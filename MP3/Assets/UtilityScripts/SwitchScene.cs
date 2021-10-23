using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public int numScenes = 2;
    public int gameOverSceneIndex = 3;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) loadNextScene();
    }

    public void loadNextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        nextScene %= numScenes;

        if (nextScene == gameOverSceneIndex) nextScene = 0;
            SceneManager.LoadScene(nextScene);
    }

    public void loadGameOverScene()
    {
        SceneManager.LoadScene(gameOverSceneIndex);
    }

}