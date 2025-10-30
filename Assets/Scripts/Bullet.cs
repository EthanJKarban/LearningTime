using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;
    [SerializeField] private StatusEffect statusEffect;
    [SerializeField] private float tickRate;
    [SerializeField] private float bulletLifetime = 5f;
    
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
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }
   
}
