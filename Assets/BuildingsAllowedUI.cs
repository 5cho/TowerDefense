using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingsAllowedUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buildingsAllowedText;

    private void Start()
    {
        GridManager.Instance.OnBuilt += GridManager_OnBuilt;
    }

    private void GridManager_OnBuilt(object sender, System.EventArgs e)
    {
        buildingsAllowedText.text = "Builds allowed: " + GridManager.Instance.GetNumberOfBuildingsAvailable();
    }
}
