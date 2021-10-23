using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    private static Camera mainCamera;

    float speed;

    public Timer eggTimer;
    public Timer bombTimer;

    void Start()
    {
        mainCamera = Camera.main;
        GetComponent<Rigidbody2D>().freezeRotation = true;

        speed = 20;
        eggTimer = new Timer(0.2f);
        bombTimer = new Timer(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if ((StateManager.playerMode & Data.PlayerMode.Mouse) != 0) setPositionToCursor();
        else updatePosition();

        if (Input.GetKey(KeyCode.Space) && eggTimer.aquire())
        {
            StateManager.instantiateEgg(transform.position + transform.up * (2 / transform.up.magnitude), transform.rotation, Data.ObjectTypes.Egg);
        }

        if (Input.GetKey(KeyCode.B) && bombTimer.aquire())
        {
            StateManager.instantiateEgg(transform.position + transform.up * (2 / transform.up.magnitude), transform.rotation, Data.ObjectTypes.Bomb);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == Data.ENEMY_NAME) StateManager.playerEnemyCollision(gameObject);
    }

    public float getCoolDownRatioForProjectile(Data.ObjectTypes type)
    {
        switch (type)
        {
            case (Data.ObjectTypes.Egg):
                return eggTimer.getRemainingTimeRatio();
            case (Data.ObjectTypes.Bomb):
                return bombTimer.getRemainingTimeRatio();
        }

        return 0;
    }

}
