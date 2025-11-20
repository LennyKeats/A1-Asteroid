using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text ScoreTextBox, HiScoreTextBox;
    public GameObject GameOverDisplay, CelebrateHiScore;
    private Spaceship ship;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

  public void Show(bool CelebrateHiScore)
    {
        ScoreTextBox.text = ship.Score.ToString();
        HiScoreTextBox.text = ship.GetHighScore().ToString();

        GameOverDisplay.SetActive(true);

    }

    public void Hide()
    {
        GameOverDisplay.SetActive(false);
    }

    void Start()
    {
        ship = FindFirstObjectByType<Spaceship>();
        Hide();
    }

   
    public void ClickPlay()
    {
        SceneManager.LoadScene("Title");
    }

    // Update is called once per frame
    void Update()
    {
        if (ship != null)
        { 
            ScoreTextBox.text = ship.Score.ToString();
        }
    }
}
