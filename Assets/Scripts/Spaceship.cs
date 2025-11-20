using UnityEngine;

public class Spaceship : MonoBehaviour
{

    public float EnginePower = 30f;
    public float TurnPower = 35f;

    public float HealthMax = 3f;
    public float HealthCurrent;

    public GameObject BulletRef;
    public float BulletSpeed = 300f;

    public float FiringRate = 0.33f;
    private float fireTimer = 0f;

    public GameObject Explosion;
  
    private Rigidbody2D rb2D;

    public ScreenFlash Flash;

    public int Score = 0;
    public GameOverUI GameOverUI;

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HiScore", 0);
            }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        HealthCurrent = HealthMax;
    }
    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt("Hiscore", score);
    }

void UpdateFiring()
        {
            bool isFiring = Input.GetButton("Fire1");
            fireTimer = fireTimer - Time.deltaTime;
            if (isFiring && fireTimer <= 0F)
            {
                FireBullet();
                fireTimer = FiringRate;
            }
        }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Mathf.Clamp(Input.GetAxis("Vertical"), 0, 1);

        ApplyThrust(vert);
        ApplyTorque(-horiz);

        UpdateFiring(); 
    }

    public void GameOver()
    {
        bool CelebrateHiScore = false;
        if (Score > GetHighScore())
        {
            SetHighScore(Score);
            CelebrateHiScore = true;

        }

    }
    private void ApplyThrust(float amount)
    {
        Vector2 thrust = transform.up * EnginePower * Time.deltaTime * amount;
        rb2D.AddForce(thrust);
    }
    private void ApplyTorque(float amount)
    {
        float torque = amount * TurnPower * Time.deltaTime;
        rb2D.AddTorque(torque);
    }

    public void TakeDamage(float damage)
    {
      
        StartCoroutine(Flash.FlashRoutine());
        HealthCurrent = HealthCurrent - damage;
        if (HealthCurrent <= 0)
        {
            Explode();
        }
    }
    public void Explode()
    {
        Debug.Log("Perished");
        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    

    public void FireBullet()
    {
        GameObject bullet = Instantiate(BulletRef, transform.position, transform.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null )
        {
            Vector2 force = transform.up * BulletSpeed;
            rb.AddForce(force); 
        }
        
    }

}
