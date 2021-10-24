using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointBehaviour : MonoBehaviour
{
    public Vector2 initialPosition;
    public Vector2 deltas = new Vector2(15, 15);
    public int maxHealth = 4;
    
    private int health;

    // Start is called before the first frame update
    void Awake()
    {
        respawn();
        GetComponent<Rigidbody2D>().freezeRotation = true;
        transform.position = new Vector3(initialPosition.x, initialPosition.y, transform.position.z);
    }

    void respawn()
    {
        Vector3 new_pos = transform.position;
        new_pos.x = (initialPosition.x + Random.Range(-deltas.x, deltas.x));
        new_pos.y = (initialPosition.y + Random.Range(-deltas.y, deltas.y));
        transform.position = new_pos;

        Color color = GetComponent<Renderer>().material.color;
        color.a = 1;
        GetComponent<Renderer>().material.color = color;

        health = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name != Data.PLAYER_PROJECTILE_NAME)
        {
            return;
        }

        health -= (collision.gameObject.GetComponent<PlayerProjectileBehaviour>().damage);

        if (health <= 0)
        {
            respawn();
            return;
        }

        Color color = GetComponent<Renderer>().material.color;
        color.a = GetComponent<Renderer>().material.color.a - 0.25f;
        GetComponent<Renderer>().material.color = color;
    }
}
