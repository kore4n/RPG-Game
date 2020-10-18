using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    // store the player
    private PlayerController thePlayer;
    // store the player's move point
    private PlayerMovePointS playerMovePoint;

    // starting direction for player to face when loading into a scene
    public Vector2 startDirection;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        thePlayer.transform.position = transform.position;

        playerMovePoint = FindObjectOfType<PlayerMovePointS>();
        playerMovePoint.transform.position = transform.position;

        //thePlayer.lastMove = startDirection;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
