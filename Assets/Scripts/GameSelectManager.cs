using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameSelectManager : MonoBehaviour
{
    [Header("References")]
    public Image trickImage;
    public Image treatImage;
    public TextMeshProUGUI trickText;
    public TextMeshProUGUI treatText;

    [Header("Game Select Settings")]
    public string[] trickSceneNames;
    public string[] treatSceneNames;
    public Sprite[] trickImages;
    public Sprite[] treatImages;

    public Image trick;
    public Image treat;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();    
    }

    private void Start()
    {
        SelectAMiniGameBackend();
        ShowMiniGameFrontend();
    }

    void SelectAMiniGameBackend()
    {
        // if TRICK was picked, dont change TREAT
        if (gameManager.trickIndex == gameManager.currentTrickGameIndex)
        {
            gameManager.previousTrickGameIndex = gameManager.trickIndex;
            while (gameManager.trickIndex == gameManager.previousTrickGameIndex)
            {
                gameManager.trickIndex = Random.Range(0, 3);
            }
        }
        // if TREAT was picked, dont change TRICK
        else
        {
            gameManager.previousTreatGameIndex = gameManager.treatIndex;
            while (gameManager.treatIndex == gameManager.previousTreatGameIndex)
            {
                gameManager.treatIndex = Random.Range(0, 3);
            }
        }
    }

    void ShowMiniGameFrontend()
    {
        trickText.text = "Trick Score: " + gameManager.trickDifficulty.ToString();
        treatText.text = "Treat Score: " + gameManager.treatDifficulty.ToString();

        trickImage.sprite = trickImages[gameManager.trickIndex];
        treatImage.sprite = treatImages[gameManager.treatIndex];
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // buttons
    public void GoToTrickGame()
    {
        gameManager.currentTrickGameIndex = gameManager.trickIndex;

        SceneManager.LoadScene(trickSceneNames[gameManager.currentTrickGameIndex]);
    }

    public void GoToTreatGame()
    {
        gameManager.currentTreatGameIndex = gameManager.treatIndex;

        SceneManager.LoadScene(treatSceneNames[gameManager.currentTreatGameIndex]);
    }
}
