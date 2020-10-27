using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    HauntedHouse hauntedHouse;
    public int slot;

    private void Awake()
    {
        hauntedHouse = FindObjectOfType<HauntedHouse>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (hauntedHouse.CheckAnswer(slot))
            {
                hauntedHouse.ShowQuestion();
                hauntedHouse.TurnOnNextCam();
            }
        }
    }
}
