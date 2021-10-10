using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float multiplier = 2;

    // Update is called once per frame
    void FixedUpdate()
    {
        float h_val = Input.GetAxis("Horizontal");
        print(h_val);
        if (h_val > 0.5) transform.Rotate(Vector3.forward * (-multiplier));
        if (h_val < -0.5) transform.Rotate(Vector3.forward * (multiplier));
    }
}
