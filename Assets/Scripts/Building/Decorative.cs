using UnityEngine;

public sealed class Decorative : Building
{
    protected override void Awake()
    {
        buildingType = 0;
    }
}
