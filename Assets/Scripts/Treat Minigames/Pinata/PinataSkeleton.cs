using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PinataSkeleton : MonoBehaviour
{
    public Vector3 punchDir;
    public int power;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

    }

    public void HitPinata(float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
    {
        punchDir = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        rb.AddForce(punchDir * power);
    }
}
