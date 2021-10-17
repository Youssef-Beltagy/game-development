using UnityEngine;

public class EggBehaviour : MonoBehaviour
{
    private static CameraBehaviour camBehaviour;

    float speed = 40;

    private void Start()
    {
        camBehaviour = Camera.main.GetComponent<CameraBehaviour>();
        camBehaviour.numEggs++;
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }
    private void Update()
    {
        if (!camBehaviour.BoundsContainsPointXY(transform.position))
        {
            camBehaviour.numEggs--;
            Destroy(gameObject);
            return;
        }
        
        transform.position += transform.up * (speed * Time.deltaTime / transform.up.magnitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player") return;

        camBehaviour.numEggs--;
        Destroy(gameObject);
    }

}
