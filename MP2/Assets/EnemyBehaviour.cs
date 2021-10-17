using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    private static StateManager stateManager;
    public int health = 4;

    private void Start()
    {
        if (stateManager == null) stateManager = Camera.main.GetComponent<StateManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == Data.PLAYER_NAME)
        {
            destroyAndRespwan(collision.gameObject);
            return;
        }
        
        
        if (collision.gameObject.name == Data.EGG_NAME){
            health--;
            Color color = GetComponent<Renderer>().material.color;
            color.a *= 0.8f;
            GetComponent<Renderer>().material.color = color; 
            if (health <= 0) destroyAndRespwan(collision.gameObject);
        }
    }

    private void destroyAndRespwan(GameObject ga)
    {
        StateManager.instantiateEnemy();
        StateManager.destroyEnemy(gameObject, ga);
    }
}
