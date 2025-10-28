using UnityEngine;

[CreateAssetMenu(fileName = "New Stun Effect", menuName = "Status Effects/Stun Effect")]
public class StunEffect : StatusEffect
{
    public float stunDuration;
    public bool stunImmunity;

    public override void tick(EM movement, Health health)
    {
        movement.moveSpeed /= 2;
    }
}
