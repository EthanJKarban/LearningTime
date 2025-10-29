using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stun Effect", menuName = "Status Effects/Stun Effect")]
public class StunEffect : StatusEffect
{
    public bool stunImmunity;

    public override void Apply(EM movement, Health health)
    {
        movement.moveSpeed = 0f;
    }

    public override void Tick(EM movement, Health health)
    {
        
    }

    public override void Remove(EM movement, Health health)
    {
        movement.moveSpeed = movement.baseSpeed;
    }
}
