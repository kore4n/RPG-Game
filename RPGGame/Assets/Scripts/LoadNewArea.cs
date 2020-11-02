using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public string levelToLoad;

    // enter through the door
    public void EnterDoor()
    {
        FindObjectOfType<AudioManager>().Play("DoorClose");
        SceneManager.LoadScene(levelToLoad);
    }

    // enter through opening
    public void EnterOpening()
    {
        // don't play sound of door opening, only change level
        SceneManager.LoadScene(levelToLoad);
    }

    // called by the fade in animation when finished
    // by the ScreenFade script
    public void OnFadeComplete()
    {
        //SceneManager.LoadScene(levelToLoad);
    }
}