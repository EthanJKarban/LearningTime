using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(fileName = "New Confusion Effect", menuName = "Status Effects/Confusion Effect")]
public class ConfusionEffect : StatusEffect
{
    public float SpeedPercentage; // Percentage to which it will slow the target using multiplication with decimals. (example: 0.5 = 50% speed)
    public int damagePerTick;
    public bool confused;
    public bool ConfuseImmunity;
    public float ConfuseImmunityTimer;

    public override void Apply(EM movement, Health health)
    {
        if (movement.moveSpeed < -1.5f)
        {
            movement.moveSpeed = -1.5f;
            return;
        }
        

        if (!confused || !ConfuseImmunity)
        {
            movement.moveSpeed = -movement.moveSpeed;
            movement.moveSpeed *= SpeedPercentage;
            confused = true;

        }
        else if (confused && !ConfuseImmunity)
        {
          movement.moveSpeed = -movement.moveSpeed;
          movement.moveSpeed *= SpeedPercentage;
        }
        else if(ConfuseImmunity)
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
        confused = false;
        ConfuseImmunity = true;
        GameObject.FindFirstObjectByType<LevelManager>().StartCoroutine( ConfuseImmunityCooldown());
    }
    IEnumerator ConfuseImmunityCooldown()
    {
        yield return new WaitForSeconds(ConfuseImmunityTimer);
        ConfuseImmunity = false;
    }
}