using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text output_text;

    // Start is called before the first frame update
    void Start()
    {

    }

    int num = 0;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) 

        output_text.text = "Yo! " + num;
        num++;
    }

}
