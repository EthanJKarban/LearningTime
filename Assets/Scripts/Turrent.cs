using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Turrent : MonoBehaviour
{
    [Header("References")]
    public Transform turrentRotationPoint;
    [SerializeField] LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button upgradeButton;

    [Header("Attribute")]
    [SerializeField] private float targettingRange = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float bps = 1f; //Bullets per second
    [SerializeField] private int baseUpgradeCost = 50;


    private float bpsBase;
    private float targettingRangeBase;

    private Transform target;
    private float timeUntilFire;

    private int level = 1;

    private void Start()
    {
        bpsBase = bps;
        targettingRangeBase = targettingRange;

        upgradeButton.onClick.AddListener(UpgradeTurret);
    }
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
    public void OpenUpgradeUI()
    {
        upgradeUI.SetActive(true);
    }

    public void CloseUpgradeUI()
    {
        upgradeUI.SetActive(false);
        UIManager.main.SetHoverUIState(false);
    }

    public void UpgradeTurret()
    {
        if (baseUpgradeCost > LevelManager.main.currency)
        {
            LevelManager.main.SpendCurrency(baseUpgradeCost);
        }
        level++;

        bps = CalculateBPS();
        targettingRange = CalculateRange();

        CloseUpgradeUI();
        Debug.Log("New BPS:" + bps);
        Debug.Log("New BPS:" + targettingRange);
        Debug.Log("New Cost " + baseUpgradeCost);

        CloseUpgradeUI();
    }
    private int CalculateCost()
    {
        return Mathf.RoundToInt(baseUpgradeCost * Mathf.Pow(level,  0.8f));
    }
    private float CalculateBPS()
    {
        return bpsBase *  Mathf.Pow(level, 0.6f);
    }
    private float CalculateRange()
    {
        return targettingRangeBase * Mathf.Pow(level, 0.4f);
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(transform.position, transform.forward, targettingRange);
    }


}
