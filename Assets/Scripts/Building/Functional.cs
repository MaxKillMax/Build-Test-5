using UnityEngine;

public sealed class Functional : Building
{
    [SerializeField] private GameObject[] buildingLevels;

    private int currentLevel = 0;
    private int maxLevel = 5;

    protected override void Awake()
    {
        buildingType = 1;
    }

    public void UpgradeBuilding()
    {
        if (currentLevel < maxLevel - 1)
        {
            currentLevel++;
            buildingLevels[currentLevel].SetActive(true);
        }
    }
}
