using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EnemySO : ScriptableObject
{
    public string enemyName;
    public float enemyMaxHealth;
    public float enemyDamage;
    public float enemyMoveSpeed;
    public float armor;
    public bool isFireResistant;
    public bool isFrostResistant;
    public bool isLightningResistant;
    public bool isWeakToFire;
    public bool isWeakToFrost;
    public bool isWeakToLightning;
}
