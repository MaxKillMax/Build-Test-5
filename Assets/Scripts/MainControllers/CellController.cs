using UnityEngine;

public sealed class CellController : MonoBehaviour
{
    [SerializeField] private InterfaceController interfaceController;

    [SerializeField] private Material selectedCell;
    [SerializeField] private Material unselectedCell;

    private Cell pickedCell;
    private Building pickedbuilding;

    private Cell[,] cellGrid;

    public void SetInformation(Cell[,] cellGrid)
    {
        this.cellGrid = cellGrid;
    }

    public void ClearPicked()
    {
        pickedCell = null;
        pickedbuilding = null;
    }

    #region Cells

    public void GetSelectedMaterial(MeshRenderer cellMeshRenderer)
    {
        cellMeshRenderer.material = selectedCell;
    }

    public void GetUnselectedMaterial(MeshRenderer cellMeshRenderer)
    {
        cellMeshRenderer.material = unselectedCell;
    }

    public void OpenCellInterface(Cell cell)
    {
        if (pickedCell == null)
        {
            pickedCell = cell;
            interfaceController.OpenCellInterface();
        }
    }

    #endregion

    #region Buildings

    public void OpenBuildingInterface(Cell cell, Building building)
    {
        if (pickedCell == null)
        {
            pickedCell = cell;
            pickedbuilding = building;
            interfaceController.OpenBuildingInterface(building);
        }
    }

    public void AddBuildingToCell(Building building)
    {
        Building thisBuilding = Instantiate(building);
        thisBuilding.transform.SetParent(pickedCell.transform);
        thisBuilding.transform.position = new Vector3(pickedCell.transform.position.x, thisBuilding.transform.position.y, pickedCell.transform.position.z);

        pickedCell.SetInformationAboutBuilding(thisBuilding);
    }

    public void UpgradeBuilding()
    {
        Functional functionalPickedBuilding = pickedbuilding as Functional;
        functionalPickedBuilding.UpgradeBuilding();

        // If there are still new types of buildings with levels, they should be inherited from functional
    }

    public void DestroyBuilding()
    {
        pickedCell.DestroyBuilding();
        pickedbuilding.DestroyBuilding();
    }

    public void RotateBuilding()
    {
        pickedbuilding.RotateBuilding();
    }

    #endregion
}
