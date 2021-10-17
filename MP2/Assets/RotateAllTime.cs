using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAllTime : MonoBehaviour
{

    public float rotationSpeed = 100;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * (rotationSpeed) * Time.deltaTime);
    }
}
