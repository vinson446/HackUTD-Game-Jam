using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Save Info- Records")]
    public int score;
    public int highScore;
    public int trickDifficulty;
    public int treatDifficulty;

    // records of last/current game played
    [Header("Save Info- Indexes")]
    public int trickIndex = 0;
    public int treatIndex = 0;

    public int previousTrickGameIndex;
    public int currentTrickGameIndex;
    public int previousTreatGameIndex;
    public int currentTreatGameIndex;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // TODO- REMOVE
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SceneManager.LoadScene("GameSelect");
        }
    }

    public void IncreaseScore(bool trickGame)
    {
        if (trickGame)
            score += trickDifficulty;
        else
            score += treatDifficulty;
    }

    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }

    public void IncreaseTrickDifficulty()
    {
        trickDifficulty += 1;

        IncreaseScore(true);
    }

    public void IncreaseTreatDifficulty()
    {
        treatDifficulty += 1;

        IncreaseScore(false);
    }
}
