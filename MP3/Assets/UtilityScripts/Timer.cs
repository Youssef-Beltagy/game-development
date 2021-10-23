using UnityEngine;

public class Timer
{
    private float lastSpawnTime;
    private float spawnRate;

    public Timer(float rate)
    {
        spawnRate = rate;
        lastSpawnTime = Time.time;
    }
    public bool aquire()
    {
        if (Time.time < (lastSpawnTime + spawnRate)) return false;

        lastSpawnTime = Time.time;
        return true;
    }

    public float getRemainingTime()
    {
        return Mathf.Max(0f, lastSpawnTime + spawnRate - Time.time);
    }

    public float getRemainingTimeRatio()
    {
        return getRemainingTime() / spawnRate;
    }
}
