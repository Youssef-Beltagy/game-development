using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public float rotationSpeed = 50;

    public Vector3 rotationCenter = new Vector3(0, 0, 0);
    public GameObject rotateAround = null;

    public bool randomizeRotationDirection = true;
    public bool ranomizeRotationSpeed = true;

    private bool rotateForward = true;

    private void Start()
    {
        if(randomizeRotationDirection) rotateForward = Random.value > 0.5;
        if(ranomizeRotationSpeed) rotationSpeed = rotationSpeed + rotationSpeed * Random.value;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) rotateForward = !rotateForward;

        if (rotateAround != null) rotationCenter = rotateAround.transform.position;

        float rotationAngle = rotationSpeed * Time.deltaTime;
        rotationAngle = rotateForward ? rotationAngle : -rotationAngle; 
        transform.RotateAround(rotationCenter, Vector3.forward, rotationAngle);
    }
}
