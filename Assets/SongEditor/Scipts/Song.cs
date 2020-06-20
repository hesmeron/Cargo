using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beats;

[System.Serializable]
public class Song
{
    public string title = "Kalinka";
    public List<Track> tracks = new List<Track>();
    public float basicSpeed = 2f;
    //public List<SpeedChanger> speedChangers = new List<SpeedChanger>();
    public Song()
    {

    }
    public Song (Song song)
    {
        this.title = song.title;
    }

    public Song(string title, int numberOfTracks)
    {
        this.title = title;
        for (int i = 0; i < 3; i++)
        {
            tracks.Add(new Track());
        }
    }

    public int GetMaxPoints()
    {
        int points = 0;
        List<Note> notes = new List<Note>();
        foreach(var t in tracks)
        {
            int mulipilier = 1;
            foreach (var n in t.notes)
            {
                points += (5 + n.length) * mulipilier;
                if(n.note != "0"){
                    mulipilier++;
                }
            }
            points++;
        }
        Debug.Log("Max:" + points);
        return points / 2;
    }

}
