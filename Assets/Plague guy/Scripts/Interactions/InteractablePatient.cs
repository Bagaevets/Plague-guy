using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractablePatient : MonoBehaviour, IInteractable
{
    [Header("Patient settings")]
    [SerializeField] private string _interactionPrompt = "Осмотреть пациента";
    [SerializeField] private bool _canInteract = true;

    [Header("Scene Settings")]
    [SerializeField] private string _inspectionSceneName = "InspectionScene";

    public string InteractionPrompt => _interactionPrompt;
    public bool CanInteract => _canInteract;

    void Start()
    {
        Debug.Log("Пациент создан! Можно взаимодействовать: {CanInteract}");
    }

    public void Interact()
    {
        Debug.Log("Метод Interact() вызван!");
        Debug.Log("Начинаем осморт пациента");
        //...
        LoadInspectionScene();
    }
    private void LoadInspectionScene()
    {
        if (!string.IsNullOrEmpty(_inspectionSceneName))
        {
            Debug.Log($"Загружаем сцену осмотра: {_inspectionSceneName}");
            SceneManager.LoadScene(_inspectionSceneName);
        }
        else
        {
            Debug.LogError("Название сцены осмотра не указано!");
        }
    }
    public void SetInteractable(bool canInteract)
    { 
     _canInteract = canInteract;  
    }

    
}
