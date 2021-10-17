using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    //private Camera cam;   // Will find this on the gameObject
    //public Bounds worldBounds;  // Computed bound from the camera

    //void Awake()  // camera may be disabled by some in Start(), so init in Awake.
    //{
    //    cam = gameObject.GetComponent<Camera>();
        
    //    worldBounds = new Bounds();
    //    UpdateWorldWindowBound();
    //}

    //void Update()
    //{
    //    UpdateWorldWindowBound();
    //}

    //private void UpdateWorldWindowBound()
    //{
        
    //    float maxY = cam.orthographicSize;
    //    float maxX = cam.orthographicSize * cam.aspect;
    //    float sizeX = 2 * maxX;
    //    float sizeY = 2 * maxY;

    //    // Make sure z-component is always zero
    //    Vector3 c = cam.transform.position;
    //    c.z = 0.0f;
    //    worldBounds.center = c;
    //    worldBounds.size = new Vector3(sizeX, sizeY, 1f);  // z is arbitrary!!

    //}

    //// Cannot use the regular bounds intersect() and contains() function
    //// Because we are not using the Z-values 
    //private bool BoundsIntersectInXY(Bounds b1, Bounds b2)
    //{
    //    return (b1.min.x < b2.max.x) && (b1.max.x > b2.min.x) &&
    //           (b1.min.y < b2.max.y) && (b1.max.y > b2.min.y);
    //}

    //private bool BoundsContainsPointXY(Bounds b, Vector3 pt)
    //{
    //    return ((b.min.x < pt.x) && (b.max.x > pt.x) &&
    //            (b.min.y < pt.y) && (b.max.y > pt.y));
    //}

}
