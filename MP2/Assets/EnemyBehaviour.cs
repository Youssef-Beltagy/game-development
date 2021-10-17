using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    public static CameraBehaviour camBehaviour;
    public int health = 4;

    private void Start()
    {
        camBehaviour = Camera.main.GetComponent<CameraBehaviour>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            destroyAndRespwan();
        }
        else if (collision.gameObject.name == "Egg"){
            health--;
            Color color = GetComponent<Renderer>().material.color;
            color.a *= 0.8f;
            GetComponent<Renderer>().material.color = color; 
            if (health <= 0) destroyAndRespwan();
        }
    }

    private void destroyAndRespwan()
    {
        camBehaviour.instantiateEnemy();
        camBehaviour.numEnemies--;
        Destroy(gameObject);
    }
}
