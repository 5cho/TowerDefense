using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class TowerSO : ScriptableObject
{
    public float towerDamage;
    public float towerFireRate;
    public float towerRange;
    public DamageType towerDamageType;
    public GameObject projectile;
}
