using UnityEngine;

public class AutoDestory : MonoBehaviour
{
    public float LifeTime = 5f;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= LifeTime)
        {
            Destroy(gameObject);
        }
    }
}
