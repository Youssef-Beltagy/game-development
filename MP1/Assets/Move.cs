using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector2 start_pos = new Vector2(1, 1);
    public Vector2 step = new Vector2(1, 1); // should never have x = 0
    public Vector2 min_val = new Vector2(0, 0);
    public Vector2 max_val = new Vector2(50, 50);
    

    void FixedUpdate()
    {
        float v_val = Input.GetAxis("Vertical");
        if(Mathf.Abs(v_val) >= 0.1) ExpandCollapse(v_val);
 
    }

    /// <summary>
    /// Expands/Collapses the gameobject by moving it and scaling it using v_val.
    /// 
    /// v_val is assumed to be smooth. Thus it safe to assume there is no significant signal noise.
    /// This also adds inertia to the movement. The Professor's WebGL sample had inertia, so this is pretty close.
    /// </summary>
    /// <param name="v_val">The Vertical Axis reading</param>
    private void ExpandCollapse(float v_val)
    {

        // using v_val as a weight adds inertia to the movement and guarantees that
        // The movement and size of the GameObject are both functions of V_Val. Thus,
        // At any position, there can only be one size.
        float x = transform.position.x + step.x * v_val; // Find the next x postion

        // Clamp the next  xposition and then find the difference between the next position and current position
        x = Mathf.Max(Mathf.Min(x, max_val.x), min_val.x) - transform.position.x;

        v_val = x / step.x; // find the movement factor.

        Vector2 increment = step * v_val;
        transform.position += new Vector3(increment.x, increment.y, 0);

        float s = v_val * 0.1f;
        Vector3 size = new Vector3(s, s, 0);
        transform.localScale += size;

        if(transform.position.x == start_pos.x && transform.position.y == start_pos.y) // reset the values;
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position = new Vector3(start_pos.x, start_pos.y, 0);
        }

    }

}
