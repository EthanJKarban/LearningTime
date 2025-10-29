using UnityEngine;

[CreateAssetMenu(fileName = "New Poison Effect", menuName = "Status Effects/Poison Effect")]
public class PoisonEffect : StatusEffect
{
    public float slowPercentage;
    public int damagePerTick;

    public override void Apply(EM movement, Health health)
    {
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
