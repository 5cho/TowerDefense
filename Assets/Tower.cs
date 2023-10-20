using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerSO towerSO;
    [SerializeField] private Transform projectileSpawnTransform;
    private Transform projectile;
    private float towerDamage;
    private float fireRateTimerMax;
    private float towerRange;
    private DamageType towerDamageType;
    private float fireRateTimer = 0f;
    private Transform target;
    private bool hasTarget;
    private List<EnemyMove> possibleTargetList;

    private void Awake()
    {
        projectile = towerSO.projectile.transform;
        towerDamage = towerSO.towerDamage;
        fireRateTimerMax = towerSO.towerFireRate;
        towerRange = towerSO.towerRange;
        towerDamageType = towerSO.towerDamageType;

        possibleTargetList = new List<EnemyMove>();
    }
    private void Update()
    {
        fireRateTimer += Time.deltaTime;
        if(fireRateTimer > fireRateTimerMax)
        {
            SetTowerTarget();
            if (hasTarget)
            {
                fireRateTimer = 0f;
                FireProjectile();
            }
        }
    }
    private void FireProjectile()
    {
        Vector3 projectileSpawnOffset = new Vector3(0f, 0.5f, 0f);
        Projectile firedProjectile = Instantiate(projectile, transform.position + projectileSpawnOffset, Quaternion.identity).GetComponent<Projectile>();
        firedProjectile.SetTarget(target);
        firedProjectile.SetDamage(towerDamage);
        firedProjectile.SetDamageType(towerDamageType);
    }
    private void SetTowerTarget()
    {
        Collider2D[] allTargetsInRange = Physics2D.OverlapCircleAll(projectileSpawnTransform.position, towerRange);
        if(allTargetsInRange.Length <= 0)
        {
            target = null;
            SetHasTarget();
            return;
        }
        foreach (Collider2D possibleTarget in allTargetsInRange)
        {
            if (possibleTarget.TryGetComponent<EnemyMove>(out EnemyMove enemyMove))
            {
                possibleTargetList.Add(enemyMove);
            }
        }
        if(possibleTargetList.Count <= 0)
        {
            target = null;
            SetHasTarget();
            
            return;
        }
        target = null;

        foreach (EnemyMove enemy in possibleTargetList)
        {
            if (target == null)
            {
                target = enemy.transform;

                continue;
            }
            if (Vector2.Distance(transform.position, target.position) > Vector2.Distance(transform.position, enemy.transform.position))
            {
                target = enemy.transform;
            }
        }
        possibleTargetList.Clear();
        SetHasTarget();
    }
    private void SetHasTarget()
    {
        if(target == null)
        {
            hasTarget = false;
        }
        else
        {
            hasTarget = true;
        }
    }
}
