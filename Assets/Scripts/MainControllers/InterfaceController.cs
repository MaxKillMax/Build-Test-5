using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public sealed class InterfaceController : MonoBehaviour
{
    [SerializeField] private CellController cellController;

    #region cellInterface

    [SerializeField] private GameObject cellInterface;
    private float cellInterfaceStartX;
    private float cellInterfaceEndX;

    #endregion

    #region buildingInterface

    [SerializeField] private GameObject buildingInterface;
    private float buildingInterfaceStartX;
    private float buildingInterfaceEndX;

    [SerializeField] private Text buildingName;
    [SerializeField] private Text buildingDescription;
    [SerializeField] private GameObject[] buildingButtonArray;

    #endregion

    private void Awake()
    {
        cellInterfaceStartX = cellInterface.transform.localPosition.x;
        cellInterfaceEndX = cellInterface.transform.localPosition.x + 400;

        buildingInterfaceStartX = buildingInterface.transform.localPosition.x;
        buildingInterfaceEndX = buildingInterface.transform.localPosition.x + 400;
    }

    public void OpenCellInterface()
    {
        cellInterface.transform.DOLocalMoveX(cellInterfaceEndX, 0.5f);
    }

    public void CloseCellInterface()
    {
        cellInterface.transform.DOLocalMoveX(cellInterfaceStartX, 0.5f);
        cellController.ClearPicked();
    }

    public void OpenBuildingInterface(Building building)
    {
        building.GetInformation(out string name, out string description, out int type);

        buildingName.text = name;
        buildingDescription.text = description;

        for (int i = 0; i < buildingButtonArray.Length; i++)
        {
            if (i != type)
            {
                buildingButtonArray[i].SetActive(false);
            }
            else
            {
                buildingButtonArray[i].SetActive(true);
            }
        }

        buildingInterface.transform.DOLocalMoveX(buildingInterfaceEndX, 0.5f);
    }

    public void CloseBuildingInterface()
    {
        buildingInterface.transform.DOLocalMoveX(buildingInterfaceStartX, 0.5f);
        cellController.ClearPicked();
    }
}
