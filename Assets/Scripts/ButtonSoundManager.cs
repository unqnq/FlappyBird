using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundManager : MonoBehaviour
{
    private void Start()
    {
        Button[] buttons = FindObjectsOfType<Button>(); // Знайдемо всі кнопки на сцені

        // Додаємо слухачів до кожної кнопки
        foreach (var button in buttons)
        {
            button.onClick.AddListener(PlayClickSound);  // Додаємо метод для кожної кнопки
        }
    }

    public void PlayClickSound()
    {
           AudioManager.Instance.PlayClick();
    }
}
