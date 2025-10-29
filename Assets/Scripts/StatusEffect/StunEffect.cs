using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stun Effect", menuName = "Status Effects/Stun Effect")]
public class StunEffect : StatusEffect
{
    public bool stunImmunity;
    public float stunImmunityTimer;

    public override void Apply(EM movement, Health health)
    {
        if(stunImmunity == true)
        {
            return;
        }
        else
        {
            movement.moveSpeed = 0f;
        }
            
    }

    public override void Tick(EM movement, Health health)
    {
        
    }

    public override void Remove(EM movement, Health health)
    {
        movement.moveSpeed = movement.baseSpeed;
        stunImmunity = false;
       StunImmunityCooldown();

    }
    IEnumerator StunImmunityCooldown()
    {
        yield return new WaitForSeconds(stunImmunityTimer);
        stunImmunity = true;
    }
}
