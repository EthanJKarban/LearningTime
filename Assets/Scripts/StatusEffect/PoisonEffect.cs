using UnityEngine;

[CreateAssetMenu(fileName = "New Poison Effect", menuName = "Status Effects/Poison Effect")]
public class PoisonEffect : StatusEffect
{
    public float slowPercentage; // Percentage to which it will slow the target using multiplication with decimals. (example: 0.5 = 50% speed)
    public int damagePerTick; 

    public override void Apply(EM movement, Health health)
    {
        if (movement.moveSpeed < 0.6)
        {
            movement.moveSpeed = 0.6f;
            return;
        }
        movement.moveSpeed *= slowPercentage;
    }

    public override void Tick(EM movement, Health health)
    {
        health.TakeDamage(damagePerTick);
    }

    public override void Remove(EM movement, Health health)
    {
        movement.moveSpeed = movement.baseSpeed;
    }
}
