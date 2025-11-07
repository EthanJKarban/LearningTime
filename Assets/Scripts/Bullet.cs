using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float bulletDamage = 1;
    [SerializeField] private float explosionDamage;
    [SerializeField] private StatusEffect statusEffect;
    [SerializeField] private float tickRate;
    [SerializeField] private float bulletLifetime = 5f;
    [SerializeField] private float explosionRadius;
    [SerializeField] private bool isExplosive;

    private float lifetimeTimer;
    private Transform target;


    public void SetTarget(Transform _target)
    {
        
        target = _target;
    }
    private void FixedUpdate()
    {   if (!target)return;

        Vector2 direction = (target.position - transform.position).normalized;

        rb.linearVelocity = direction * bulletSpeed;

    }
    private void Update()
    {
       
        lifetimeTimer += Time.deltaTime;
        if (lifetimeTimer >= bulletLifetime)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (statusEffect)
        {
            other.gameObject.GetComponent<StatusEffectInstance>().Apply(statusEffect);
        }
        if (isExplosive)
        {   
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
            other.gameObject.GetComponent<Health>().TakeDamage(explosionDamage);
            ExplosionRangeCheck();
        }
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }
    private void ExplosionRangeCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            Health health = collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(explosionDamage);
            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
