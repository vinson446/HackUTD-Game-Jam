using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOLOWCAR : MonoBehaviour
{
    public Transform car;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = car.position + offset;
    }
}
