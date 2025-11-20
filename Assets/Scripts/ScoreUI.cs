using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text GameOverDisplay;
    public GameObject ScoreDisplayPanel;
    private Spaceship ship;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ship = FindFirstObjectByType<Spaceship>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ship != null)
        {
            GameOverDisplay.text = ship.Score.ToString();
        }
    }
}
