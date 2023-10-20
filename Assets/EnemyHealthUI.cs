using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] EnemyHealth enemyHealth;
    [SerializeField] Image healthFillImage;
    private float fillAmount;
    private void Start()
    {
        enemyHealth.OnHealthChanged += EnemyHealth_OnHealthChanged;

        fillAmount = 1f;
    }
    private void Update()
    {
        healthFillImage.fillAmount = fillAmount;
    }
    private void EnemyHealth_OnHealthChanged(object sender, System.EventArgs e)
    {
        fillAmount = enemyHealth.GetRemainingHealthNormalized();
    }
}
