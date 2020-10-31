using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PinataStick : MonoBehaviour
{
    public Transform pinata;
    public Transform spawn;
    public bool canSmackAgain = true;

    float x1;
    float x2;
    float y1;
    float y2;
    float z1;
    float z2;

    public GameObject[] candiesToSpawn;
    Pinata pinataManager;

    public float power;

    // Start is called before the first frame update
    void Start()
    {
        pinataManager = FindObjectOfType<Pinata>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canSmackAgain && pinataManager.startGame)
        {
            // left side
            if (Input.mousePosition.x > Screen.width * 7 / 8)
            {
                z1 = 75;
                z2 = 90;
            }
            else if (Input.mousePosition.x > Screen.width * 3 / 4)
            {
                z1 = 50;
                z2 = 75;
            }
            else if (Input.mousePosition.x > Screen.width * 5 / 8)
            {
                z1 = 35;
                z2 = 50;
            }
            else if (Input.mousePosition.x > Screen.width / 2)
            {
                z1 = 10;
                z2 = 35;
            }
            else if (Input.mousePosition.x > Screen.width * 3 / 8)
            {
                z1 = -10;
                z2 = -35;
            }
            else if (Input.mousePosition.x > Screen.width / 4)
            {
                z1 = -35;
                z2 = -50;
            }
            else if (Input.mousePosition.x > Screen.width / 8)
            {
                z1 = -50;
                z2 = -75;
            }
            else
            {
                z1 = -75;
                z2 = -90;
            }

            StartCoroutine(Smack());
        }
    }
    
    IEnumerator Smack()
    {
        canSmackAgain = false;
        transform.DOMove(pinata.position, 0.1f);

        transform.DORotate(new Vector3(Random.Range(-90, 90), Random.Range(-90, 90), Random.Range(z1, z2)), 0.1f);

        yield return new WaitForSeconds(0.1f);

        transform.DOMove(spawn.position, 0.1f);

        yield return new WaitForSeconds(0.1f);

        canSmackAgain = true;
        transform.DORotate(new Vector3(0, 0, 0), 0.1f);
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PinataSkeleton>() != null)
        {
            other.GetComponentInParent<PinataSkeleton>().HitPinata(x1, x2, y1, y2, z1, z2);
        }
    }
    */

    private void OnCollisionEnter(Collision collision)
    {
        Collider myColl = collision.contacts[0].otherCollider;

        if (myColl.gameObject.tag == "Target")
        {
            myColl.gameObject.SetActive(false);
            pinataManager.SetNewTarget();

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            // spawn candies
            for (int i = 0; i < Random.Range(10, 15); i++)
            {
                GameObject candy = Instantiate(candiesToSpawn[Random.Range(0, candiesToSpawn.Length)], pos, rot);
                candy.GetComponentInChildren<Rigidbody>().AddForce(new Vector3(Random.Range(-90, 90), Random.Range(-90, 90), Random.Range(-90, 90)) * power);
                pinataManager.IncreaseCandyCount();
            }
        }
        else if (collision.gameObject.GetComponent<PinataSkeleton>() != null)
        {
            PinataSkeleton pinata = collision.gameObject.GetComponent<PinataSkeleton>();

            if (pinata != null)
            {
                ContactPoint contact = collision.contacts[0];
                Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
                Vector3 pos = contact.point;

                // spawn candies
                for (int i = 0; i < Random.Range(1, 5); i++)
                {
                    GameObject candy = Instantiate(candiesToSpawn[Random.Range(0, candiesToSpawn.Length)], pos, rot);
                    candy.GetComponentInChildren<Rigidbody>().AddForce(new Vector3(Random.Range(-90, 90), Random.Range(-90, 90), Random.Range(-90, 90)) * power);
                    pinataManager.IncreaseCandyCount();
                }
            }
        }
    }
}
