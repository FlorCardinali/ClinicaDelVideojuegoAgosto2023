using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeCanvasGroup : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] bool fadeIn;
    [SerializeField] bool fadeOut;
    public float fadeDuration = 1.0f;

    public void fadeToOne()
    {
        fadeIn = true;
    }

    public void fadeToZero()
    {
        fadeOut = true;
    }

    private void Update()
    {
        if(fadeIn)
        {
            if(canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime;
                if(canvasGroup.alpha >= 1 ) {
                fadeIn=false;}
            }
        }
        if (fadeOut)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= Time.deltaTime;
                if (canvasGroup.alpha == 1)
                {
                    fadeOut = false;
                }
            }
        }
    }
}