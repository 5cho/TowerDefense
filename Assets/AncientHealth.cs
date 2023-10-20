using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AncientHealth : MonoBehaviour
{
    [SerializeField] private float ancientHealthMax = 5f;
    private float ancientHealth;

    public event EventHandler OnAncientHealthChanged;
    private void Awake()
    {
        ancientHealth = ancientHealthMax;
    }
    private void Update()
    {
        if(ancientHealth <= 0)
        {
            Debug.Log("You lose!");
        }
    }

    public void DealDamageToAncient(float damageToTake)
    {
        ancientHealth -= damageToTake;
        OnAncientHealthChanged?.Invoke(this, EventArgs.Empty);
    }
    public float GetAncientHealthNormalized()
    {
        return ancientHealth / ancientHealthMax;
    }
}
