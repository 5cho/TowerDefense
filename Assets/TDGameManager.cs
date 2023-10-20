using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDGameManager : MonoBehaviour
{
    public static TDGameManager Instance { get; private set; }

    [SerializeField] private Transform[] levelMarkers;
    [SerializeField] private GameObject[] enemiesToSpawn;
    [SerializeField] private AncientHealth ancientHealth;


    private float spawnTimer = 0f;
    private float spawnTimerMax = 3f;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > spawnTimerMax)
        {
            spawnTimer = 0f;
            int enemyToSpawnIndex = Random.Range(0, enemiesToSpawn.Length);
            Instantiate(enemiesToSpawn[enemyToSpawnIndex], levelMarkers[0].position, Quaternion.identity);
        }
    }
    public Transform[] GetLevelMarkers()
    {
        return levelMarkers;
    }
    public void AttackAncient(float damage)
    {
        ancientHealth.DealDamageToAncient(damage);
    }
}
