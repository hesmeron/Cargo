using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beats;

[System.Serializable]
public class Track
{
    public List<Note> notes = new List<Note>();


    public Track()
    {
        
    }
    public void AddBlankNote(int length)
    {
        Note blankNote = new Note();
        blankNote.length = length;
        this.notes.Add(blankNote);
    }
    public void AddNotes(List<NoteView> noteViews)
    {
        notes.Clear();
        NoteView lastNoteView;
        if(noteViews.Count  == 0)
        {
            return;
        }
        CheckPreroll(noteViews[0]);
        lastNoteView = noteViews[0];
        if (noteViews.Count <= 1)
        {
            return;
        }
        Debug.Log(noteViews.Count + " " + "Count");
        for (int i = 1; i < noteViews.Count; i++)
        {
            
            float distance = noteViews[i].gameObject.transform.localPosition.z - lastNoteView.GetEndZPosition();
            Debug.Log("Distance: " + distance.ToString());
            if (distance < 0)
            {
                Debug.LogError("Two notes in the same place");
                distance = 0;
            }
            AddBlankNote((int)distance / 13);
            notes.Add(noteViews[i].note);
            lastNoteView = noteViews[i];
        }
    }
    List<NoteView> CleanNoteViews(List<NoteView> noteViews)
    {
        
        List<NoteView> viewsToRemove = new List<NoteView>();
        foreach (var n in noteViews){
            if (!n)
            {
                viewsToRemove.Add(n);
            }
        }
        foreach(var n in viewsToRemove)
        {
            noteViews.Remove(n);
        }
        return noteViews;
    }

    void CheckPreroll(NoteView noteView)
    {
        if (!noteView)
        {
            return;
        }
        Note blank = new Note();
        float z = noteView.transform.localPosition.z;
        blank.length = (int) noteView.transform.localPosition.z / 13;
        if (z%13 > 13/2)
        {
            blank.length++;
        }
        notes.Add(blank);
        notes.Add(noteView.note);
    }

}

