using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarBehavior : MonoBehaviour
{
    private bool inCollision = false;
    private bool pressedButton = false;

    private void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (inCollision && Input.GetKeyDown(KeyCode.Space))
        {
            pressedButton = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pressedButton = false;
        inCollision = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (pressedButton) ControllerCircleBehavior.score++;
        else ControllerCircleBehavior.numLives--;

        inCollision = false;
        pressedButton = false;
    }
}
