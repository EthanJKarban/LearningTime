
using UnityEngine;

public class EM : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    public float moveSpeed = 2f;
    [HideInInspector] public float baseSpeed;

    private Transform targets;
    private int pathIndex = 0;
    void Start()
    {
        targets = LevelManager.main.path[pathIndex];
        baseSpeed = moveSpeed;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, targets.position) <= 0.1f)
        {
            pathIndex++;
            
            if (pathIndex == LevelManager.main.path.Length)
            {
                EnemySpawner.onEnemyDestroyed.Invoke();
                Destroy(gameObject);
                return;
            }
            else             
            {
                targets = LevelManager.main.path[pathIndex];
            }
        }
    }
    private void FixedUpdate()
    {
         Vector2 direction = (targets.position - transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }
}
