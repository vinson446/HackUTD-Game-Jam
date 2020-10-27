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
    public Image[] trickImages;
    public Image[] treatImages;

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
                gameManager.trickIndex = Random.Range(0, 4);
            }
        }
        // if TREAT was picked, dont change TRICK
        else
        {
            gameManager.previousTreatGameIndex = gameManager.treatIndex;
            while (gameManager.treatIndex == gameManager.previousTreatGameIndex)
            {
                gameManager.treatIndex = Random.Range(0, 4);
            }
        }
    }

    void ShowMiniGameFrontend()
    {
        trickText.text = trickSceneNames[gameManager.trickIndex];
        treatText.text = treatSceneNames[gameManager.treatIndex];

        trickImage = trickImages[gameManager.trickIndex];
        treatImage = treatImages[gameManager.treatIndex];
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
