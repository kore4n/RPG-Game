using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;

    // store player movement animation
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // remove the connection between it and its parent
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        // move player towards the final destination
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        // only get an input if the player is near the destination
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            // check if there is a horizontal input
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                // check if there is NO object that stops movement ahead of the player
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                {
                    // move the character in the horizontal direction
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }

            // check if there is a vertical input
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                // check if there is NO object that stops movement ahead of the player
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                {
                    // move the character in the vertical direction
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }

            anim.SetBool("moving", false);
        }
        else
        {
            anim.SetBool("moving", true);
        }
    }
}
