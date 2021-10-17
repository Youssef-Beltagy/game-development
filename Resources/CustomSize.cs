using UnityEngine;

public class CustomSize : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 desired_dimensions = new Vector3(1, 1, 1);

    void Start()
    {
        Vector3 rescale = GetComponent<Renderer>().bounds.size;

        rescale.x = desired_dimensions.x / rescale.x;
        rescale.y = desired_dimensions.y / rescale.y;

        if (rescale.z != 0) rescale.z = desired_dimensions.z / rescale.z;
        else rescale.z = 0;

        transform.localScale = rescale;
    }

}
