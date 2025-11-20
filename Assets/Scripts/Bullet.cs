using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage = 1f;
    public GameObject Explosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // this work I did is worth saving.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();
        if (asteroid)
        {
            asteroid.TakeDamage(Damage);
            Explode(); 
        }
    }
    private void Explode()
    {
        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject); 
    }
}
