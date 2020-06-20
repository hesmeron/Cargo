using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class XMLManager
{
    public SongEntry songEntry;


    public void SaveSong(Song song)
    {
        XmlSerializer xmlSerilizer = new XmlSerializer(typeof(Song));
        string filename = Application.dataPath + "/XMLLibrary/" + song.title + ".xml";
        var encoding = Encoding.GetEncoding("UTF-8");

        using (StreamWriter stream = new StreamWriter(filename, false, encoding))
        {
            xmlSerilizer.Serialize(stream, song);
            stream.Close();
        }

        Debug.Log(song.title + " " + song.tracks.Count);

       
    }
    public Song LoadSong(string title)
    {
        Song song= new Song();
        string path = Application.dataPath + "/XMLLibrary/" + title + ".xml";
        song.title = title;
        if (File.Exists(path))
        {
            XmlSerializer xmlSerilizer = new XmlSerializer(typeof(Song));
            FileStream stream = new FileStream(path, FileMode.Open);
            song = (Song)xmlSerilizer.Deserialize(stream);
            stream.Close();
        }
        return song;
    }
}
[System.Serializable]
public class NoteEntry
{
    public string note;
    public int octave;
    public int length;
    public int semitoneNumber;
}
[System.Serializable]
public class TrackEntry
{
    public List<NoteEntry> noteEntries = new List<NoteEntry>();
}
[System.Serializable]
public class SongEntry {
    public string title = "Kalinka";
    public List<TrackEntry> trackEntries = new List<TrackEntry>();
    
    public SongEntry()
    {

    }
    public SongEntry(Song song)
    {
        title = song.title;
    }
}
[System.Serializable]
public class SongDatabase
{
    public List<SongEntry> songEntries = new List<SongEntry>();
}






