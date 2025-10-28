using UnityEngine;

[CreateAssetMenu(fileName = "New Poison Effect", menuName = "Status Effects/Poison Effect")]
public class PoisonEffect : StatusEffect
{
    public float tickRate;
    public int damagePerTick;

    public override void tick(EM movement, Health health)
    {

    }
}
