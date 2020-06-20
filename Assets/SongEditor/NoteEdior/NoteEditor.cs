using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beats;

public class NoteEditor : MonoBehaviour
{
    
    public Note note = new Note();
    public float scale = 1f;
    public GameObject trainPrefab, carPrefab, firstTrain;
    public List<GameObject> cars = new List<GameObject>();
    public TrackEditor currentTrack;
    public Transform spawnPoint;
    public bool isBuilding = true;
    [SerializeField]
    NoteUiView noteUiView;
    // Start is called before the first frame update
    void Start()
    {
        firstTrain = Instantiate(trainPrefab, spawnPoint);
        noteUiView.note = note;
        note.length = 1;
        note.SetNote("C");
        cars.Add(firstTrain);
         
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTrack == null)
        {
            return;
        }
        Vector3 newPosition = currentTrack.GetNotePrevievPosition();
        //firstTrain.GetComponent<NoteView>().editor = currentTrack;
        this.transform.position = new Vector3(newPosition.x, newPosition.y, newPosition.z);
        CheckInput();
    }

    void CheckInput()
    {
        CheckMouseInput();
        ChangeIfLengthHasChanged();
        CheckIfNoteChanged();
        CheckForOctaveNumber();
        CheckForNoteLetter();

       
    }

    void CheckMouseInput()
    {
        if (Input.GetMouseButtonDown(0) && isBuilding)
        {
            AddNote(note);
        }
        if (Input.GetMouseButtonDown(1))
        {
            isBuilding = !isBuilding;
            firstTrain.SetActive(isBuilding);
        }
    }
    void ChangeIfLengthHasChanged()
    {
        Note note = new Note();
        note.length = 1;
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            note.note = "speed";
            AddNote(note);
        }

        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            note.note = "slow";
            AddNote(note);
        }
        ChangeLength((int)(Input.mouseScrollDelta.y * scale));
    }
    void CheckIfNoteChanged()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            note.AddSemitone();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            note.SubstractSemitone();
        }
    }

    void CheckForNoteLetter()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            note.SetNote("A");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            note.SetNote("B");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            note.SetNote("C");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            note.SetNote("D");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            note.SetNote("E");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            note.SetNote("F");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            note.SetNote("G");
        }
    }
    private void CheckForOctaveNumber()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            note.octave = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            note.octave = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            note.octave = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            note.octave = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            note.octave = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            note.octave = 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            note.octave = 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            note.octave = 8;
        }
    }
    void ChangeLength(int change)
    {
        if(change < -(cars.Count -1))
        {
            return;
        }
        
        if(change > 0)
        {
            note.length++;
            AddCar();
        }
        else if(change < 0)
        {
            note.length--;
            RemoveCar();
        }
    }

    void AddCar()
    {
        GameObject car = Instantiate(carPrefab, spawnPoint);
        car.transform.parent = firstTrain.transform;
        float x = car.transform.localPosition.x;
        float y = car.transform.localPosition.y;
        float z = (note.length -1)* 13;
        car.transform.localPosition = new Vector3(x, y, z);
        cars.Add(car);
    }
    void RemoveCar()
    {
        GameObject carToRemove = cars[cars.Count - 1];
        cars.Remove(carToRemove);
        Destroy(carToRemove);
    }
    void AddNote(Note noteToAdd)
    {
        Note duplicateNote = new Note(noteToAdd);
        currentTrack.AddNote(duplicateNote,firstTrain);
    }
}
