using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DilationScript : MonoBehaviour
{
    [SerializeField] private bool startOn;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float BeginWaitTime;
    [SerializeField] private bool lerpIn;
    [SerializeField] private float BetweenWaitTime;
    [SerializeField] private bool lerpOut;

    [SerializeField] UnityEvent startEvents;
    [SerializeField] UnityEvent endEvents;

    TextMeshProUGUI tmp;
    TMP_Text textComponent;
    float dilateLevel;
    float dilateTime;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        textComponent = tmp.GetComponent<TMP_Text>();


        if (startOn)
        {
            tmp.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, 0);
            textComponent.enabled = true;
        }
        else
        {
            textComponent.enabled = false;
            tmp.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -.8f);
        }
    }

    void Update()
    {

        if (BeginWaitTime <= 0)
        {
            if (lerpIn)
            {
                textComponent.enabled = true;

                dilateLevel = Mathf.Lerp(-.8f, 0, dilateTime);
                dilateTime += lerpSpeed * Time.deltaTime;
                tmp.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, dilateLevel);

                if (lerpOut && dilateLevel == 0)
                {
                    if (BetweenWaitTime <= 0)
                    {
                        lerpIn = false;
                        dilateTime = 0;
                    }
                    else
                    {
                        BetweenWaitTime -= Time.deltaTime;

                    }
                }

                if (dilateLevel == 0)
                {
                    startEvents.Invoke();
                }
            }
            else if (lerpOut)
            {
                dilateLevel = Mathf.Lerp(0f, -.8f, dilateTime);
                dilateTime += lerpSpeed * Time.deltaTime;
                tmp.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, dilateLevel);

                if (dilateLevel <= -.8f)
                {
                    textComponent.enabled = false;
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
