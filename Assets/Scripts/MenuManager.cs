using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void GoToLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
