using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{

    public static Data.PlayerMode playerMode = Data.PlayerMode.Mouse;
    public static int enemiesCreated = 0;
    public static int enemiesDestroyed = 0;
    public static int enemiesDestroyedByPlayer = 0;
    public static int eggCount = 0;

    public static int maxPlayerLives = 3;
    public static int playerLives;

    private static CameraBehaviour cameraBehaviour;

    // Start is called before the first frame update
    void Awake()
    {
        cameraBehaviour = Camera.main.GetComponent<CameraBehaviour>();
        playerLives = maxPlayerLives;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) playerMode ^= Data.PlayerMode.Mouse;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerMode ^= Data.PlayerMode.FewLives;
            playerLives = maxPlayerLives;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) playerMode ^= Data.PlayerMode.EnableEnemy2;

        if (Input.GetKeyDown(KeyCode.Alpha3)) playerMode ^= Data.PlayerMode.EnableEnemy3;

    }

    private void Start()
    {
        for (int i = 0; i < 10; i++) instantiateEnemy();
    }

    public static void instantiateEnemy()
    {
        Bounds worldBounds = cameraBehaviour.worldBounds;

        enemiesCreated++;
        Vector3 position = new Vector3();

        position.z = 0;

        float delta = 0.05f * (worldBounds.max.x - worldBounds.min.x);
        position.x = Random.Range(worldBounds.min.x + delta, worldBounds.max.x - delta);

        delta = 0.05f * (worldBounds.max.y - worldBounds.min.y);
        position.y = Random.Range(worldBounds.min.y + delta, worldBounds.max.y - delta);
        
        GameObject e = Instantiate(Resources.Load(chooseEnemy()) as GameObject);
        e.transform.position = position;
        e.name = Data.ENEMY_NAME;
    }

    private static string chooseEnemy()
    {
        switch (((int)Random.Range(0, 9)) % 3)
        {
            case 0:
                return "Prefabs/Enemy1";
            case 1:
                if((playerMode & Data.PlayerMode.EnableEnemy2) != 0) return "Prefabs/Enemy2";
                break;
            case 2:
                if ((playerMode & Data.PlayerMode.EnableEnemy3) != 0) return "Prefabs/Enemy3";
                break;
        }
        return "Prefabs/Enemy1";
    }

    public static void instantiateEgg(Vector3 position, Quaternion orientation, bool bomb)
    {
        eggCount++;
        string eggType = "Prefabs/Egg";
        if (bomb) eggType = "Prefabs/Bomb";
        GameObject e = Instantiate(Resources.Load(eggType) as GameObject);
        e.transform.position = position;
        e.transform.rotation = orientation;
        e.name = Data.EGG_NAME;
    }


    public static void destroyEnemy(GameObject e, GameObject by)
    {
        enemiesDestroyed++;
        if (by.name == Data.PLAYER_NAME) enemiesDestroyedByPlayer++;
        Destroy(e);
    }

    public static void destroyEgg(GameObject e)
    {
        eggCount--;
        Destroy(e);
    }

    public static bool pointInWorld(Vector3 point)
    {
        return cameraBehaviour.pointInWorld(point);
    }

    public static void playerCollision(GameObject player)
    {
        if ((StateManager.playerMode & Data.PlayerMode.FewLives) == 0) return;

        playerLives--;
        if (playerLives > 0) return;

        Destroy(player);
        SceneManager.LoadScene(1);
    }

}

