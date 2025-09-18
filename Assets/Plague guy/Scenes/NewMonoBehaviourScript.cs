using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    void Update()
    {
        // Проверка самого низкоуровневого ввода
        if (Input.anyKeyDown)
        {
            Debug.LogError("AnyKeyDown сработал! Значит, ввод жив.");
        }

        // Проверка конкретной клавиши
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.LogError("ПРОБЕЛ НАЖАТ!");
        }

        // Принудительный вывод значений осей каждые 60 кадров
        if (Time.frameCount % 60 == 0)
        {
            Debug.Log($"Frame: {Time.frameCount}. Input: ({Input.GetAxisRaw("Horizontal")}, {Input.GetAxisRaw("Vertical")})");
        }
    }
}
