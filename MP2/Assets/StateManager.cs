using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    public static Data.PlayerMode playerMode = Data.PlayerMode.Mouse;
    public static int enemiesCreated = 0;
    public static int enemiesDestroyed = 0;
    public static int enemiesDestroyedByPlayer = 0;
    public static int eggCount = 0;
    
    private static CameraBehaviour cameraBehaviour;

    // Start is called before the first frame update
    void Awake()
    {
        cameraBehaviour = Camera.main.GetComponent<CameraBehaviour>();

        // To guarantee the world bounds are initialized before instantiating enemies
        cameraBehaviour.UpdateWorldWindowBound();
        for (int i = 0; i < 10; i++) instantiateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) playerMode ^= Data.PlayerMode.Keyboard;
    }

    public void instantiateEnemy()
    {
        Bounds worldBounds = cameraBehaviour.worldBounds;

        enemiesCreated++;
        Vector3 position = transform.position;

        position.z = 0;

        float delta = 0.05f * (worldBounds.max.x - worldBounds.min.x);
        position.x = Random.Range(worldBounds.min.x + delta, worldBounds.max.x - delta);

        delta = 0.05f * (worldBounds.max.y - worldBounds.min.y);
        position.y = Random.Range(worldBounds.min.y + delta, worldBounds.max.y - delta);

        GameObject e = Instantiate(Resources.Load("Prefabs/Enemy") as GameObject);
        e.transform.position = position;
        e.name = Data.ENEMY_NAME;
    }

    public void instantiateEgg(Vector3 position, Quaternion orientation)
    {
        eggCount++;
        GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject);
        e.transform.position = position;
        e.transform.rotation = orientation;
        e.name = Data.EGG_NAME;
    }


    public void destroyEnemy(GameObject e, GameObject by)
    {
        enemiesDestroyed++;
        if (by.name == Data.PLAYER_NAME) enemiesDestroyedByPlayer++;
        Destroy(e);
    }

    public void destroyEgg(GameObject e)
    {
        eggCount--;
        Destroy(e);
    }

    public bool pointInWorld(Vector3 point)
    {
        return cameraBehaviour.pointInWorld(point);
    }


}

