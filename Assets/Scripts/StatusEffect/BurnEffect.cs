using UnityEngine;

[CreateAssetMenu(fileName = "New Burn Effect", menuName = "Status Effects/Burn Effect")]
public class BurnEffect : StatusEffect
{
    public int damagePerTick;

    public override void Apply(EM movement, Health health)
    {

    }

    public override void Tick(EM movement, Health health)
    {
        health.TakeDamage(damagePerTick);
    }

    public override void Remove(EM movement, Health health)
    {

    }
}
