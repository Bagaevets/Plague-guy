using System.Globalization;
using UnityEngine;

public class InteractablePatient : MonoBehaviour, IInteractable
{
    [Header("Patient settings")]
    [SerializeField] private string _interactionPrompt = "Осмотреть пациента";
    [SerializeField] private bool _canInteract = true;

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
    }

    public void SetInteractable(bool canInteract)
    { 
     _canInteract = canInteract;  
    }

    
}
