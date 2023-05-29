using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderController : MonoBehaviour
{
    public bool FadingIn;
    public float FadingTime;
    private CanvasGroup canvasGroup;
    

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        
    }

    private void Update()
    {
        if (FadingIn)
        {
            canvasGroup.alpha -= Time.deltaTime / FadingTime;
            if (Mathf.Approximately(canvasGroup.alpha, 0f))
            {
                this.enabled = false;
            }
        }

        else if (!FadingIn)
        {
            canvasGroup.alpha += Time.deltaTime / FadingTime;
            if (Mathf.Approximately(canvasGroup.alpha, 1f))
            {
                this.enabled = false;
            }
        }
    }
}
