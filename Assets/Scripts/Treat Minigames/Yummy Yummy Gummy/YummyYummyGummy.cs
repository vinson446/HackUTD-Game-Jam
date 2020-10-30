using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class YummyYummyGummy : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject endPanel;

    public bool gameIsIn;
    public bool momTurning;
    public GameObject mom;
    public int gummysPickedUp;
    public int numGummyWorms;
    public float turnTimer;
    public bool isEating;

    public float warningTime;

    [Header("Animation")]
    public Animator animator;

    [Header("UI")]
    public Image warningImage;
    public Sprite warningSprite;
    public Sprite angrySprite;

    public TextMeshProUGUI endText;
    public GameObject winButton;
    public GameObject loseButton;

    [Header("References")]
    public GameObject[] gummyWorms;
    public Transform[] spawnPos;
    public float y = -4;
    public float transformScale;

    public Transform startMomRot;
    public Transform endMomRot;

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
        if (gameIsIn)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    if (hit.transform.tag == "YummyGummy")
                    {
                        GummyWorm gummy = hit.transform.gameObject.GetComponent<GummyWorm>();
                        if (!gummy.flyToMouth)
                            gummysPickedUp++;
                        gummy.flyToMouth = true;
                        isEating = true;
                    }
                }
            }

            if (gummysPickedUp >= numGummyWorms)
            {
                Win();
            }
        }

        if (momTurning)
        {
            mom.transform.localRotation = Quaternion.Slerp(mom.transform.rotation, endMomRot.rotation, 0.2f);

            if (isEating)
                AngryMom();
        }
        else
        {
            mom.transform.localRotation = Quaternion.Slerp(mom.transform.rotation, startMomRot.rotation, 0.2f);
        }
    }

    void Intro()
    {
        SetTurnTimer();
    }

    public void Continue()
    {
        introPanel.SetActive(false);
        SpawnNumberOfGummyWorms();

        gameIsIn = true;

        StartCoroutine(Game());
    }

    void SpawnNumberOfGummyWorms()
    {
        if (gameManager.treatDifficulty >= 50)
        {
            numGummyWorms = Random.Range(75, 100);
        }
        else if (gameManager.treatDifficulty >= 15)
        {
            numGummyWorms = Random.Range(50, 75);
        }
        else if (gameManager.treatDifficulty >= 0)
        {
            numGummyWorms = Random.Range(25, 50);
        }

        for (int i = 0; i < numGummyWorms; i++)
        {
            float x = Random.Range(spawnPos[0].position.x, spawnPos[1].position.x);
            float z = Random.Range(spawnPos[0].position.z, spawnPos[1].position.z);
            GameObject obj = Instantiate(gummyWorms[Random.Range(0, gummyWorms.Length)], new Vector3(x, y, z), Quaternion.Euler(new Vector3(-90, Random.Range(-90, 90), Random.Range(-90, 90))));
            obj.transform.localScale = new Vector3(transformScale, transformScale, transformScale);
        }
    }

    void SetTurnTimer()
    {
        if (gameManager.treatDifficulty >= 50)
        {
            turnTimer = 3;
        }
        else if (gameManager.treatDifficulty >= 15)
        {
            turnTimer = 4;
        }
        else if (gameManager.treatDifficulty >= 0)
        {
            turnTimer = 5;
        }
    }

    IEnumerator Game()
    {
        while(gameIsIn)
        {
            yield return new WaitForSeconds(Random.Range(turnTimer, turnTimer + 2));

            StartCoroutine(TurnMom());
        }
    }

    IEnumerator TurnMom()
    {
        if (gameIsIn)
        {
            warningImage.gameObject.SetActive(true);
            warningImage.sprite = warningSprite;

            if (gameManager.treatDifficulty >= 50)
            {
                warningTime = 0.75f;
            }
            else if (gameManager.treatDifficulty >= 15)
            {
                warningTime = 1f;
            }
            else if (gameManager.treatDifficulty >= 0)
            {
                warningTime = 1.25f;
            }
        }

        yield return new WaitForSeconds(warningTime);

        warningImage.gameObject.SetActive(false);

        momTurning = true;
        animator.CrossFadeInFixedTime("turn", 0.2f);

        yield return new WaitForSeconds(1.25f);

        if (gameIsIn)
            IdleMom();
    }

    void IdleMom()
    {
        momTurning = false;
        animator.CrossFadeInFixedTime("idle", 0.2f);
        warningImage.gameObject.SetActive(false);
    }

    void AngryMom()
    {
        animator.CrossFadeInFixedTime("caught", 0.2f);

        warningImage.gameObject.SetActive(true);
        warningImage.sprite = angrySprite;

        StartCoroutine(Lose());
    }

    void Win()
    {
        gameIsIn = false;

        endPanel.SetActive(true);
        endText.fontSize = 90;
        endText.text = "Great work!";
        winButton.SetActive(true);
    }

    IEnumerator Lose()
    {
        gameIsIn = false;

        yield return new WaitForSeconds(2);

        animator.enabled = false;
        endPanel.SetActive(true);
        endText.text = "Oooh you are in troubleee...\nYOU LOSE";
        loseButton.SetActive(true);
    }
    
    public void GoToGameSelect()
    {
        SceneManager.LoadScene("GameSelect");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
