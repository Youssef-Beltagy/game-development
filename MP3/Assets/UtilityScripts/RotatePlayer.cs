using UnityEngine;
public class RotatePlayer: MonoBehaviour
{
    public float rotationSpeed = 45;

    // Update is called once per frame
    void Update()
    {
        bool left = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        if (right && !left) transform.Rotate(Vector3.forward * (-rotationSpeed) * Time.deltaTime);
        if (left && !right) transform.Rotate(Vector3.forward * ( rotationSpeed) * Time.deltaTime);
    }
}
