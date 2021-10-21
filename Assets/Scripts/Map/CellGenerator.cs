using UnityEngine;

public sealed class CellGenerator : MonoBehaviour
{
    [SerializeField] private GameObject rotationCameraObject;
    [SerializeField] private CellController cellController;
    [SerializeField] private Transform cellParent;
    [SerializeField] private Cell cellPrefab;

    [Header("Atributes")]
    [SerializeField] private int xLength;
    [SerializeField] private int zLength;

    private Cell[,] cellGrid;

    private void Awake()
    {
        cellGrid = new Cell[xLength, zLength];
        rotationCameraObject.transform.position = new Vector3(xLength, 4, zLength);

        for (int x = 0; x < cellGrid.GetLength(0); x++)
        {
            for (int z = 0; z < cellGrid.GetLength(1); z++)
            {
                cellGrid[x, z] = Instantiate(cellPrefab);

                cellGrid[x, z].SetInformation(cellController);
                cellGrid[x, z].transform.SetParent(cellParent);
                cellGrid[x, z].transform.position = new Vector3(1 + x * 2, cellGrid[x, z].transform.position.y, 1 + z * 2);
            }
        }

        cellController.SetInformation(cellGrid);
    }
}
