using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beats;

public class TrackEditor : MonoBehaviour
{
    public Track track;
    NoteEditor noteEditor;
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    TrackView trackView;
    KeyCode input;
    public List<NoteView> notes = new List<NoteView>();
    int length = 0;
    // Start is called before the first frame update
    void Start()
    {
        noteEditor = FindObjectOfType<NoteEditor>();
        track = new Track();
    }

    public Vector3 GetNotePrevievPosition()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        float z = Mouse.MouseWorldPosition().z;
        Vector3 newPosition = new Vector3(x, y, z);
        return newPosition;
    }

    public Vector3 GetNoteBuildPosition(Transform t)
    {
        float x = t.transform.localPosition.x;
        float y = t.transform.localPosition.y;
        float z = GetNoteZPosition(t);
        Vector3 newPosition = new Vector3(x, y, z);
        return newPosition;
    }
    public void SetTrack(KeyCode key)
    {
        track = new Track();
    }

    public void AddNote(Note note, GameObject prefab)
    {
        CleanListOfEmptyViews();
        GameObject newNote = Instantiate(prefab, spawnPoint);
        SetNotePosition(newNote);
        NoteView newNoteView = newNote.AddComponent<NoteView>();
        newNoteView.note = note;
        newNoteView.inEditing = true;
        newNoteView.editor = this;
        AddNoteViewToList(newNoteView);
    }

    public void SetNotePosition(GameObject newNote)
    {
        Vector3 notePosition = GetNotePrevievPosition();
        newNote.transform.position = notePosition;
        newNote.transform.localPosition = GetNoteBuildPosition(newNote.transform);
    }

    void CleanListOfEmptyViews()
    {
        for(int i=0; i<notes.Count; i++)
        {
            if(notes[i] == null)
            {
                notes.RemoveAt(i);
            }
        }
    }
    void AddNoteViewToList(NoteView noteView)
    {
        int index = notes.Count - 1;
        if(notes.Count == 0)
        {
            notes.Add(noteView);
            return;
        }
        float z = noteView.gameObject.transform.position.z;
        if (z > notes[index].GetStartZPosition())
        {
            notes.Add(noteView);
            return;
        }
        else
        {
            for(int i = index; i > 0; i--)
            {
                if (z < notes[i].GetStartZPosition() && z > notes[i - 1].GetStartZPosition())
                {
                    notes.Insert(i, noteView);
                    return;
                }
            }

            notes.Insert(0, noteView);
            return;
        }


    }

    void OnMouseEnter()
    {
        noteEditor.currentTrack = this;
    }


    public float GetNoteZPosition(Transform t)
    {
        Vector3 position = t.localPosition;
        float z = position.z;
        float differece = (z) % 13;
        z -= differece;
        if ( differece >= 6.5f)
        {
            z += 13;
        }
        if(z == 0)
        {
            z = 13;
        }
        return  z;
    }

    public void PrepareToSave()
    {
        Debug.Log(notes.Count);
        CleanListOfEmptyViews();
        track.AddNotes(notes);

    }

    public void LoadTrack(Track track)
    {
        this.track = track;
        trackView.AddTrack(track);
        trackView.Init();
        notes = trackView.noteViews;
    }
    
}
