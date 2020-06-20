using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beats;
public class TextureReader
{
    [SerializeField]
    string title;
    [SerializeField]
    Texture2D songTexture;
    [SerializeField]
    Track red, green, blue;
    [SerializeField]
    Song song;
    float currentTime = 8;
    float speed = 2;
    public float speedChange = 0.3f;


    bool wasRed, wasGreen, wasBlue, wasYellow, wasPurple;


    Note redNote = null, greenNote = null, blueNote = null;

    public TextureReader(Texture2D texture, string title)
    {
        this.songTexture = texture;
        this.title = title;
    }

    public Song ReadFromTexture()
    {
        song = new Song(title, 3);
        SetUpTracks();
        for (int y = 6; y <songTexture.height; y++)
        {
            CheckRow(y);
        }

        return song;
    }

    void SetUpTracks()
    {
        red = song.tracks[0];
        green = song.tracks[1];
        blue = song.tracks[2];
    }
    void CheckRow(int y)
    {
        ResetBools();
        for (int x = 0; x < songTexture.width; x++)
        {
            Debug.Log("Check");
            CheckPixel(x, y);
        }

        currentTime += 1 / (float)speed;
        if (wasYellow || wasPurple)
        {
            AddSpeedChanger();
        }
        AddWhiteSpace();
    }

    void AddSpeedChanger()
    {
        int choice = Random.Range(0, 3);
        Note newNote = new Note();
        newNote.length = 1;

        if (wasYellow)
        {
            newNote.note = "speed";
        }
        else
        {
            newNote.note = "slow";
        }

        if(choice == 0){
            red.notes.Add(newNote);
            wasRed = true;
        }
        if (choice == 1)
        {
            green.notes.Add(newNote);
            wasGreen = true;
        }
        if (choice == 2)
        {
            blue.notes.Add(newNote);
            wasBlue = true;
        }

    }
    void ResetBools()
    {
        wasRed = false;
        wasGreen = false;
        wasBlue = false;
        wasYellow = false;
        wasPurple = false;
    }
    void CheckPixel(int x, int y)
    {
        Color color = songTexture.GetPixel(x, y);
        CheckColor(color, new Color(1f, 0f, 0f), x, y);
        CheckColor(color, new Color(0, 1f, 0f), x, y);
        CheckColor(color, new Color(0, 0, 1f), x, y);
        CheckColor(color, new Color(0, 1f, 1f), x, y);
        CheckColor(color, new Color(1f, 0, 1f), x, y);

    }

    private void CheckColor(Color colorOfPixel, Color colorToCompare, int x, int y)
    {
        if (colorOfPixel == colorToCompare)
        {
            if (colorToCompare == new Color(1f, 0, 0))
            {
                if (wasRed)
                {
                    Debug.LogError(x + " " + y);
                }
                GeneratePixel(x, y, ref red, ref redNote, colorToCompare);
                wasRed = true;

            }
            if (colorToCompare == new Color(0, 1f, 0))
            {
                if (wasGreen)
                {
                    Debug.LogError(x + " " + y);
                }
                GeneratePixel(x, y, ref green, ref greenNote, colorToCompare);
                wasGreen = true;
            }
            if (colorToCompare == new Color(0, 0, 1f))
            {
                if (wasBlue)
                {
                    Debug.LogError(x + " " + y);
                }
                GeneratePixel(x, y, ref blue, ref blueNote, colorToCompare);
                wasBlue = true;
            }
            if (colorToCompare == new Color(0, 1f, 1f))
            {

                wasYellow = true;
            }
            if (colorToCompare == new Color(1f, 0, 1f))
            {

                wasPurple = true; ;
            }


        }
    }

    void GeneratePixel(int x, int y, ref Track track, ref Note note, Color color)
    {
        if (note == null)
        {
            note = new Note(x);
            Debug.Log("Generate note");

        }
        else
        {

            if (note.semitoneNumber == x - ((note.octave - 1) * 13) - 1)
            {
                note.length++;

            }
            else
            {
                track.notes.Add(note);
                UI.Points.maxPoints += note.length + 10;
                Debug.Log("Max points" + UI.Points.maxPoints);
                note = null;
            }


        }

        if ((songTexture.GetPixel(x, y + 1) == new Color(1, 1, 1) || songTexture.GetPixel(x, y + 1) != color) && note != null)
        {
            track.notes.Add(note);
            UI.Points.maxPoints += note.length + 10;
            note = null;
        }

    }

    void AddNote(Note note, TrackView track)
    {
        track.notes.Add(note);
        UI.Points.maxPoints += note.length + 10;
        note = null;
    }
    void AddWhiteSpace()
    {
        Note blank = new Note();
        blank.length = 1;
        if (!wasRed)
        {
            red.notes.Add(blank);
        }
        if (!wasGreen)
        {
            green.notes.Add(blank);
        }
        if (!wasBlue)
        {
            blue.notes.Add(blank);
        }
    }
}

