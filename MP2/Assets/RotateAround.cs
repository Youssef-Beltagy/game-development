using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject rotationCenter;
    public float rotationSpeed;
    private bool rotateForward;

    private void Start()
    {
        rotateForward = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) rotateForward = !rotateForward;


        float rotationAngle = rotationSpeed * Time.deltaTime;
        rotationAngle = rotateForward ? rotationAngle : -rotationAngle; 
        transform.RotateAround(rotationCenter.transform.position, Vector3.forward, rotationAngle);
    }
}
