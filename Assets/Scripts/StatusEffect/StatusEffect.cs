using UnityEngine;

public abstract class StatusEffect: ScriptableObject
{
    public float tickRate; //How many hits per second from status
    public float duration; // Duration of status
    
    public abstract void Apply(EM movement, Health health); //Set
    public abstract void Tick(EM movement, Health health); //During
    public abstract void Remove(EM movement, Health health); //Destroying
}

