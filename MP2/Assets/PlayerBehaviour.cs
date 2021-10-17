using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    private static Camera mainCamera;
    private static StateManager stateManager;

    float speed;

    public float spawnRate = 0.2f;
    float lastSpawnTime;

    void Start()
    {
        mainCamera = Camera.main;
        stateManager = mainCamera.GetComponent<StateManager>();
        GetComponent<Rigidbody2D>().freezeRotation = true;

        speed = 20;
        lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if ((StateManager.playerMode & Data.PlayerMode.ALLON) == Data.PlayerMode.Mouse) setPositionToCursor();
        if ((StateManager.playerMode & Data.PlayerMode.ALLON) == Data.PlayerMode.Keyboard) updatePosition();

        if (Input.GetKey(KeyCode.Space) && Time.time > lastSpawnTime + spawnRate)
        {
            lastSpawnTime = Time.time;
            mainCamera.GetComponent<StateManager>().instantiateEgg(transform.position + transform.up * (2 / transform.up.magnitude), transform.rotation);
        }

    }

    private void setPositionToCursor()
    {
        speed = 20; // reset the speed every time you use the cursor.
        Vector3 new_position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        new_position.z = transform.position.z;
        transform.position = new_position;
    }

    private void updatePosition()
    {
        speed += Input.GetAxis("Vertical") * 0.2f;
        transform.position +=  transform.up * (speed * Time.deltaTime / transform.up.magnitude);
    }

}
