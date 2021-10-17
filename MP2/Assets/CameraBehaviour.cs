using UnityEngine;
using UnityEngine.UI;

public class CameraBehaviour : MonoBehaviour
{

    private Camera cam;
    private StateManager stateManager;
    public Bounds worldBounds;
    public Text text;
    
    void Awake()  // camera may be disabled by some in Start(), so init in Awake.
    {
        cam = gameObject.GetComponent<Camera>();

        worldBounds = new Bounds();
        UpdateWorldWindowBound();

    }

    void Update()
    {
        UpdateWorldWindowBound();
        UpdateText();
    }

    public void UpdateWorldWindowBound()
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

    public bool pointInWorld(Vector3 pt)
    {
        return ((worldBounds.min.x < pt.x) && (worldBounds.max.x > pt.x) &&
                (worldBounds.min.y < pt.y) && (worldBounds.max.y > pt.y));
    }

    private void UpdateText()
    {
        
        text.text =  " Hero touched: " + playerBehaviour.num_enemies_destroyed.ToString().PadRight(5, ' ');
        text.text += " Eggs: " + numEggs.ToString().PadRight(5,' ');
        text.text += " Enemies: " + numEnemies.ToString().PadRight(5, ' ');
        text.text += " Enemies Destroyed: " + (enemiesCreated - numEnemies).ToString().PadRight(5,' ');
        text.text += " Mode: " + playerBehaviour.player_mode.ToString().PadRight(20, ' ');

    }

}
