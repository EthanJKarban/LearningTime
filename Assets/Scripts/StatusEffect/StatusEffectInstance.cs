using UnityEngine;

public class StatusEffectInstance : MonoBehaviour
{
    public StatusEffect effect;

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
        if (!effect) return; // If no effect happens instead of it having a stroke it will now just return nothing and chill out.

        tickTimer += Time.deltaTime;
        if (tickTimer > effect.tickRate) // If the tick timer is bigger than the tick rate it will tick down, doing damage.
        {
            effect.Tick(movement, health);
            tickTimer = 0f;
            Debug.Log("Ticking down");
        }

        duration += Time.deltaTime;
        if (duration > effect.duration)  // Duration, when the duration is bigger than effect duration it removes the effect, by turning it null.
        {
            effect.Remove(movement, health);
            effect = null;
            Debug.Log("Effect ended.");
        }
    }

    public void Apply(StatusEffect newEffect) // Will apply a new effect and reset duration.
    {
        effect = newEffect;
        effect.Apply(movement, health);
        duration = 0f;
        Debug.Log("Afflicted with a status effect.");
    }
}
