using UnityEngine;

[CreateAssetMenu(fileName = "New Burn Effect", menuName = "Status Effects/Burn Effect")]
public class BurnEffect : StatusEffect
{
    public float burnDuration;
    public int tickRate;
    public int damagePerTick;

    public override void tick(EM movement, Health health)
    {

    }
}
