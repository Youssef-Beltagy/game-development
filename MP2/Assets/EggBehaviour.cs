using UnityEngine;

public class EggBehaviour : MonoBehaviour
{

    float speed = 40;

    private static StateManager stateManager = null;

    private void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;

        if(stateManager == null) stateManager = Camera.main.GetComponent<StateManager>();
    }

    private void Update()
    {
        if (!stateManager.pointInWorld(transform.position))
        {
            stateManager.destroyEgg(gameObject);
            return;
        }
        
        transform.position += transform.up * (speed * Time.deltaTime / transform.up.magnitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == Data.PLAYER_NAME) return;

        stateManager.destroyEgg(gameObject);
    }

}
