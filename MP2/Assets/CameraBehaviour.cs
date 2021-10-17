using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBehaviour : MonoBehaviour
{
    private Camera cam;   // Will find this on the gameObject
    public Bounds worldBounds;  // Computed bound from the camera

    public int numEnemies = 0;
    public int enemiesCreated = 0;

    public Text text;
    public GameObject Player;
    public int numEggs;
    PlayerBehaviour playerBehaviour;

    void Awake()  // camera may be disabled by some in Start(), so init in Awake.
    {
        cam = gameObject.GetComponent<Camera>();

        worldBounds = new Bounds();
        UpdateWorldWindowBound();

        for (int i = 0; i < 10; i++) instantiateEnemy();

        playerBehaviour = Player.GetComponent<PlayerBehaviour>();
    }


    void Update()
    {
        UpdateWorldWindowBound();
        UpdateText();
    }

    private void UpdateWorldWindowBound()
    {

        float maxY = cam.orthographicSize;
        float maxX = cam.orthographicSize * cam.aspect;
        float sizeX = 2 * maxX;
        float sizeY = 2 * maxY;

        // Make sure z-component is always zero
        Vector3 c = cam.transform.position;
        c.z = 0.0f;
        worldBounds.center = c;
        worldBounds.size = new Vector3(sizeX, sizeY, 1f);  // z is arbitrary!!

    }

    public bool BoundsContainsPointXY(Vector3 pt)
    {
        return ((worldBounds.min.x < pt.x) && (worldBounds.max.x > pt.x) &&
                (worldBounds.min.y < pt.y) && (worldBounds.max.y > pt.y));
    }

    public void instantiateEnemy()
    {
        numEnemies++;
        enemiesCreated++;
        Vector3 position = transform.position;

        position.z = 0;

        float delta = 0.05f * (worldBounds.max.x - worldBounds.min.x);
        position.x = Random.Range(worldBounds.min.x + delta, worldBounds.max.x - delta);

        delta = 0.05f * (worldBounds.max.y - worldBounds.min.y);
        position.y = Random.Range(worldBounds.min.y + delta, worldBounds.max.y - delta);

        GameObject e = Instantiate(Resources.Load("Prefabs/Enemy") as GameObject);
        e.transform.position = position;
        e.name = "Enemy";
    }

    private void UpdateText()
    {
        text.text = "Mode: " + playerBehaviour.player_mode.ToString().PadRight(20,' ');
        text.text += " Hero touched: " + playerBehaviour.num_enemies_destroyed.ToString().PadRight(5, ' ');
        text.text += " Eggs: " + numEggs.ToString().PadRight(5,' ');
        text.text += " Enemies: " + numEnemies.ToString().PadRight(5, ' ');
        text.text += " Enemies Destroyed: " + (enemiesCreated - numEnemies).ToString().PadRight(5,' ');

    }

}
