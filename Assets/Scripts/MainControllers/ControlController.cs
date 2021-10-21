using UnityEngine;
using UnityEngine.Events;

public sealed class ControlController : MonoBehaviour
{

    #region UnityEvents

    /* Array:
     * a - Dynamic - Left
     * d - Dynamic - Right
     * 
     * w - Dynamic - Zoom In
     * s - Dynamic - Zoom Out
     * 
     * q - Static - Starting Zoom And Rotation
     * esc - Static - Quit the game
    */

    [SerializeField] private UnityEvent scrollEvent;
    [SerializeField] private UnityEvent[] dynamicEventArray;
    [SerializeField] private UnityEvent[] staticEventArray;

    [SerializeField] private KeyCode[] dynamicKeyArray;
    [SerializeField] private KeyCode[] staticKeyArray;

    #endregion

    private Cell currentCell;

    private void Update()
    {
        // dynamic keys
        for (int i = 0; i < dynamicKeyArray.Length; i++)
        {
            if (Input.GetKey(dynamicKeyArray[i]))
            {
                dynamicEventArray[i].Invoke();
            }
        }

        // static keys
        for (int i = 0; i < staticKeyArray.Length; i++)
        {
            if (Input.GetKeyDown(staticKeyArray[i]))
            {
                staticEventArray[i].Invoke();
            }
        }

        // scroll delta
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            scrollEvent.Invoke();
        }

        // mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit) == true)
        {
            if (currentCell != null && raycastHit.collider.transform != currentCell.transform)
            {
                currentCell.OnDeselected();
            }

            if (raycastHit.collider.TryGetComponent(out Cell cell) == true)
            {
                if (cell != currentCell)
                {
                    currentCell = cell;
                    cell.OnSelected();
                }
                else if (Input.GetMouseButtonDown(0) == true)
                {
                    currentCell.OnPicked();
                }
            }
        }
    }
}
