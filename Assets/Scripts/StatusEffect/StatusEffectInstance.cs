

using System.Collections.Generic;
using UnityEngine;

public class StatusEffectInstance : MonoBehaviour
{
    
    public List<StatusEffect> effects;
    private EM movement;
    private Health health;

    private float tickTimer;
    private float duration;

    public void Awake()
    {
        
        movement = GetComponent<EM>();
        health = GetComponent<Health>();
    }

    public void Update()
    {
        tickTimer += Time.deltaTime;
        duration += Time.deltaTime;

        foreach (var item in effects) 
        {
            if (tickTimer > item.tickRate) // If the tick timer is bigger than the tick rate it will tick down, doing damage.
            {
                item.Tick(movement, health);
                tickTimer = 0f;
                Debug.Log("Ticking down");
            }

            if (duration > item.duration)  // Duration, when the duration is bigger than effect duration it removes the effect, by turning it null.
            {
                item.Remove(movement, health);
                effects.Remove(item);
                Debug.Log("Effect ended.");
                break;
            }
        }
    }

    public void Apply(StatusEffect newEffect) // Will apply a new effect and reset duration.
    {
        if(effects.Contains(newEffect))
        {
            duration = 0f;
            return; // If it already contains the effect, it will not apply it again.
        }
        effects.Add(newEffect);
        newEffect.Apply(movement, health);
        duration = 0f;
        Debug.Log("Afflicted with a status effect.");
    }
}
