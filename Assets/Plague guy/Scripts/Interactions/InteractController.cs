using System.Runtime.CompilerServices;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [Header("Interaction settings")]
    [SerializeField] private float _interactionRange = 2f;
    [SerializeField] private LayerMask _interactableLayer;
    [SerializeField] private KeyCode _interactionKey = KeyCode.E;
    
    [SerializeField] private GameObject _interactionUI;

    private IInteractable _currentInteractable;
    private bool _canInteract = false;

    private void Update()
    {
        FindInteractables();
        UpdateInteractionUI();
        HandleInteractionInput();
    }
    private void FindInteractables() // Поиск интерактивных объектов 
    { 
      _currentInteractable = null;
       _canInteract = false;

        // Поиск коллайдеров
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll
            (transform.position, //Бросает круг от позиции персонажа
            _interactionRange, // в каком радиусе
            _interactableLayer // На конкретные слои
            );
        Debug.Log($"Найдено объектов: {hitColliders.Length}");
        foreach (Collider2D collider in hitColliders) // Проверяет каждый коллайдер
        { 
          IInteractable interactable = collider.GetComponent<IInteractable>(); // Берется найденный колайдер и ищет на нем скрип с реализацие интерфейса
            Debug.Log($"Проверяем: {collider.name}, Interactable: {interactable != null}");
            if (interactable != null && interactable.CanInteract) // Есть ли интерфейс и можно ли взаимодействовать с ним (Зачем я проверяю два раза есть ли он)
            { 
              _currentInteractable = interactable;
                _canInteract = true;
                Debug.Log($"Можно взаимодействовать с: {collider.name}");
                break;
            }
        }
    }
    private void UpdateInteractionUI() //отображение подсказки 
    { 
      if (_interactionUI != null)
            _interactionUI.SetActive( _canInteract );
    }
    private void HandleInteractionInput()
    {
        if (_canInteract && Input.GetKeyDown(_interactionKey))
        {
            Debug.Log("Взаимодействие с: " + _currentInteractable.GetType().Name);
            _currentInteractable.Interact();
        }
    }
    private void OnDrawGizmos()
    {
        if (!enabled) return;

        Gizmos.color = _canInteract ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, _interactionRange);
    }
}
