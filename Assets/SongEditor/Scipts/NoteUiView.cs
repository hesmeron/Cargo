using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beats;

public class NoteUiView : MonoBehaviour
{
    public Number letterCounter, octaveCounter;
    public Note note;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        letterCounter.number = note.semitoneNumber;
        octaveCounter.number = note.octave; 

        if(note.note == "speed")
        {
            letterCounter.number = 12;
            
        }
        if(note.note == "slow")
        {
            letterCounter.number = 13;
        }



    }
  

    public void Activate(Note note)
    {
        letterCounter.gameObject.SetActive(true);
        octaveCounter.gameObject.SetActive(true);
        this.note = note;
    }
    public void Deactivate()
    {
        letterCounter.gameObject.SetActive(false);
        octaveCounter.gameObject.SetActive(false);
    }
}
