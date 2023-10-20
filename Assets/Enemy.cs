using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemySO enemySO;

    public float enemyMaxHealth;
    public float enemyDamage;
    public float enemyMoveSpeedMax;
    public float currentEnemyMoveSpeed;
    public float enemyArmor;
    public bool isFireResistant;
    public bool isFrostResistant;
    public bool isLightningResistant;
    public bool isWeakToFire;
    public bool isWeakToFrost;
    public bool isWeakToLightning;

    private bool isSlowed = false;
    private float isSlowedTimer = 0f;
    private float isSlowedTimerMax = 2f;
    private float slowMultiplier = 0.8f;

    private void Awake()
    {
        enemyMaxHealth = enemySO.enemyMaxHealth;
        enemyDamage = enemySO.enemyDamage;
        enemyMoveSpeedMax = enemySO.enemyMoveSpeed;
        currentEnemyMoveSpeed = enemyMoveSpeedMax;
        enemyArmor = enemySO.armor;
        isFireResistant = enemySO.isFireResistant;
        isFrostResistant = enemySO.isFrostResistant;
        isLightningResistant = enemySO.isLightningResistant;
        isWeakToFire = enemySO.isWeakToFire;
        isWeakToFrost = enemySO.isWeakToFrost;
        isWeakToLightning = enemySO.isWeakToLightning;
    }
    private void Update()
    {
        if (isSlowed)
        {
            currentEnemyMoveSpeed = slowMultiplier * enemyMoveSpeedMax;
            isSlowedTimer += Time.deltaTime;

            if (isSlowedTimer >= isSlowedTimerMax)
            {
                isSlowedTimer = 0f;
                isSlowed = false;
            }
        }
        else
        {
            currentEnemyMoveSpeed = enemyMoveSpeedMax;
        }
    }
    public void ApplySlowToEnemy()
    {
        if (!isSlowed)
        {
            isSlowed = true;
        }
        else
        {
            isSlowedTimer = 0f;
        }
    }
}
