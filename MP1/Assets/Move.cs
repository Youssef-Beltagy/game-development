using UnityEngine;

public class Move : MonoBehaviour
{

    public Vector2 step = new Vector2(0, 0);
    public Vector2 min_val = new Vector2(0, 0);
    public Vector2 max_val = new Vector2(0, 0);

    void FixedUpdate()
    {
        float v_val = Input.GetAxis("Vertical");
        if(v_val != 0) ExpandCollapse(v_val); // 0 is set, so it is okay to compare with it.
 
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
        Vector2 increment = step * v_val;

        if (
            !( // If the next step is not in range, do nothing.
            ((transform.position.x + increment.x) <= max_val.x) &&
            ((transform.position.x + increment.x) >= min_val.x) &&
            ((transform.position.y + increment.y) <= max_val.y) &&
            ((transform.position.y + increment.y) >= min_val.y)
            )
            
            ) return;

        transform.position += new Vector3(increment.x, increment.y, 0);

        float s = v_val * 0.1f;
        Vector3 size = new Vector3(s, s, 0);
        Vector3 sum = transform.localScale + size;
        if (sum.x >= 0 && sum.y >= 0)
            transform.localScale += size;

    }

}
