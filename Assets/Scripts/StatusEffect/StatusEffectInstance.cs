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
        if (!effect) return;

        tickTimer += Time.deltaTime;
        if (tickTimer > effect.tickRate)
        {
            effect.Tick(movement, health);
            tickTimer = 0f;
            Debug.Log("Ticking down");
        }

        duration += Time.deltaTime;
        if (duration > effect.duration)
        {
            effect.Remove(movement, health);
            effect = null;
            Debug.Log("Effect ended.");
        }
    }

    public void Apply(StatusEffect newEffect)
    {
        effect = newEffect;
        effect.Apply(movement, health);
        duration = 0f;
        Debug.Log("Afflicted with a status effect.");
    }
}
