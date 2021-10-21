using UnityEngine;
using DG.Tweening;

public sealed class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    private Vector3 startPosition;

    private float currentRotation = 0;

    private void Awake()
    {
        startPosition = mainCamera.transform.localPosition;
    }

    public void OnZoomChanged(float value)
    {
        mainCamera.DOLocalMove
            (new Vector3(mainCamera.localPosition.x + value, mainCamera.localPosition.y - value * 1.5f, mainCamera.localPosition.z + value), 0.5f);
    }

    public void OnZoomChangedByScroll(float multiply)
    {
        float value = Input.GetAxis("Mouse ScrollWheel") * multiply;
        OnZoomChanged(value);
    }

    public void OnCameraRotate(float value)
    {
        currentRotation += value;
        transform.DOLocalRotateQuaternion
            (Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, currentRotation, 0), 1), 0.5f);
    }

    public void ClearPositionAndRotation()
    {
        transform.DOLocalRotateQuaternion(Quaternion.identity, 1f);
        mainCamera.transform.DOLocalMove(startPosition, 1f);

        currentRotation = 0;
    }
}
