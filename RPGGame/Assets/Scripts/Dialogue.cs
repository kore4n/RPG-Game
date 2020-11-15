using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// serialize to show up in inspector and make it editable
[System.Serializable]
public class Dialogue
{
    // names of npcs
    [TextArea(1, 3)]
    public string[] names;

    public string name;

    // attribute to change text area in text editor
    // min # lines, max # lines
    [TextArea(7, 12)]
    public string[] sentences;
}