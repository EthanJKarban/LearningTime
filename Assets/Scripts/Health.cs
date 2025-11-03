using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    public float hitPoints = 2;
    //public float stunImmunityTimer;

    [SerializeField] private int currencyMoolah = 50;

    private bool isDestroyed = false;
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        

        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroyed.Invoke();
            LevelManager.main.IncreaseCurrency(currencyMoolah);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
