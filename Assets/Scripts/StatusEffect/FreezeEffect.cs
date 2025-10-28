using UnityEngine;

[CreateAssetMenu(fileName = "New Freeze Effect", menuName = "Status Effects/Freeze Effect")]
public class FreezeEffect : StatusEffect
{
    public float slowDuration;
    public float slowPercentage;

    public override void tick(EM movement, Health health)
    {

    }
}
