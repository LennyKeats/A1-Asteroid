using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ClickPlay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    // Update is called once per frame
    public void ClickQuit()
    {
        Application.Quit();
    }
}
