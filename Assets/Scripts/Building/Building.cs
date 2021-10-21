using UnityEngine;
using DG.Tweening;

public abstract class Building : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private string buildingName;
    [SerializeField] private string buildingDescription;

    [Header("Other")]
    [SerializeField] private GameObject selectedObject;

    protected int buildingType;
    private float currentRotation = 0;

    protected abstract void Awake();

    public void DestroyBuilding()
    {
        Destroy(gameObject);
    }

    public void RotateBuilding()
    {
        currentRotation += 90;
        transform.DOLocalRotateQuaternion(Quaternion.Euler(0, currentRotation, 0), 0.5f);
    }

    public void OnSelected()
    {
        selectedObject.SetActive(true);
    }

    public void OnDeselected()
    {
        selectedObject.SetActive(false);
    }

    public void GetInformation(out string name, out string description, out int type)
    {
        name = buildingName;
        description = buildingDescription;
        type = buildingType;
    }
}
