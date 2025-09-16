using UnityEngine;
public class CameraInitializer : MonoBehaviour
{
    [Header("Maincameras")]
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Camera _inspectionCamera;

    private void Start()
    {
        if (_mainCamera == null)
        _mainCamera = Camera.main;
        if (_inspectionCamera == null)
            _inspectionCamera = GameObject.Find("InspectionCamera").GetComponent<Camera>();

        _mainCamera.enabled = true;
        _inspectionCamera.enabled = false;

        Debug.Log("Камеры инициализированы: Основная камера активна");
    }
}
