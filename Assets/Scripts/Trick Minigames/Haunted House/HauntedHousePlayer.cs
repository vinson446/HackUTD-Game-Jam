using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HauntedHousePlayer : MonoBehaviour
{
    public Transform[] doorPos;
    public float speed;

    public int index = -2;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (index == -2)
            {
                index = 1;
                return;
            }

            index -= 1;

            if (index - 1 < 0)
            {
                index = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (index == -2)
            {
                index = 2;
                return;
            }

            index += 1;

            if (index > doorPos.Length - 1)
            {
                index = doorPos.Length - 1;
            }
        }
        if (index != -2)
            transform.position = Vector3.Lerp(transform.position, new Vector3(doorPos[index].position.x, transform.position.y, transform.position.z), 0.2f);

        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
    }
}
