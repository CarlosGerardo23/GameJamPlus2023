using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ImagefadeScript : MonoBehaviour
{
    [SerializeField] private bool startOn;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float BeginWaitTime;
    [SerializeField] private bool lerpIn;
    [SerializeField] private float BetweenWaitTime;
    [SerializeField] private bool lerpOut;

    [SerializeField] UnityEvent startEvents;
    [SerializeField] UnityEvent endEvents;

    Image imageComponent;
    float fadeLevel;
    float fadeTime;

    void Start()
    {
        imageComponent = GetComponent<Image>();

        if (startOn)
        {
            imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, 100);
        }
        else
        {
            imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, 0);
        }
    }

    void Update()
    {

        if (BeginWaitTime <= 0)
        {
            if (lerpIn)
            {
                fadeLevel = Mathf.Lerp(0, 100, fadeTime);
                fadeTime += lerpSpeed * Time.deltaTime;
                imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, fadeLevel);

                if (lerpOut && fadeLevel == 100)
                {
                    if (BetweenWaitTime <= 0)
                    {
                        lerpIn = false;
                        fadeTime = 0;
                    }
                    else
                    {
                        BetweenWaitTime -= Time.deltaTime;

                    }
                }

                if (fadeLevel == 0)
                {
                    startEvents.Invoke();
                }
            }
            else if (lerpOut)
            {
                fadeLevel = Mathf.Lerp(100f, 0f, fadeTime);
                fadeTime += lerpSpeed * Time.deltaTime;
                imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, fadeLevel);

                if (fadeLevel <= 0)
                {
                    endEvents.Invoke();
                }
            }
        }
        else
        {
            BeginWaitTime -= Time.deltaTime;
        }
    }
}
