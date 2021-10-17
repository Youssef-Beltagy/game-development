using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public enum PlayerMode
    {
        mouse = 0,
        keyboard = 1
    }

    public PlayerMode player_mode;
    private Camera mainCamera;
    float speed;

    public float spawnRate = 0.2f;
    public int num_enemies_destroyed = 0;
    float lastSpawnTime;

    void Start()
    {
        mainCamera = Camera.main;
        player_mode = PlayerMode.mouse;
        GetComponent<Rigidbody2D>().freezeRotation = true;
        speed = 20;
        lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerMode();
        if (player_mode == PlayerMode.mouse) setPositionToCursor();
        if (player_mode == PlayerMode.keyboard) updatePosition();

        if (Input.GetKey(KeyCode.Space) && Time.time > lastSpawnTime + spawnRate)
        {
            lastSpawnTime = Time.time;
            GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject);
            e.transform.position = transform.position + transform.up * (2 / transform.up.magnitude);
            e.transform.rotation = transform.rotation;
            e.name = "Egg";
        }

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
            player_mode = PlayerMode.mouse;
        }

    }

    private void setPositionToCursor()
    {
        Vector3 new_position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        new_position.z = transform.position.z;
        transform.position = new_position;
    }

    private void updatePosition()
    {
        speed += Input.GetAxis("Vertical") * 0.2f;
        transform.position +=  transform.up * (speed * Time.deltaTime / transform.up.magnitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy") num_enemies_destroyed++;
    }
}
