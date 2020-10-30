using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HalloweenTrivia : MonoBehaviour
{
    [Header("Game Settings")]
    public int selectedQuestionIndex;
    public float timer = 10;
    bool startGame;

    [Header("UI Stuff")]
    public GameObject introPanel;
    public GameObject endPanel;
    public TextMeshProUGUI endText;
    public Button[] buttons;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI controlsText;

    // 5 questions per level (3 levels total)
    [Header("Questions")]
    public TextMeshProUGUI questionText;
    [TextArea(0, 100)]
    public string[] questionLevel1;
    [TextArea(0, 100)]
    public string[] questionLevel2;
    [TextArea(0, 100)]
    public string[] questionLevel3;

    // 4 answers per question
    [Header("Answers")]
    public TextMeshProUGUI[] answerText;
    [TextArea(0, 100)]
    public string[] correctAnswerLevel1;
    [TextArea(0, 100)]
    public string[] correctAnswerLevel2;
    [TextArea(0, 100)]
    public string[] correctAnswerLevel3;

    string[] answers = new string[4];

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                timerText.text = Mathf.Round(timer).ToString();
            }
            else
            {
                Lose();
            }
        }
    }

    public void Continue()
    {
        ShowQuestion();
    }

    void ShowQuestion()
    {
        startGame = true;
        introPanel.SetActive(false);
        controlsText.gameObject.SetActive(false);

        selectedQuestionIndex = Random.Range(0, 5);

        // level 3
        if (gameManager.trickDifficulty >= 50)
        {
            questionText.text = questionLevel3[selectedQuestionIndex];

            switch (selectedQuestionIndex)
            {
                // Are pumpkins fruits or vegetables?
                case 0:
                    // correct
                    answers[0] = "Fruit";
                    answers[1] = "Vegetable";
                    answers[2] = "Both";
                    answers[3] = "Neither";
                    RandomizeAnswerChoices();
                    break;

                // What is the phobia of Halloween called?
                case 1:
                    // correct
                    answers[0] = "Samhainophobia";
                    answers[1] = "Hallophopbia";
                    answers[2] = "Triskaphobia";
                    answers[3] = "Hellenologophobia";
                    RandomizeAnswerChoices();
                    break;

                // What is the rarest M&M color?
                case 2:
                    // correct
                    answers[0] = "Brown";
                    answers[1] = "Purple";
                    answers[2] = "Yellow";
                    answers[3] = "Green";
                    RandomizeAnswerChoices();
                    break;

                // In what century did the practice of trick-or-treating begin?
                case 3:
                    answers[0] = "16th century";
                    // correct
                    answers[1] = "20th century";
                    answers[2] = "14th century";
                    answers[3] = "17th century";
                    RandomizeAnswerChoices();
                    break;

                // Who made the first Jack-O'-Lantern?
                case 4:
                    // correct
                    answers[0] = "Jack";
                    answers[1] = "Jack-O";
                    answers[2] = "John";
                    answers[3] = "Joe";
                    RandomizeAnswerChoices();
                    break;
            }
        }
        // level 2
        else if (gameManager.trickDifficulty >= 15)
        {
            questionText.text = questionLevel2[selectedQuestionIndex];

            switch (selectedQuestionIndex)
            {
                // What is Dr. Frankenstein's first name?
                case 0:
                    // correct
                    answers[0] = "Victor";
                    answers[1] = "Boris";
                    answers[2] = "Francois";
                    answers[3] = "Bobby";
                    RandomizeAnswerChoices();
                    break;

                // What is a group of witches called?
                case 1:
                    answers[0] = "Convoy";
                    answers[1] = "Commune";
                    answers[2] = "Cauldron";
                    // correct
                    answers[3] = "Coven";
                    RandomizeAnswerChoices();
                    break;

                // In which modern-day country would you find Transylvania?
                case 2:
                    answers[0] = "Bulgaria";
                    answers[1] = "Hungary";
                    // correct
                    answers[2] = "Romania";
                    answers[3] = "Germany";
                    RandomizeAnswerChoices();
                    break;

                // Which mythical creature is the most vulnerable to silver bullets  
                case 3:
                    // correct
                    answers[0] = "Werewolf";
                    answers[1] = "Bogey-Man";
                    answers[2] = "Vampire";
                    answers[3] = "Zombie";
                    RandomizeAnswerChoices();
                    break;
                
                // Where do pumpkins grow?
                case 4:
                    // correct
                    answers[0] = "Vines";
                    answers[1] = "Trees";
                    answers[2] = "Bushes";
                    answers[3] = "Potatoes";
                    RandomizeAnswerChoices();
                    break;
            }
        }
        // level 1
        else if (gameManager.trickDifficulty >= 0)
        {
            questionText.text = questionLevel1[selectedQuestionIndex];

            switch (selectedQuestionIndex)
            {
                // What two colors are associated with Halloween?
                case 0:
                    // correct
                    answers[0] = "Orange and Black";
                    answers[1] = "Green and Black";
                    answers[2] = "Red and Green";
                    answers[3] = "Blue and Red";
                    RandomizeAnswerChoices();
                    break;
                
                // What vegetable scares away vampires?
                case 1:
                    // correct 
                    answers[0] = "Garlic";
                    answers[1] = "Ginger";
                    answers[2] = "Cucumber";
                    answers[3] = "Tomatoe";
                    RandomizeAnswerChoices();
                    break;

                // Which animal is associated with Halloween?
                case 2:
                    // correct
                    answers[0] = "Black cats";
                    answers[1] = "Green frogs";
                    answers[2] = "Brown bears";
                    answers[3] = "White rats";
                    RandomizeAnswerChoices();
                    break;

                // What are mummies...real mummies wrapped up in?
                case 3:
                    // correct
                    answers[0] = "Linen cloth";
                    answers[1] = "Sandpaper";
                    answers[2] = "Toilet paper";
                    answers[3] = "Crepe paper";
                    RandomizeAnswerChoices();
                    break;

                // What can Dracula transform himself into (physically)?
                case 4:
                    answers[0] = "A cat";
                    // correct
                    answers[1] = "A bat";
                    answers[2] = "A rat";
                    answers[3] = "A brat";
                    RandomizeAnswerChoices();
                    break;
            }
        }
    }

    void RandomizeAnswerChoices()
    {
        // fill up array
        for (int i = 0; i < answers.Length; i++)
        {
            answerText[i].text = answers[i];
        }

        // bad randomization
        for (int i = 0; i < answers.Length; i++)
        {
            int tmpIndex = Random.Range(0, 4);
            string tmpString = answerText[i].text;
            answerText[i].text = answerText[tmpIndex].text;
            answerText[tmpIndex].text = tmpString;
        }
    }

    // button
    public void CheckAnswer(int index)
    {
        if (gameManager.trickDifficulty >= 50)
        {
            if (correctAnswerLevel3[selectedQuestionIndex] == answerText[index].text)
            {
                Win();
            }
            else
            {
                Lose();
            }
        }
        else if (gameManager.trickDifficulty >= 15)
        {
            if (correctAnswerLevel2[selectedQuestionIndex] == answerText[index].text)
            {
                Win();
            }
            else
            {
                Lose();
            }
        }
        else if (gameManager.trickDifficulty >= 0)
        {
            if (correctAnswerLevel1[selectedQuestionIndex] == answerText[index].text)
            {
                Win();
            }
            else
            {
                Lose();
            }
        }
    }

    public void Win()
    {
        startGame = false;

        gameManager.IncreaseTrickDifficulty();

        endPanel.SetActive(true);
        endText.text = "Correct!";
        buttons[0].gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(true);
        buttons[2].gameObject.SetActive(false);
    }

    public void GoToGameSelect()
    {
        SceneManager.LoadScene("GameSelect");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Lose()
    {
        startGame = false;

        endPanel.SetActive(true);
        endText.text = "Wrong...YOU LOSE";
        buttons[0].gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(true);
    }
}
