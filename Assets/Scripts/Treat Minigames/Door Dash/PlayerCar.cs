using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    DoorDash doorDash;

    private void Start()
    {
        doorDash = FindObjectOfType<DoorDash>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Win")
        {
            doorDash.Win();
        }
        else
        {
            doorDash.Lose();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Win")
        {
            doorDash.Win();
            GetComponent<ConstantForce2D>().enabled = false;
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
        else
        {
            doorDash.Lose();
            GetComponent<ConstantForce2D>().enabled = false;
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}
