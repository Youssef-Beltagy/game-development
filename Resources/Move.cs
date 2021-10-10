using UnityEngine;

public class Move : MonoBehaviour
{

    public float speed = 0.05f; 
    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection*speed,yDirection*speed, 0);

        transform.position += moveDirection;

        if(Input.GetKeyDown(KeyCode.Q)) Application.Quit();
    }
}
