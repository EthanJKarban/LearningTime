using UnityEngine;

public class TurrentSlomo : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float targettingRange = 5f;
    [SerializeField] private float aps = 1f; //Attacks per second

    private float timeUntilFire;

    private void Update()
    {
        
            
            /*if (timeUntilFire += Time.deltaTime >= 1f / aps)
            {
                Time.timeScale = 0.5f; // Slow down time
            FreezeEffect();
                timeUntilFire = 0f;
        }
    }

    private void FreezeEffect()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targettingRange, Vector2.up, 0f);
        foreach (var hit in hits)
        {
            StatusEffectInstance statusEffectInstance = hit.collider.gameObject.GetComponent<StatusEffectInstance>();
            if (statusEffectInstance != null)
            {
                // Assuming FreezeEffect is a predefined StatusEffect
                StatusEffect freezeEffect = Resources.Load<StatusEffect>("FreezeEffect");
                statusEffectInstance.Apply(freezeEffect);
            }
        }*/
    }
}
