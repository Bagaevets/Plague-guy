using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainScene() => SceneManager.LoadScene("MainScene");
    public void LoadInspectionScene() => SceneManager.LoadScene("InspectionScene");
    public void LoadBattleScene() => SceneManager.LoadScene("BattleScene");

}
