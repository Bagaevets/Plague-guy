using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour
{
    [Header("Current mode")]
    [SerializeField] private GameMode _currentMode = GameMode.Exploration;

    [Header("Scene Names")]
    [SerializeField] private string _mainSceneName = "MainScene";
    [SerializeField] private string _inspectionSceneName = "InspectionScene";
    [SerializeField] private string _battleSceneName = "BattleScene";

    // Событие для уведомления других систем о смене режима
    public static System.Action<GameMode> OnGameModeChanged;

    void Start()
    {
        // Инициализируем начальный режим
        SwitchToMode(_currentMode);
    }

    public void SwitchToMode(GameMode newMode) //Метод переключения режимов
    {
        _currentMode = newMode;
        
        OnGameModeChanged?.Invoke(newMode);

        Debug.Log($"Режим изменен на :{newMode}");
        
        LoadSceneForMode(newMode);
    }

    private void LoadSceneForMode(GameMode mode)
    {
        switch (mode)
        {
            case GameMode.Exploration:
                SceneManager.LoadScene(_mainSceneName);
                break;

            case GameMode.Inspection:
                SceneManager.LoadScene(_inspectionSceneName);
                break;

            case GameMode.Battle:
                SceneManager.LoadScene(_battleSceneName);
                break;
        }
    }

    public void SwitchToExploration() => SwitchToMode(GameMode.Exploration);
    public void SwitchToInspection() => SwitchToMode(GameMode.Inspection);
    public void SwitchToBattle() => SwitchToMode(GameMode.Battle);
}



