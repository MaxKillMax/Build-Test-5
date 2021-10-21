using UnityEngine;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    // ��� ������ ������� ������� �������� �� ������, �� ������ ���������� �� ��� � ����������, ����� �� �����������
    // ��� ������ ������� ������������� �� ����� ����, �� ������ ���� ������ ������������

    [SerializeField] private Cell cell;
    [SerializeField] private MeshRenderer meshRenderer;

    private Building building;
    private CellController cellController;

    public void SetInformationAboutBuilding(Building building)
    {
        this.building = building;
    }

    public void SetInformation(CellController cellController)
    {
        this.cellController = cellController;
    }

    public void DestroyBuilding()
    {
        building = null;
    }

    public virtual void OnPicked()
    {
        if (building == null)
        {
            cellController.OpenCellInterface(cell);
        }
        else
        {
            cellController.OpenBuildingInterface(cell, building);
        }
    }

    public virtual void OnSelected()
    {
        cellController.GetSelectedMaterial(meshRenderer);

        if (building != null)
        {
            building.OnSelected();
        }
    }

    public virtual void OnDeselected()
    {
        cellController.GetUnselectedMaterial(meshRenderer);

        if (building != null)
        {
            building.OnDeselected();
        }
    }
}
