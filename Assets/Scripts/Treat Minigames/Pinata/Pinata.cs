using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Pinata : MonoBehaviour
{
    GameManager gameManager;

    [Header("Game")]
    public bool startGame = false;
    public float timer = 60;
    public int candiesNeeded;
    public int candies;
    public float currentTimer;

    public GameObject[] spawnTrans;

    [Header("UI")]
    public TextMeshProUGUI endText;
    public GameObject winButton;
    public GameObject loseButton;
    public GameObject introPanel;
    public GameObject gamePanel;
    public GameObject finishPanel;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI candiesText;
    public TextMeshProUGUI candiesNeededText;

    // Start is called before the first frame update
    void Start()
    {
        currentTimer = timer;

        gameManager = FindObjectOfType<GameManager>();
        SetupCandiesNeeded();
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            currentTimer -= Time.deltaTime;
            timerText.text = Mathf.RoundToInt(currentTimer).ToString();

            if (candies >= candiesNeeded)
            {
                GameFinished();
            }
            if (currentTimer <= 0)
            {
                GameFinished();
            }
        }
    }

    void SetupCandiesNeeded()
    {
        if (gameManager.treatDifficulty >= 50)
        {
            candiesNeeded = Random.Range(1000, 1200);
        }
        else if (gameManager.treatDifficulty >= 15)
        {
            candiesNeeded = Random.Range(800, 1000);
        }
        else if (gameManager.treatDifficulty >= 0)
        {
            candiesNeeded = Random.Range(600, 800);
        }
    }

    public void Continue()
    {
        introPanel.SetActive(false);
        gamePanel.SetActive(true);

        startGame = true;
        candiesNeededText.text = candiesNeeded.ToString();

        spawnTrans[Random.Range(0, 6)].SetActive(true);
    }

    void GameFinished()
    {
        startGame = false;

        for (int i = 0; i < spawnTrans.Length; i++)
        {
            spawnTrans[i].SetActive(false);
        }

        finishPanel.SetActive(true);
        if (candies >= candiesNeeded)
        {
            endText.text = "Good job!";
            winButton.SetActive(true);
        }
        else
        {
            endText.text = "Better luck next time...YOU LOSE";
            loseButton.SetActive(true);
        }
    }

    void Win()
    {
        print("Win");
        gameManager.IncreaseTreatDifficulty();
    }

    void Lose()
    {
        print("Lose");
    }

    public void GoToGameSelect()
    {
        SceneManager.LoadScene("GameSelect");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void IncreaseCandyCount()
    {
        candies += 1;
        candiesText.text = candies.ToString();
    }

    public void SetNewTarget()
    {
        spawnTrans[Random.Range(0, spawnTrans.Length - 1)].SetActive(true);
    }
}
