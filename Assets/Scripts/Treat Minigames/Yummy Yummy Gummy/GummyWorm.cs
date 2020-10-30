using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GummyWorm : MonoBehaviour
{
    public bool flyToMouth;
    public Transform endTranform;

    YummyYummyGummy gummyManager;

    // Start is called before the first frame update
    void Start()
    {
        gummyManager = FindObjectOfType<YummyYummyGummy>();
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
                flyToMouth = false;
                gummyManager.isEating = false;

                Destroy(gameObject);
            }
        }
    }
}
