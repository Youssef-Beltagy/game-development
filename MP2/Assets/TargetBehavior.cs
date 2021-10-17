using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public GameObject rotateAround = null;
    // Start is called before the first frame update
    void Start()
    {
        transform.RotateAround(rotateAround.transform.position, Vector3.forward, Random.value * 360);
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.RotateAround(rotateAround.transform.position, Vector3.forward, 30 + Random.value * 330);
    }

}
