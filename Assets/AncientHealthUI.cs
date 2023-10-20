using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AncientHealthUI : MonoBehaviour
{
    [SerializeField] private AncientHealth ancientHealth;
    [SerializeField] private Image ancientHealthBarImage;

    private void Start()
    {
        ancientHealth.OnAncientHealthChanged += AncientHealth_OnAncientHealthChanged;

        ancientHealthBarImage.fillAmount = 1f;
    }

    private void AncientHealth_OnAncientHealthChanged(object sender, System.EventArgs e)
    {
        ancientHealthBarImage.fillAmount = ancientHealth.GetAncientHealthNormalized();
    }
}
