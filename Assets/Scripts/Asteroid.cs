using JetBrains.Annotations;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float CollisionDamage = 1f;
    public float HealthMax = 5f;

    public GameObject Explosion;
    public GameObject[] ChunkRefs;
    public int ChunksMin = 0;
    public int ChunksMax = 4;
    public float ExplodeDist = 0.5f;
    public float ExplosionForce = 10f;
    public int SpawnValue = 3;
    private float healthCurrent;
    public int ScoreValue = 10;
    

    public void TakeDamage(float damage)
    {
        healthCurrent -= damage;
        if (healthCurrent < 0)
        {
            Explode();
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    private void Start()
    {
        healthCurrent = HealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Spaceship spaceship = collision.gameObject.gameObject.GetComponent<Spaceship>();
        if (spaceship != null)
        {
            spaceship.TakeDamage(CollisionDamage);
        }
    }
    public void Explode()
    {
        Spaceship ship = FindFirstObjectByType<Spaceship>();
        if (ship != null)
        { ship.Score += ScoreValue; }

        Instantiate(Explosion, transform.position, transform.rotation);

        int numChunks = Random.Range(ChunksMin, ChunksMax + 1);

        if (ChunkRefs != null && ChunkRefs.Length > 0)

             for(int i  = 0; i < numChunks; i++)
                 {
                       CreateAsteroidChunk();
                 }

        Destroy(gameObject);
    }

    private void CreateAsteroidChunk()
    {
        int randomIndex = Random.Range(0, ChunkRefs.Length);
        GameObject chunkRef = ChunkRefs[randomIndex];

        Vector2 spawnPos = transform.position;
        spawnPos.x += Random.Range(-ExplodeDist, ExplodeDist);
        spawnPos.y += Random.Range(-ExplodeDist, ExplodeDist);

        GameObject chunk = Instantiate(chunkRef, spawnPos, transform.rotation);

        Vector2 dir = (spawnPos - (Vector2)transform.position).normalized;

        Rigidbody2D rb = chunk.GetComponent<Rigidbody2D>();
        rb.AddForce(dir * ExplosionForce); 
    }
}
