using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    public int health = 4;
    public bool changeColor = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == Data.PLAYER_NAME)
        {
            destroyAndRespwan(collision.gameObject);
            return;
        }
        
        
        if (collision.gameObject.name == Data.EGG_NAME){
            health -= (collision.gameObject.GetComponent<EggBehaviour>().damage);
        }

        if (health <= 0)
        {
            destroyAndRespwan(collision.gameObject);
            return;
        }

        Color color;
        if (changeColor) color = Data.colors[2 - health];
        else color = GetComponent<Renderer>().material.color;

        color.a = GetComponent<Renderer>().material.color.a * 0.8f;

        GetComponent<Renderer>().material.color = color;
    }

    private void destroyAndRespwan(GameObject ga)
    {
        StateManager.instantiateEnemy();
        StateManager.destroyEnemy(gameObject, ga);
    }
}
