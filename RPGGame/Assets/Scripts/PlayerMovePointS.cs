using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePointS : MonoBehaviour
{
    public static bool playerMovePointExists;

    // store the player
    private PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        // run if the player does not exist
        if (!playerMovePointExists)
        {
            playerMovePointExists = true;
            // don't destroy scripts and gameobjects attached
            // for loading between scenes
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        thePlayer = FindObjectOfType<PlayerController>();
        thePlayer.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
