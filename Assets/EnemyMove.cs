using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private float enemyDamageTimer = 1f;
    private Transform[] levelMarkers;
    private Vector3 targetPosition;
    private int currentTargetMarker;
    private bool hasReachedEnd = false;
    
    private void Awake()
    {
        levelMarkers = TDGameManager.Instance.GetLevelMarkers();
        currentTargetMarker = 1;
        targetPosition = levelMarkers[currentTargetMarker].position;
    }

    private void Update()
    {
        
        if (hasReachedEnd)
        {
            enemyDamageTimer -= Time.deltaTime;
            if (enemyDamageTimer <= 0f)
            {
                enemyDamageTimer = 1f;
                TDGameManager.Instance.AttackAncient(enemy.enemyDamage);
            }
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemy.currentEnemyMoveSpeed * Time.deltaTime);  
        
        if(Vector3.Distance(transform.position, targetPosition) < 0.1)
        {
            currentTargetMarker++;
            if(currentTargetMarker == levelMarkers.Length)
            {
                Debug.Log("Reached the end!");
                hasReachedEnd = true;
            }
            else
            {
                targetPosition = levelMarkers[currentTargetMarker].position;
            }
        }
    }
}
