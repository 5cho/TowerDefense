using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    public event EventHandler OnHealthChanged;

    private float remainingHealth;
    private float maxHealth;

    private bool isOnFire;
    private int isOnFireDuration = 2;
    private float fireDamageTickTimer;
    private float fireDamage = 1f;

    private float lightningDamageRadius = 1f;
    

    private void Start()
    {
        maxHealth = enemy.enemyMaxHealth;
        remainingHealth = maxHealth;
    }
    private void Update()
    {
        if (isOnFire)
        {
            HandleFireDamageOverTime();
        }

        if(remainingHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    public void TakeDamage(float damageToTake, DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Physical:
                damageToTake -= enemy.enemyArmor;
                break;
            case DamageType.Fire:
                damageToTake = TakeFireDamageCalculation(damageToTake);
                break;
            case DamageType.Frost:
                damageToTake = TakeFrostDamageFrostCalculation(damageToTake);
                break;
            case DamageType.Lightning:
                damageToTake = TakeLightningDamageCalculation(damageToTake);
                break;
            default:
                break;
        }
        remainingHealth -= damageToTake;

        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }
    private float TakeFireDamageCalculation(float damageToTake)
    {
        if (enemy.isFireResistant)
        {
            damageToTake = Mathf.Round(damageToTake / 2);
        }
        else if (enemy.isWeakToFire)
        {
            damageToTake *= 2;
        }
        if (!isOnFire)
        {
            isOnFire = true;
        }
        else
        {
            isOnFireDuration = 2;
        }

        return damageToTake;
    }
    private float TakeFrostDamageFrostCalculation(float damageToTake)
    {
        if (enemy.isFrostResistant)
        {
            damageToTake = Mathf.Round(damageToTake / 2);
        }
        else if (enemy.isWeakToFrost)
        {
            damageToTake *= 2;
        }
        enemy.ApplySlowToEnemy();
        return damageToTake;
    }
    private float TakeLightningDamageCalculation(float damageToTake)
    {
        if (enemy.isLightningResistant)
        {
            damageToTake = Mathf.Round(damageToTake / 2);
        }
        else if (enemy.isWeakToLightning)
        {
            damageToTake *= 2;
        }
        HandleLightningDamageAOE();
        return damageToTake;
    }
    public float GetRemainingHealthNormalized()
    {
        return remainingHealth / maxHealth;
    }
    private void HandleLightningDamageAOE() 
    {
        Collider2D[] collidersInRange = Physics2D.OverlapCircleAll(transform.position, lightningDamageRadius);

        List<EnemyHealth> enemiesInRange = new List<EnemyHealth>();

        foreach(Collider2D collider2D in collidersInRange)
        {
            if(collider2D.TryGetComponent<EnemyHealth>(out EnemyHealth enemyInRange))
            {
                if(enemyInRange == this)
                {
                    continue;
                }
                enemiesInRange.Add(enemyInRange);
            }
        }
        foreach(EnemyHealth enemyHealth in enemiesInRange)
        {
            enemyHealth.TakeLightningAOEDamage(1f);
        }

    }
    private void TakeLightningAOEDamage(float damageToTake)
    {
        if (enemy.isLightningResistant)
        {
            damageToTake = Mathf.Round(damageToTake / 2);
        }
        else if (enemy.isWeakToLightning)
        {
            damageToTake *= 2;
        }

        remainingHealth -= damageToTake;

        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }
    private void HandleFireDamageOverTime()
    {
        fireDamageTickTimer += Time.deltaTime;
        if (fireDamageTickTimer >= 1f)
        {
            fireDamageTickTimer = 0f;
            TakeDamage(fireDamage, DamageType.Fire);
            isOnFireDuration--;
            if (isOnFireDuration == 0)
            {
                isOnFireDuration = 2;
                isOnFire = false;
            }
        }
    }
}
