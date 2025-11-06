using Unity.VisualScripting;

using UnityEngine;

public class TurrentSlomo : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;

    [Header("Attributes")]
    [SerializeField] private float targettingRange = 5f;
    [SerializeField] private StatusEffect statusEffect;
    [SerializeField] private float aps = 1f; //Attacks per second

    private float timeUntilFire;

    private void Update()
    {
        timeUntilFire += Time.deltaTime;

        if (timeUntilFire >= 1f / aps)
        {

            timeUntilFire = 0f;
            AreaEffect();
            
        }
    }

    private void AreaEffect()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targettingRange, Vector2.up, 0f, enemyMask);
        
        
            if(hits.Length > 0)
            {
               for (int i = 0; i < hits.Length; i++)
               {
                RaycastHit2D hit = hits[i];


                StatusEffectInstance statusEffectInstance = hit.collider.gameObject.GetComponent<StatusEffectInstance>();
                if (statusEffect)
                {
                    Debug.Log("Effected");
                    Applying();
                }
                else if (!statusEffect)
                {
                    Debug.Log("No status effect assigned to turret.");
                }
                else if(!statusEffectInstance)
                {
                    Debug.Log("They are immune to status effects.");
                }
            }
                
            }
           
        
    }
    private void Applying()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targettingRange, Vector2.up, 0f, enemyMask);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];
            StatusEffectInstance statusEffectInstance = hit.collider.gameObject.GetComponent<StatusEffectInstance>();
            if (statusEffectInstance)
            {
                timeUntilFire = 0f;
                statusEffectInstance.Apply(statusEffect);
            }
        }
    }
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (statusEffect)
    //    {

    //    }
    //}

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        UnityEditor.Handles.color = Color.cyan;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, targettingRange);
    }

#endif
}
