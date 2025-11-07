using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New KnockBack Effect", menuName = "Status Effects/Knockback Effect")]
public class KnockBackEffect : StatusEffect
{
    public float SpeedPercentage; // Percentage to which it will slow the target using multiplication with decimals. (example: 0.5 = 50% speed)
    public int damagePerTick;
    public bool KnockedBack;
    public bool KnockBackImmunity;
    public float KnockBackImmunityTimer;

    public override void Apply(EM movement, Health health)
    {
        if (movement.moveSpeed < -1.5f)
        {
            movement.moveSpeed = -1.5f;
            return;
        }


        if (!KnockedBack || !KnockBackImmunity)
        {
            movement.moveSpeed = -movement.moveSpeed;
            movement.moveSpeed *= SpeedPercentage;
            KnockedBack = true;

        }
        else if (KnockedBack && !KnockBackImmunity)
        {
            movement.moveSpeed = -movement.moveSpeed;
            movement.moveSpeed *= SpeedPercentage;
        }
        else if (KnockBackImmunity)
        {
            return;
        }
    }



    public override void Tick(EM movement, Health health)
    {
        health.TakeDamage(damagePerTick);
    }

    public override void Remove(EM movement, Health health)
    {
        movement.moveSpeed = movement.baseSpeed;
        KnockedBack = false;
        KnockBackImmunity = true;
        GameObject.FindFirstObjectByType<LevelManager>().StartCoroutine(KnockBackImmunityCoolDown());
    }
    IEnumerator KnockBackImmunityCoolDown()
    {
        yield return new WaitForSeconds(KnockBackImmunityTimer);
        KnockBackImmunity = false;
    }
}