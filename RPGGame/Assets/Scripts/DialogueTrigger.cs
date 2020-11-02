using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool oneTimeTrigger;

    private bool hasBeenTriggered;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (oneTimeTrigger == true)
        {
            if (hasBeenTriggered == false)
            {
                // trigger dialogue is the player walks by
                // only trigger dialogue if collider CANNOT be interacted with 
                if (other.gameObject.name == "Player" && GetComponent<Interactable>() == null)
                {
                    TriggerDialogue();
                    hasBeenTriggered = true;
                }
            }
        }
        else
        {
            // trigger dialogue is the player walks by
            // only trigger dialogue if collider CANNOT be interacted with 
            if (other.gameObject.name == "Player" && GetComponent<Interactable>() == null)
            {
                TriggerDialogue();
            }
        }
        
    }
}
