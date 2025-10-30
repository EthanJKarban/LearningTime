using UnityEngine;
using UnityEditor;

public class Turrent : MonoBehaviour
{
    [Header("References")]
    public Transform turrentRotationPoint;
    [SerializeField] LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;


    [Header("Attribute")]
    [SerializeField] private float targettingRange = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float bps = 1f; //Bullets per second

    private Transform target;
    private float timeUntilFire;


    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }
        
            RotateTorwardsTarget();

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;

            if(timeUntilFire >= 1f / bps)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }
    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }
    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targettingRange, Vector2.up, 0f, enemyMask);

        if(hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targettingRange;
    }
    public void RotateTorwardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        turrentRotationPoint.rotation = Quaternion.RotateTowards(turrentRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(transform.position, transform.forward, targettingRange);
    }


}
