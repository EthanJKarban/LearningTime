using UnityEngine;

[CreateAssetMenu(fileName = "New Freeze Effect", menuName = "Status Effects/Freeze Effect")]
public class FreezeEffect : StatusEffect
{
    public float slowPercentage;

    public override void Apply(EM movement, Health health)
    {
        movement.moveSpeed *= slowPercentage;
        if (movement.moveSpeed < 0.25f)
        {
            movement.moveSpeed = 0.25f;
            return;
        }
    }

    public override void Tick(EM movement, Health health)
    {

    }

    public override void Remove(EM movement, Health health)
    {
        movement.moveSpeed = movement.baseSpeed;
    }
}
