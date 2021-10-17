using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public int num_scenes = 2;
    void Update()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene == 3) nextScene = 0;

        nextScene %= num_scenes;

        if (Input.GetKeyDown(KeyCode.N))
            SceneManager.LoadScene(nextScene);
    }

}