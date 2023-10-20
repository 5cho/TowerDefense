using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    private float damage;
    private DamageType projectileDamageType;
    [SerializeField] private float projectileSpeed;

    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, projectileSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetTarget(Transform targetToSet)
    {
        target = targetToSet;
    }
    public void SetDamage(float damageToSet)
    {
        damage = damageToSet;
    }
    public void SetDamageType(DamageType damageTypeToSet)
    {
        projectileDamageType = damageTypeToSet;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamage(damage, projectileDamageType);
            Destroy(gameObject);
        }
    }
}
