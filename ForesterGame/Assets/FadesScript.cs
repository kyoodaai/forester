using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadesScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator FadeCoroutine(float startAlpha, float endAlpha, float duration, TextMeshProUGUI text)
    {
        Color startColor = text.color;
        startColor.a = startAlpha;
        text.color = startColor;

        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            startColor.a = alpha;
            text.color = startColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Устанавливаем окончательный альфа-канал
        startColor.a = endAlpha;
        text.color = startColor;
    }
}
