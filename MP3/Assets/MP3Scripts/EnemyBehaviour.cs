using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    public int health = 4;
    public bool changeColor = false;

    public bool chase = false;
    private int target;
    public float rotationSpeed = 0.03f;
    public float movementSpeed = 20f;

    void Start()
    {
        target = Random.Range(0, StateManager.wayPoints.Length);
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    void Update()
    {

        if (chase)
        {
            if ((transform.position - StateManager.wayPoints[target].transform.position).magnitude < 25)
            {
                target = (target + 1) % StateManager.wayPoints.Length;
                if ((StateManager.playerMode & Data.PlayerMode.WayPointSequence) == 0)
                    target = Random.Range(0, StateManager.wayPoints.Length);
            }

            PointAtPosition(StateManager.wayPoints[target].transform.localPosition, rotationSpeed * Time.deltaTime);
            transform.localPosition += transform.up * (movementSpeed * Time.smoothDeltaTime / transform.up.magnitude);
        }
        
    }

    private void PointAtPosition(Vector3 p, float r)
    {
        Vector3 v = p - transform.localPosition;
        transform.up = Vector3.LerpUnclamped(transform.up, v, r);
        transform.up /= transform.up.magnitude;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == Data.PLAYER_NAME)
        {
            destroyAndRespwan(collision.gameObject);
            return;
        }
        
        
        if (collision.gameObject.name != Data.PLAYER_PROJECTILE_NAME){
            return;
        }

        health -= (collision.gameObject.GetComponent<PlayerProjectileBehaviour>().damage);

        if (health <= 0)
        {
            destroyAndRespwan(collision.gameObject);
            return;
        }

        Color color;
        if (changeColor) color = Data.colors[Random.Range(0, Data.colors.Length)];
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
