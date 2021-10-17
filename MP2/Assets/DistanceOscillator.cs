using UnityEngine;

public class DistanceOscillator : MonoBehaviour
{
    public float frequency = 1;
    public bool randomizeFrequency = true;
    public float oscillationRange = 0.2f;

    private float cycle = 0;
    private float magnitude;

    private void Start()
    {
        if (randomizeFrequency) frequency *= Random.value;

        oscillationRange = oscillationRange / 2;

        magnitude = transform.position.magnitude;
    }
    // Update is called once per frame
    void Update()
    {
        if (cycle > 360) cycle -= 360;

        cycle += frequency * Time.deltaTime;
        transform.position = transform.position * ((1 - oscillationRange + oscillationRange * Mathf.Sin(cycle)) * magnitude / transform.position.magnitude);

    }
}
