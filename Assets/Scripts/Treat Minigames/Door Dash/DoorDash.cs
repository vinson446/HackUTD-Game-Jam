using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DoorDash : MonoBehaviour
{
    GameManager gameManager;

    bool startGame;
    public GameObject player;
    public float[] yPos;
    int currentIndex;

    public GameObject[] level;
    public GameObject[] win;

    [Header("Obstacles")]
    public GameObject[] obstacles;
    public Transform botLeft1;
    public Transform topRight1;
    public Transform botLeft2;
    public Transform topRight2;
    public Transform botLeft3;
    public Transform topRight3;

    [Header("UI")]
    public GameObject introPanel;
    public GameObject endPanel;
    public GameObject winButton;
    public GameObject loseButton;

    public TextMeshProUGUI endText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        SetupLevel();
        SetupObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            Movement();
        }
    }

    void Intro()
    {

    }

    public void Continue()
    {
        startGame = true;
        introPanel.SetActive(false);
        StartCoroutine(StepOnGas());
    }

    IEnumerator StepOnGas()
    {
        player.GetComponent<ConstantForce2D>().enabled = true;
        player.GetComponent<ConstantForce2D>().force = new Vector2(10, 0);

        yield return new WaitForSeconds(1);

        player.GetComponent<ConstantForce2D>().force = new Vector2(0f, 0);
    }

    void SetupLevel()
    {

    }

    void SetupObstacles()
    {
        if (gameManager.treatDifficulty >= 50)
        {
            for (int i = 0; i < Random.Range(40, 50); i++)
            {
                float x = Random.Range(botLeft1.position.x, topRight1.position.x);
                float y = Random.Range(botLeft1.position.y, topRight1.position.y);
                GameObject obj = Instantiate(obstacles[Random.Range(0, obstacles.Length)], new Vector3(x, y, 0), Quaternion.identity);

                obj.GetComponent<SpriteRenderer>().sortingOrder = 10;

                int flip = Random.Range(0, 2);
                if (flip == 0)
                    obj.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else if (gameManager.treatDifficulty >= 15)
        {
            for (int i = 0; i < Random.Range(30, 40); i++)
            {
                float x = Random.Range(botLeft1.position.x, topRight1.position.x);
                float y = Random.Range(botLeft1.position.y, topRight1.position.y);
                GameObject obj = Instantiate(obstacles[Random.Range(0, obstacles.Length)], new Vector3(x, y, 0), Quaternion.identity);

                obj.GetComponent<SpriteRenderer>().sortingOrder = 10;

                int flip = Random.Range(0, 2);
                if (flip == 0)
                    obj.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else if (gameManager.treatDifficulty >= 0)
        {
            for (int i = 0; i < Random.Range(20, 30); i++)
            {
                float x = Random.Range(botLeft1.position.x, topRight1.position.x);
                float y = Random.Range(botLeft1.position.y, topRight1.position.y);
                GameObject obj = Instantiate(obstacles[Random.Range(0, obstacles.Length)], new Vector3(x, y, 0), Quaternion.identity);

                obj.GetComponent<SpriteRenderer>().sortingOrder = 10;

                int flip = Random.Range(0, 2);
                if (flip == 0)
                    obj.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentIndex + 1 <= yPos.Length - 1)
            {
                currentIndex += 1;
                player.transform.position = new Vector3(player.transform.position.x, yPos[currentIndex],
                    player.transform.position.z);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentIndex -1 >= 0)
            {
                currentIndex -= 1;
                player.transform.position = new Vector3(player.transform.position.x, yPos[currentIndex],
                    player.transform.position.z);
            }
        }
    }

    public void Lose()
    {
        startGame = false;
        endPanel.SetActive(true);
        endText.text = "Welp, there's always next year for those kids right...YOU LOSE";

        loseButton.SetActive(true);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToGameSelect()
    {
        SceneManager.LoadScene("GameSelect");
    }

    public void Win()
    {
        startGame = false;
        winButton.SetActive(true);
        endPanel.SetActive(true);
        endText.text = "You made it just in the nick of time. The customer thanks you considerably for your efforts.";
        gameManager.IncreaseTreatDifficulty();
    }
}
