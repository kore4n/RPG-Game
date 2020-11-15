using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 25f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;

    // store player movement animation
    public Animator anim;

    // bool to see if player exists
    // used when changing between scenes
    public static bool playerExists;

    // check if the player can move
    // used in cutscenes and dialogue
    public bool canMove = true;

    // TODO Animate player based on lsat move
    // last move to determine orientation
    public Vector2 lastMove;

    // only used for animations
    Vector2 movement;

    private Collider2D collision;

    private bool isColliding;

    private Interactable interaction;

    // Start is called before the first frame update
    void Start()
    {
        // remove the connection between it and its parent
        movePoint.parent = null;

        // run if the player does not exist
        if (!playerExists)
        {
            playerExists = true;
            // don't destroy scripts and gameobjects attached
            // for loading between scenes
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // check if it can be interacted with
        Interactable interaction = collision.gameObject.GetComponent<Interactable>();

        if (interaction != null)
        {
            isColliding = true;
            this.collision = collision;
            this.interaction = interaction;

            TryToMoveIntoScene(collision, interaction);
        }
        //else
        //{
        //    isColliding = false;
        //}
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }

    void Interact(Collider2D collision, Interactable interaction)
    {
        // interact with objects
            
        // if it's a bookshelf, begin dialogue
        if (interaction.interactableName == "BookShelf")
        {
            DialogueTrigger text = collision.gameObject.GetComponent<DialogueTrigger>();
            text.TriggerDialogue();
        }
        else if (interaction.interactableName == "Door")
        {
            LoadNewArea door = collision.gameObject.GetComponent<LoadNewArea>();
            door.EnterDoor();
        }
        else if (interaction.interactableName == "ChestUnopened")
        {
            // close the chest
            interaction.interactableName = "ChestOpened";
            // add in code to allow player to pick up item
            
        }
    }

    void TryToMoveIntoScene(Collider2D collision, Interactable interaction)
    {
        if (interaction.interactableName == "Opening")
        {
            LoadNewArea opening = collision.gameObject.GetComponent<LoadNewArea>();
            opening.EnterOpening();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) == true)
        {
            if (isColliding == true)
            {
                Interact(collision, interaction);
            }
        }

        // check if the dialogue is open
        if (FindObjectOfType<DialogueManager>().animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "DialogueBox_Open")
        {
            // disable movement if dialogue is up
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        //// prevent player from moving if pointer is over UI
        //if (EventSystem.current.IsPointerOverGameObject())
        //{
        //    return;
        //}

        // check if the player can move
        if (canMove == true)
        {
            // perform animations
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("Speed", movement.sqrMagnitude); 

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

                //anim.SetBool("moving", false);
            }
            else
            {
                //anim.SetBool("moving", true);
            }
        }
    }
}
