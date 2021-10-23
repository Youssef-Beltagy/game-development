using UnityEngine;
using UnityEngine.UI;
public class CameraBehaviour : MonoBehaviour
{

    private Camera cam;
    [HideInInspector] public Bounds worldBounds;
    public PlayerBehaviour playerBehaviour;

    public Slider playerHealthSlider;
    public Slider bombSlider;
    public Slider eggSlider;
    public Text eggCountText;

    public Text enemyCountText;
    public Text enemiesDestroyedText;
    public Text enemiesDestroyedByPlayerText;

    public Text controlModeText;
    public Text waypointModeText;



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

    public bool pointInWorld(Vector3 pt)
    {
        return ((worldBounds.min.x < pt.x) && (worldBounds.max.x > pt.x) &&
                (worldBounds.min.y < pt.y) && (worldBounds.max.y > pt.y));
    }

    private void UpdateText()
    {
        eggSlider.value = 1 - playerBehaviour.getCoolDownRatioForProjectile(Data.ObjectTypes.Egg);
        bombSlider.value = 1 - playerBehaviour.getCoolDownRatioForProjectile(Data.ObjectTypes.Bomb);
        playerHealthSlider.value = ((float)StateManager.playerLives) / ((float)StateManager.maxPlayerLives);
        eggCountText.text = StateManager.eggCount.ToString();

        enemyCountText.text = (StateManager.enemiesCreated - StateManager.enemiesDestroyed).ToString();
        enemiesDestroyedText.text = StateManager.enemiesDestroyed.ToString();
        enemiesDestroyedByPlayerText.text = StateManager.enemiesDestroyedByPlayer.ToString();

        controlModeText.text = (StateManager.playerMode & Data.PlayerMode.Mouse) != 0 ? "Mouse" : "Keyboard";

        waypointModeText.text = (StateManager.playerMode & Data.PlayerMode.WayPointSequence) != 0 ? "Sequence" : "Random";

    }

}
