using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HauntedHouse : MonoBehaviour
{
    [Header("Settings")]
    public int correctAnswer;
    public int correctQuestionsAnswered;

    [Header("References")]
    public TextMeshProUGUI[] questionTexts;
    public TextMeshProUGUI[] answerTexts1;
    public TextMeshProUGUI[] answerTexts2;
    public TextMeshProUGUI[] answerTexts3;

    [Header("Camera")]
    [SerializeField] GameObject cam;
    [SerializeField] GameObject[] cams;
    public int currentCamIndex;

    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        ShowQuestion();
    }

    private void Update()
    {
        cam.transform.position = Vector3.Slerp(cam.transform.position, cams[currentCamIndex].transform.position, 0.2f);
    }

    public void ShowQuestion()
    {
        if (gameManager.trickDifficulty >= 50)
        {
            int num1 = Random.Range(0, 10);
            int num2 = Random.Range(0, 10);
            int num3 = Random.Range(0, 10);
            int num4 = Random.Range(0, 10);

            int sign = Random.Range(0, 6);
            switch (sign)
            {
                case 0:
                    questionTexts[correctQuestionsAnswered].text = num1.ToString() + " + " + num2.ToString() + " + " + num3.ToString() + " + " + num4.ToString() + " = ?";
                    correctAnswer = num1 + num2 + num3 + num4;
                    answerTexts1[0].text = correctAnswer.ToString();
                    answerTexts1[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts2[0].text = correctAnswer.ToString();
                    answerTexts2[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts3[0].text = correctAnswer.ToString();
                    answerTexts3[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    RandomizeAnswerChoices();
                    break;
                case 1:
                    questionTexts[correctQuestionsAnswered].text = num1.ToString() + " - " + num2.ToString() + " - " + num3.ToString() + " - " + num4.ToString() + " = ?";
                    correctAnswer = num1 - num2 - num3 - num4;
                    answerTexts1[0].text = correctAnswer.ToString();
                    answerTexts1[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts2[0].text = correctAnswer.ToString();
                    answerTexts2[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts3[0].text = correctAnswer.ToString();
                    answerTexts3[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    RandomizeAnswerChoices();
                    break;
                case 2:
                    questionTexts[correctQuestionsAnswered].text = num1.ToString() + " - " + num2.ToString() + " + " + num3.ToString() + " + " + num4.ToString() + " = ?";
                    correctAnswer = num1 - num2 + num3 + num4;
                    answerTexts1[0].text = correctAnswer.ToString();
                    answerTexts1[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts2[0].text = correctAnswer.ToString();
                    answerTexts2[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts3[0].text = correctAnswer.ToString();
                    answerTexts3[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    RandomizeAnswerChoices();
                    break;
                case 3:
                    questionTexts[correctQuestionsAnswered].text = num1.ToString() + " + " + num2.ToString() + " - " + num3.ToString() + " - " + num4.ToString() + " = ?";
                    correctAnswer = num1 + num2 - num3 - num4;
                    answerTexts1[0].text = correctAnswer.ToString();
                    answerTexts1[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts2[0].text = correctAnswer.ToString();
                    answerTexts2[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts3[0].text = correctAnswer.ToString();
                    answerTexts3[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    RandomizeAnswerChoices();
                    break;
                case 4:
                    questionTexts[correctQuestionsAnswered].text = num1.ToString() + " + " + num2.ToString() + " - " + num3.ToString() + " + " + num4.ToString() + " = ?";
                    correctAnswer = num1 + num2 - num3 + num4;
                    answerTexts1[0].text = correctAnswer.ToString();
                    answerTexts1[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts2[0].text = correctAnswer.ToString();
                    answerTexts2[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts3[0].text = correctAnswer.ToString();
                    answerTexts3[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    RandomizeAnswerChoices();
                    break;
                case 5:
                    questionTexts[correctQuestionsAnswered].text = num1.ToString() + " - " + num2.ToString() + " - " + num3.ToString() + " + " + num4.ToString() + " = ?";
                    correctAnswer = num1 - num2 - num3 + num4;
                    answerTexts1[0].text = correctAnswer.ToString();
                    answerTexts1[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts2[0].text = correctAnswer.ToString();
                    answerTexts2[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts3[0].text = correctAnswer.ToString();
                    answerTexts3[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    RandomizeAnswerChoices();
                    break;
            }
        }
        else if (gameManager.trickDifficulty >= 15)
        {
            int num1 = Random.Range(0, 10);
            int num2 = Random.Range(0, 10);
            int num3 = Random.Range(0, 10);

            int sign = Random.Range(0, 4);
            switch (sign)
            {
                case 0:
                    questionTexts[correctQuestionsAnswered].text = num1.ToString() + " + " + num2.ToString() + " + " + num3.ToString() + " = ?";
                    correctAnswer = num1 + num2 + num3;
                    answerTexts1[0].text = correctAnswer.ToString();
                    answerTexts1[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts2[0].text = correctAnswer.ToString();
                    answerTexts2[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts3[0].text = correctAnswer.ToString();
                    answerTexts3[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    RandomizeAnswerChoices();
                    break;
                case 1:
                    questionTexts[correctQuestionsAnswered].text = num1.ToString() + " - " + num2.ToString() + " - " + num3.ToString() + " = ?";
                    correctAnswer = num1 - num2 - num3;
                    answerTexts1[0].text = correctAnswer.ToString();
                    answerTexts1[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts2[0].text = correctAnswer.ToString();
                    answerTexts2[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts3[0].text = correctAnswer.ToString();
                    answerTexts3[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    RandomizeAnswerChoices();
                    break;
                case 2:
                    questionTexts[correctQuestionsAnswered].text = num1.ToString() + " - " + num2.ToString() + " + " + num3.ToString() + " = ?";
                    correctAnswer = num1 - num2 + num3;
                    answerTexts1[0].text = correctAnswer.ToString();
                    answerTexts1[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts2[0].text = correctAnswer.ToString();
                    answerTexts2[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts3[0].text = correctAnswer.ToString();
                    answerTexts3[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    RandomizeAnswerChoices();
                    break;
                case 3:
                    questionTexts[correctQuestionsAnswered].text = num1.ToString() + " + " + num2.ToString() + " - " + num3.ToString() + " = ?";
                    correctAnswer = num1 + num2 - num3;
                    answerTexts1[0].text = correctAnswer.ToString();
                    answerTexts1[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts2[0].text = correctAnswer.ToString();
                    answerTexts2[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts3[0].text = correctAnswer.ToString();
                    answerTexts3[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    RandomizeAnswerChoices();
                    break;
            }
        }
        else if (gameManager.trickDifficulty >= 0)
        {
            int num1 = Random.Range(0, 10);
            int num2 = Random.Range(0, 10);

            int sign = Random.Range(0, 2);
            switch (sign)
            {
                case 0:
                    questionTexts[correctQuestionsAnswered].text = num1.ToString() + " + " + num2.ToString() + " = ?";
                    correctAnswer = num1 + num2;
                    answerTexts1[0].text = correctAnswer.ToString();
                    answerTexts1[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts2[0].text = correctAnswer.ToString();
                    answerTexts2[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts3[0].text = correctAnswer.ToString();
                    answerTexts3[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    RandomizeAnswerChoices();
                    break;
                case 1:
                    questionTexts[correctQuestionsAnswered].text = num1.ToString() + " - " + num2.ToString() + " = ?";
                    correctAnswer = num1 - num2;
                    answerTexts1[0].text = correctAnswer.ToString();
                    answerTexts1[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts1[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts2[0].text = correctAnswer.ToString();
                    answerTexts2[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts2[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    answerTexts3[0].text = correctAnswer.ToString();
                    answerTexts3[1].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[2].text = (correctAnswer + Random.Range(-10, 10)).ToString();
                    answerTexts3[3].text = (correctAnswer + Random.Range(-10, 10)).ToString();

                    RandomizeAnswerChoices();
                    break;
            }
        }
    }

    void RandomizeAnswerChoices()
    {
        // bad randomization
        for (int i = 0; i < answerTexts1.Length; i++)
        {
            int tmpIndex = Random.Range(0, 4);

            string tmpString1 = answerTexts1[i].text;
            answerTexts1[i].text = answerTexts1[tmpIndex].text;
            answerTexts1[tmpIndex].text = tmpString1;

            string tmpString2 = answerTexts2[i].text;
            answerTexts2[i].text = answerTexts2[tmpIndex].text;
            answerTexts2[tmpIndex].text = tmpString2;

            string tmpString3 = answerTexts3[i].text;
            answerTexts3[i].text = answerTexts3[tmpIndex].text;
            answerTexts3[tmpIndex].text = tmpString3;
        }
    }

    // button
    public bool CheckAnswer(int index)
    {
        if (answerTexts1[index].text == correctAnswer.ToString())
        {
            correctQuestionsAnswered += 1;
            if (correctQuestionsAnswered == 3)
            {
                Win();
            }

            return true;
        }
        else
        {
            Lose();
            return false;
        }
    }

    public void Win()
    {
        print("Win");
        gameManager.IncreaseTrickDifficulty();
        SceneManager.LoadScene("Haunted House");
    }

    public void Lose()
    {
        print("Lose");
        SceneManager.LoadScene("Haunted House");
    }

    public void TurnOnNextCam()
    {
        currentCamIndex += 1;
        if (currentCamIndex < cams.Length)
        {
            //cam.transform.position = Vector3.Slerp(cam.transform.position, cams[currentCamIndex].transform.position, 0.2f);
        }
    }
}
