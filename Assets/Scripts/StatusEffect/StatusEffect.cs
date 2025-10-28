using UnityEngine;

public abstract class StatusEffect: ScriptableObject
{
    public abstract void tick(EM movement, Health health);
}

