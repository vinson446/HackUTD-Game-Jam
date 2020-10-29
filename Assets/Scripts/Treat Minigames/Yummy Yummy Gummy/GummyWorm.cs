using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GummyWorm : MonoBehaviour
{
    public bool flyToMouth;
    public Transform endTranform;

    // Start is called before the first frame update
    void Start()
    {
        endTranform = GameObject.FindGameObjectWithTag("mouth").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (flyToMouth)
        {
            if (Vector3.Distance(transform.position, endTranform.position) > 0.25f)
            {
                transform.position = Vector3.Slerp(transform.position, endTranform.position, 0.2f);
                transform.rotation = Quaternion.Slerp(transform.rotation, endTranform.rotation, 0.2f);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
