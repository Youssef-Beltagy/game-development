using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ControllerCircleBehavior : MonoBehaviour
{

    public static int score = 0;
    public static int numLives = 3;

    public Text text;


    void Update()
    {
        text.text = "Score: " + score.ToString().PadRight(5, ' ');
        text.text += "Lives: " + numLives.ToString().PadRight(5, ' ');

        if(numLives <= 0) SceneManager.LoadScene(2);
    }
}
