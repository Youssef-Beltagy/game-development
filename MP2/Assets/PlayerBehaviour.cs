using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private enum PlayerMode
    {
        mouse = 0,
        keyboard = 1
    }

    public Camera mainCamera;

    float speed;

    private PlayerMode player_mode;

    private Rigidbody2D rigid_body;

    void Start()
    {
        player_mode = PlayerMode.mouse;
        rigid_body = GetComponent<Rigidbody2D>();
        rigid_body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerMode();
        if (player_mode == PlayerMode.mouse) setPositionToCursor();
        if (player_mode == PlayerMode.keyboard) updateVelocity();
    }


    private void UpdatePlayerMode()
    {
        if (!Input.GetKeyDown(KeyCode.M)) return;

        if (player_mode == PlayerMode.mouse)
        {
            speed = 20;
            player_mode = PlayerMode.keyboard;
        }
        else
        {
            speed = 0;
            rigid_body.velocity = new Vector2(0, 0);
            player_mode = PlayerMode.mouse;
        }

    }

    private void setPositionToCursor()
    {
        Vector3 new_position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        new_position.z = transform.position.z;
        transform.position = new_position;
    }

    private void updateVelocity()
    {
        speed += Input.GetAxis("Vertical") * 0.2f;
        rigid_body.velocity = transform.up * (speed / transform.up.magnitude);
    }
}
