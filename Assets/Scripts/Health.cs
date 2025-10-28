using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    public int hitPoints = 2;
    [SerializeField] private int currencyMoolah = 5;

    private bool isDestroyed = false;
    public void TakeDamage(int damage)
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
