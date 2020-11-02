using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFade : MonoBehaviour
{
    public bool firstFade = true;

    // call when fade animation finishes
    public void FadeScreen()
    {
        Debug.Log("Screenfaded");
        if (!firstFade)
        {
            LoadNewArea areaLoader = FindObjectOfType<LoadNewArea>();
            areaLoader.OnFadeComplete();
            Debug.Log("Screen fade successfully");
        }
        else
        {
            firstFade = false;
        }
    }
}
