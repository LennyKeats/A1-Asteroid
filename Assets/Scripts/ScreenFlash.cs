using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    public float FlashDuration = 0.33f;
    private Image FlashImage;
    private Color imageColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FlashImage = GetComponent<Image>();
        imageColor = FlashImage.color;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(FlashRoutine());
        }
    }

    
    public IEnumerator FlashRoutine()
      
    {
        float timer = 0f;
        float t = 0f;
        float alphaFrom = 1f; //max opaqueness
        float alphaTo = 0f; //zero opacity

        while (t < 1f) // Whole condition is true
        {
            timer += Time.deltaTime;
            t = Mathf.Clamp01(timer / FlashDuration);
            float alpha = Mathf.Lerp(alphaFrom, alphaTo, t);
            Color col = imageColor;
            col.a = alpha;
            FlashImage.color = col;

            yield return new WaitForEndOfFrame();
        }



        yield return null;
    }
}
