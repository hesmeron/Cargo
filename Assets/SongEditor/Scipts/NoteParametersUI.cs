using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Beats;
using System;

public class NoteParametersUI : MonoBehaviour
{
    NoteEditor noteEditor;
    [SerializeField]
    InputField noteInput;
    [SerializeField]
    Text octaveText;
    // Start is called before the first frame update
    void Start()
    {
        noteEditor = FindObjectOfType<NoteEditor>();
    }

    // Update is called once per frame
    void Update()
    {
        
        noteEditor.note.SetNote(noteInput.text);
        octaveText.text = noteEditor.note.octave.ToString();


    }


}
