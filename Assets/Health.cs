using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;


    private bool isDestroyed = false;
    public void TakeDamage(int damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroyed.Invoke();
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
