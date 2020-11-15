using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    // for personal note:
    // part of FIFO principle: first in, first out
    // a queue is like an array
    private Queue<string> sentences;

    // these 2 variables are changed in this script
    private int index = -1;
    private Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        if (dialogue.names.Length == 0)
        {
            nameText.text = dialogue.name;
        }
        // an else isn't needed, the name is automatically filled from DisplayNextSentence
        // as it's called immediately

        // clear old sentences from previous conversations
        sentences.Clear();

        // clear all old sentences
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        this.dialogue = dialogue;

        DisplayNextSentence();
    }

    public void UpdateDialogue(int index)
    {
        // ADD IN THE FUNCTION ANYTHING THAT NEEDS TO BE UPDATED FROM TEXTBOX TO TEXTBOX
        // Such as avatar, element symbol, character name, text font, etc...
        nameText.text = dialogue.names[index];
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        // if stop sentence is already running, stop it and start a new one
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        // update name of the speaker
        UpdateDialogue(index + 1);
        index += 1;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    private void Update()
    {
        // check if the dialogue is open
        if (FindObjectOfType<DialogueManager>().animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "DialogueBox_Open")
        {
            if (Input.GetKeyDown(KeyCode.C) == true)
            {
                DisplayNextSentence();
            }
            else if (Input.GetKeyDown(KeyCode.Z) == true)
            {
                EndDialogue();
            }
        }
    }
}
