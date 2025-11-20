using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] AsteroidRefs; // asteroids to spawn
    public float CheckInterval = 3f;
    public float PushForce = 10000f;
    public int SpawnThreshold = 10; // in-scene asteroids
    private float checkTimer = 0f;
    public float Inaccuracy = 2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkTimer += Time.deltaTime;
        if (checkTimer > CheckInterval)
            checkTimer = 0f;
        if (TotalAsteroidValue() < SpawnThreshold) //if total value is insufficient, spawn more asteroids.
        {
            SpawnNewAsteroid();
        }
    }


    public void SpawnNewAsteroid()
    {
        // pick an asteroid to spawn
        int randomIndex = Random.Range(0, AsteroidRefs.Length);
        GameObject asteroidRef = AsteroidRefs[randomIndex];

        // find a random spawn point
        Vector2 spawnPoint = OffscreenSpawnPoint();
        GameObject asteroid = Instantiate(asteroidRef, spawnPoint,
        transform.rotation);
        Vector2 force = PushDirection(spawnPoint) * PushForce;
        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        rb.AddForce(force);
    }


    public Vector3 OffscreenSpawnPoint()
    {
        Vector2 randomPos = Random.insideUnitCircle;
        Vector2 direction = randomPos.normalized;
        Vector2 finalPos = (Vector2)transform.position + direction * 2f;
        Vector3 result = Camera.main.ViewportToWorldPoint(finalPos);
        result.z = transform.position.z; // ensure same z-depth so it's alligned with camera.

        return result;
    }


    public int TotalAsteroidValue()
    {
        int value = 0;
        Asteroid[] allAsteroids =
            FindObjectsByType<Asteroid>(FindObjectsSortMode.None);
        foreach (Asteroid asteroid in allAsteroids)
        {
            value += asteroid.SpawnValue;
        }
        return value;
    }

    public Vector2 PushDirection(Vector2 from)
    {
        Vector2 miss = Random.insideUnitCircle * Inaccuracy;
        Vector2 destination = (Vector2)transform.position + miss;
        // make sure SpawnManager is at 0,0,0!
        Vector2 direction = (destination - from).normalized;
        return direction;
    }
}