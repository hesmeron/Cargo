using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beats;

public class TrackEditor : MonoBehaviour
{
    Track track;
    NoteEditor noteEditor;
    Transform spawnPoint;
    //KeyCode input;
    public List<NoteView> notes = new List<NoteView>();
    int length = 0;
    // Start is called before the first frame update
    void Start()
    {
        noteEditor = FindObjectOfType<NoteEditor>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Vector3 GetNoteBuildPosition()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        //float z = 13 * (length + 1);
        float z = Mouse.MouseWorldPosition().z;
        Vector3 newPosition = new Vector3(x,y,z);
        return newPosition;
    }
    public void SetTrack(KeyCode key)
    {
        track = new Track(key);
    }

    public void AddNote(Note note, GameObject prefab)
    {
        Vector3 notePosition = NewNotePosition();
        GameObject newNote = Instantiate(prefab, spawnPoint);
        newNote.transform.position = notePosition;
        NoteView newNoteView = newNote.AddComponent<NoteView>();
        newNoteView.note = note;
        notes.Add(newNoteView);

    }

    void OnMouseEnter()
    {
        noteEditor.currentTrack = this;
    }

    public Vector3 NewNotePosition()
    {
        Vector3 position = Mouse.MouseWorldPosition();
        float z = position.z;
        float differece = (z - 5) % 13;
        if ( differece >= 6.5f)
        {
            z = z - +13;
        }
        else
        {
            z -= differece;
        }
        return  position;
    }
    
}
