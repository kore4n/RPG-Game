using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// serialize to show up in inspector and make it editable
[System.Serializable]
public class Dialogue
{
    // name of npc
    public string name;

    // attribute to change text area in text editor
    // min # lines, max # lines
    [TextArea(3, 10)]
    public string[] sentences;
}