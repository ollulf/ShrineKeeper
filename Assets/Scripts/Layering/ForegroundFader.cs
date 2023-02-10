using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundFader : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private AnimationCurve fadeInCurve, fadeOutCurve;
    [SerializeField] private float fadeTime;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }                                                                                                                                 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            StopAllCoroutines();
            StartCoroutine(FadeSprite(fadeTime,false));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            StopAllCoroutines();
            StartCoroutine(FadeSprite(fadeTime, true));
        }
    }

    private IEnumerator FadeSprite (float duration, bool fadeIn)
    {
        float currentDuration = 0;

        while(currentDuration <= duration)
        {
            currentDuration = currentDuration + Time.deltaTime;

            float opacity;

            if (fadeIn)
            {
                opacity = fadeInCurve.Evaluate(currentDuration / duration);
            }
            else
            {
                opacity = fadeOutCurve.Evaluate(currentDuration / duration);
            }

            spriteRenderer.color = new Color(1,1,1,opacity);

            yield return null;
        }

        //if (fadeIn) spriteRenderer.color = new Color(1, 1, 1, 1);
        //else spriteRenderer.color = new Color(1, 1, 1, 0);

    }
}
