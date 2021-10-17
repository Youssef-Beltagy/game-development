using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public int num_scenes = 2;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
            SceneManager.LoadScene(
                (SceneManager.GetActiveScene().buildIndex + 1) % num_scenes
                );
    }

}