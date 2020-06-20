using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beats;

[System.Serializable]
public class Track
{
    public List<Note> notes = new List<Note>();
    public KeyCode key;

    public Track(KeyCode key)
    {
        this.key = key;
    }
}

