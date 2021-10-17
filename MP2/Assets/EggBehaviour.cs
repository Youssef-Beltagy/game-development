using UnityEngine;

public class EggBehaviour : MonoBehaviour
{

    public float speed = 40;
    public int damage = 1;

    private void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    private void Update()
    {
        if (!StateManager.pointInWorld(transform.position))
        {
            StateManager.destroyEgg(gameObject);
            return;
        }
        
        transform.position += transform.up * (speed * Time.deltaTime / transform.up.magnitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != Data.ENEMY_NAME) return;

        StateManager.destroyEgg(gameObject);
    }

}
