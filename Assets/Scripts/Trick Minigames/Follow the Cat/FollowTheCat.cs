using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class FollowTheCat : MonoBehaviour
{
    [Header("Game")]
    public int correctHat;
    public int currentSwaps = 0;
    public int totalSwaps;

    public int yStartPos;
    public int ySwapPos;

    [Header("References")]
    public GameObject cat;
    public Transform catParent;
    public GameObject[] hats;
    public Transform[] level1HatTransforms;
    public Transform[] level2HatTransforms;
    public Transform[] level3HatTransforms;

    [Header("UI References")]
    public GameObject[] hatButtons;
    public GameObject introPanel;
    public TextMeshProUGUI endText;
    public GameObject[] buttons;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Intro()
    {
        introPanel.SetActive(true);
    }

    public void Continue()
    {
        introPanel.SetActive(false);

        SetHatPosAtStart();
        SetCatPosAtStart();

        SetTotalNumberOfSwaps();

        StartCoroutine(SwapCoroutine());
    }

    void SetHatPosAtStart()
    {
        if (gameManager.trickDifficulty >= 50)
        {
            for (int i = 0; i < hats.Length; i++)
            {
                if (i < level3HatTransforms.Length)
                {
                    hats[i].transform.position = level3HatTransforms[i].position;
                }
            }
        }
        else if (gameManager.trickDifficulty >= 15)
        {
            for (int i = 0; i < hats.Length; i++)
            {
                if (i < level2HatTransforms.Length)
                {
                    hats[i].transform.position = level2HatTransforms[i].position;
                }
            }
        }
        else if (gameManager.trickDifficulty >= 0)
        {
            for (int i = 0; i < hats.Length; i++)
            {
                if (i < level1HatTransforms.Length)
                {
                    hats[i].transform.position = level1HatTransforms[i].position;
                }
            }
        }
    }
    
    void SetCatPosAtStart()
    {
        if (gameManager.trickDifficulty >= 50)
        {
            correctHat = Random.Range(0, level3HatTransforms.Length);

            cat.transform.position = new Vector3
                (hats[correctHat].transform.position.x, cat.transform.position.y, hats[correctHat].transform.position.z);
        }
        else if (gameManager.trickDifficulty >= 15)
        {
            correctHat = Random.Range(0, level2HatTransforms.Length);

            cat.transform.position = new Vector3
                (hats[correctHat].transform.position.x, cat.transform.position.y, hats[correctHat].transform.position.z);
        }
        else if (gameManager.trickDifficulty >= 0)
        {
            correctHat = Random.Range(0, level1HatTransforms.Length);

            cat.transform.position = new Vector3
                (hats[correctHat].transform.position.x, cat.transform.position.y, hats[correctHat].transform.position.z);
        }

        cat.SetActive(true);
    }

    void SetTotalNumberOfSwaps()
    {
        if (gameManager.currentTrickGameIndex >= 50)
        {
            totalSwaps = Random.Range(15, 20);
        }
        else if (gameManager.currentTrickGameIndex >= 15)
        {
            totalSwaps = Random.Range(10, 15);
        }
        else if (gameManager.currentTrickGameIndex >= 0)
        {
            totalSwaps = Random.Range(5, 10);
        }
    }

    IEnumerator SwapCoroutine()
    {
        // spawn hats above 
        if (gameManager.trickDifficulty >= 50)
        {
            for (int i = 0; i < level3HatTransforms.Length; i++)
            {
                hats[i].transform.DOLocalMoveY(yStartPos, 0);

                hats[i].SetActive(true);
            }
        }
        else if (gameManager.trickDifficulty >= 15)
        {
            for (int i = 0; i < level2HatTransforms.Length; i++)
            {
                hats[i].transform.DOLocalMoveY(yStartPos, 0);

                hats[i].SetActive(true);
            }
        }
        else if (gameManager.trickDifficulty >= 0)
        {
            for (int i = 0; i < level1HatTransforms.Length; i++)
            {
                hats[i].transform.DOLocalMoveY(yStartPos, 0);

                hats[i].SetActive(true);
            }
        }

        yield return new WaitForSeconds(1);

        // bring hats down on cat
        for (int i = 0; i < hats.Length; i++)
        {
            hats[i].transform.DOLocalMoveY(ySwapPos, 0.5f);
        }

        yield return new WaitForSeconds(0.5f);

        cat.transform.parent = hats[correctHat].transform;
        cat.GetComponent<Image>().enabled = false;

        // swap hats
        while (currentSwaps < totalSwaps)
        {
            int index1 = 0;
            int index2 = 0;

            // swap hats
            if (gameManager.trickDifficulty >= 50)
            {
                while (index1 == index2)
                {
                    index1 = Random.Range(0, level3HatTransforms.Length);
                    index2 = Random.Range(0, level3HatTransforms.Length);
                }
            }
            else if (gameManager.trickDifficulty >= 15)
            {
                while (index1 == index2)
                {
                    index1 = Random.Range(0, level2HatTransforms.Length);
                    index2 = Random.Range(0, level2HatTransforms.Length);
                }
            }
            else if (gameManager.trickDifficulty >= 0)
            {
                while (index1 == index2)
                {
                    index1 = Random.Range(0, level1HatTransforms.Length);
                    index2 = Random.Range(0, level1HatTransforms.Length);
                }
            }

            Transform tmp = hats[index1].transform;
            hats[index1].transform.DOLocalMove(hats[index2].transform.localPosition, 0.5f);
            hats[index2].transform.DOLocalMove(tmp.localPosition, 0.5f);

            currentSwaps += 1;
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        }

        foreach(GameObject obj in hatButtons)
        {
            obj.SetActive(true);
        }
    }

    public void CheckAnswer(int index)
    {
        // unparent cat
        cat.transform.parent = catParent;
        cat.GetComponent<Image>().enabled = true;

        // take off hats
        for (int i = 0; i < hats.Length; i++)
            hats[i].gameObject.SetActive(false);

        // check answer
        if (gameManager.trickDifficulty >= 50)
        {
            // win
            if (index == correctHat)
            {
                Win();
            }
            // lose
            else
            {
                Lose();
            }
        }
        else if (gameManager.trickDifficulty >= 15)
        {
            // win
            if (index == correctHat)
            {
                Win();
            }
            // lose
            else
            {
                Lose();
            }
        }
        else if (gameManager.trickDifficulty >= 0)
        {
            // win
            if (index == correctHat)
            {
                Win();
            }
            // lose
            else
            {
                Lose();
            }
        }
    }

    public void Win()
    {
        print("Win");
        gameManager.IncreaseTrickDifficulty();

        introPanel.SetActive(true);
        endText.text = "Correct!";

        buttons[0].SetActive(false);
        buttons[1].SetActive(true);
        buttons[2].SetActive(false);
    }

    public void Lose()
    {
        introPanel.SetActive(true);
        endText.text = "Wrong...YOU LOSE";

        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(true);
    }
}
