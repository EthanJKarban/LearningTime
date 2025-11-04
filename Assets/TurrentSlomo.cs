using UnityEditor;
using UnityEngine;

public class TurrentSlomo : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask EnemyMask;

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
            FreezeEffect();
            timeUntilFire = 0f;
        }
    }

    private void FreezeEffect()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targettingRange, Vector2.up, 0f);
        for (int i = 0; i < hits.Length; i++)
        {
            if(hits.Length > 0)
            {
                RaycastHit2D hit = hits[i];


                StatusEffectInstance statusEffectInstance = hit.collider.gameObject.GetComponent<StatusEffectInstance>();
                if (statusEffectInstance != null)
                {
                    StatusEffect freezeEffect = Resources.Load<StatusEffect>("FreezeEffect");
                    statusEffectInstance.Apply(freezeEffect);
                    Debug.Log("HONEY WHERE IS MY SUPER SUIT?!");
                }
            }
           
        }
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targettingRange);
    }
}
