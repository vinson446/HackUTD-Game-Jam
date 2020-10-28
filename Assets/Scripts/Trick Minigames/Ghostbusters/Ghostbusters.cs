using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ghostbusters : MonoBehaviour
{
    [Header("Game Settings")]
    public int numberOfGhostsToSpawn;
    public float spawnRate;
    public int findColor;
    public int[] ghostColors;

    [Header("References")]
    public GameObject[] ghosts;
    public Transform[] spawnPosLeft;
    public Transform[] spawnPosRight;

    [Header("UI")]
    public GameObject introPanel;
    public TextMeshProUGUI introText;
    public GameObject controlText;
    public TextMeshProUGUI endEndText;

    public GameObject guessPanel;
    public TMP_InputField inputField;
    public TextMeshProUGUI endText;
    public GameObject levelButton;
    public GameObject menuButton;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        Intro();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Intro()
    {
        findColor = Random.Range(0, 5);
        switch(findColor)
        {
            case 0:
                introText.text = "As a fresh member of the Ghostbusters squad, headquarters has given you your first thrill-seeking, action-packed mission..." +
                    "counting ghosts in an abandoned mansion.\n\nAre you able to count all the RED ghosts?";
                break;
            case 1:
                introText.text = "As a fresh member of the Ghostbusters squad, headquarters has given you your first thrill-seeking, action-packed mission..." +
    "counting ghosts in an abandoned mansion.\n\nAre you able to count all the BLUE ghosts?";
                break;
            case 2:
                introText.text = "As a fresh member of the Ghostbusters squad, headquarters has given you your first thrill-seeking, action-packed mission..." +
    "counting ghosts in an abandoned mansion.\n\nAre you able to count all the GREEN ghosts?";
                break;
            case 3:
                introText.text = "As a fresh member of the Ghostbusters squad, headquarters has given you your first thrill-seeking, action-packed mission..." +
    "counting ghosts in an abandoned mansion.\n\nAre you able to count all the YELLOW ghosts?";
                break;
            case 4:
                introText.text = "As a fresh member of the Ghostbusters squad, headquarters has given you your first thrill-seeking, action-packed mission..." +
    "counting ghosts in an abandoned mansion.\n\nAre you able to count all the PURPLE ghosts?";
                break;
        }
    }

    public void Continue()
    {
        introPanel.SetActive(false);
        StartSpawningGhosts();
    }

    void StartSpawningGhosts()
    {
        if (gameManager.trickDifficulty >= 50)
        {
            numberOfGhostsToSpawn = Random.Range(200, 400);
            spawnRate = 0.1f;
        }
        else if (gameManager.trickDifficulty >= 15)
        {
            numberOfGhostsToSpawn = Random.Range(100, 200);
            spawnRate = 0.15f;
        }
        else if (gameManager.trickDifficulty >= 0)
        {
            numberOfGhostsToSpawn = Random.Range(50, 100);
            spawnRate = 0.2f;
        }

        StartCoroutine(SpawnGhostCoroutine());
    }

    IEnumerator SpawnGhostCoroutine()
    {
        int numGhosts = 0;

        while (numGhosts < numberOfGhostsToSpawn)
        {
            int colorIndex = Random.Range(0, 5);
            int leftRight = Random.Range(0, 2);
            Vector3 spawn = Vector3.zero;

            // left
            if (leftRight == 0)
            {
                float spawnPosX = Random.Range(spawnPosLeft[0].position.x, spawnPosLeft[1].position.x);
                float spawnPosY = Random.Range(spawnPosLeft[0].position.y, spawnPosLeft[1].position.y);
                float spawnPosZ = Random.Range(spawnPosLeft[0].position.z, spawnPosLeft[1].position.z);
                spawn = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
            }
            else
            {
                float spawnPosX = Random.Range(spawnPosRight[0].position.x, spawnPosRight[1].position.x);
                float spawnPosY = Random.Range(spawnPosRight[0].position.y, spawnPosRight[1].position.y);
                float spawnPosZ = Random.Range(spawnPosRight[0].position.z, spawnPosRight[1].position.z);
                spawn = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
            }

            GameObject ghost = Instantiate(ghosts[colorIndex], spawn, transform.rotation);
            
            if (leftRight == 0)
            {
                ghost.GetComponent<ConstantForce>().force = new Vector3(Random.Range(5, 15), 0, 0);
            }
            else
            {
                ghost.GetComponent<ConstantForce>().force = new Vector3(Random.Range(-5, -15), 0, 0);
            }

            ghostColors[colorIndex] += 1;
            numGhosts += 1;

            yield return new WaitForSeconds(spawnRate);
        }

        yield return new WaitForSeconds(3);

        GuessNumber();
    }

    void GuessNumber()
    {
        switch (findColor)
        {
            case 0:
                endText.text = "How many RED ghosts were there?";
                break;
            case 1:
                endText.text = "How many BLUE ghosts were there?";
                break;
            case 2:
                endText.text = "How many GREEN ghosts were there?";
                break;
            case 3:
                endText.text = "How many YELLOW ghosts were there?";
                break;
            case 4:
                endText.text = "How many PURPLE ghosts were there?";
                break;
        }

        guessPanel.SetActive(true);
    }

    public void CheckAnswer()
    {
        if (inputField.text == ghostColors[findColor].ToString())
        {
            Win();
        }
        else
        {
            Lose();
        }
    }

    public void Win()
    {
        inputField.gameObject.SetActive(false);
        gameManager.IncreaseTrickDifficulty();
        controlText.SetActive(false);
        endText.gameObject.SetActive(false);

        endEndText.gameObject.SetActive(true);
        endEndText.text = "Correct!";
        levelButton.SetActive(true);
    }

    public void Lose()
    {
        inputField.gameObject.SetActive(false);
        controlText.SetActive(false);
        endText.gameObject.SetActive(false);

        endEndText.gameObject.SetActive(true);
        endEndText.text = "Wrong...YOU LOSE";
        menuButton.SetActive(true);
    }
}
