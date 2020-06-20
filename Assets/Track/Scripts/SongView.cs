using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Beats
{
    public class SongView : MonoBehaviour
    {
        [SerializeField]
        public string title;
        [SerializeField]
        TextAsset textAsset;
        [SerializeField]
        TrackView red, green, blue;

        XMLManager xML;

        

        Note redNote = null, greenNote = null, blueNote = null;
        // Start is called before the first frame update
        void Awake()
        {
            xML = new XMLManager(); 
        }

        void GenerateSong()
        {
            ReadFromXML();
        }

        void ReadFromXML()
        {
            StringReader xml = xml = new StringReader(textAsset.text);

            var serializer = new XmlSerializer(typeof(Song));

            Song song = serializer.Deserialize(xml) as Song;
            //Song song = xML.LoadSong(title);
            UI.Points.maxPoints = song.GetMaxPoints();
            Debug.Log("Basic speed");
            Player.SetBasicSpeed(song.basicSpeed);
            Debug.Log(Player.songSpeed + "Song speed");
            red.AddTrack(song.tracks[0]);
            green.AddTrack(song.tracks[1]);
            //blue.AddTrack(song.tracks[2]);
        }

     

        void AddWhiteSpace()
        {
            Note blank = new Note();
            blank.length = 16;
            red.notes.Add(blank);
            green.notes.Add(blank);
            blue.notes.Add(blank);
        }



        public void Reset()
        {
            ResetTracks();
            Player.Reset();
            AddWhiteSpace();
            GenerateSong();
            InitTrakcs();
        }

        void ResetTracks()
        {
            red.Reset();
            green.Reset();
            blue.Reset();
        }

        void InitTrakcs()
        {
            red.Init();
            green.Init();
            blue.Init();
        }

        public void ChangeSong(TextAsset songDocument)
        {
            textAsset = songDocument;
            Reset();
        }
    }

}
