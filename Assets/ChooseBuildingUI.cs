using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBuildingUI : MonoBehaviour
{
    [SerializeField] private Button frostTowerButton;
    [SerializeField] private Button fireTowerButton;
    [SerializeField] private Button lightningTowerButton;
    [SerializeField] private Button archerTowerButton;
    [SerializeField] private Button cannonTowerButton;

    [SerializeField] private Transform fireTower;
    [SerializeField] private Transform frostTower;
    [SerializeField] private Transform lightningTower;
    [SerializeField] private Transform archerTower;
    [SerializeField] private Transform cannonTower;

    private void Awake()
    {
        frostTowerButton.onClick.AddListener(() => {
            GridManager.Instance.SetSelectedTower(frostTower);
        });
        fireTowerButton.onClick.AddListener(() => {
            GridManager.Instance.SetSelectedTower(fireTower);
        });
        lightningTowerButton.onClick.AddListener(() => {
            GridManager.Instance.SetSelectedTower(lightningTower);
        });
        archerTowerButton.onClick.AddListener(() => {
            GridManager.Instance.SetSelectedTower(archerTower);
        });
        cannonTowerButton.onClick.AddListener(() => {
            GridManager.Instance.SetSelectedTower(cannonTower);
        });
    }
}
