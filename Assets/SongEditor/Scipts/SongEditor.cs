using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SongEditor {
    public class SongEditor:MonoBehaviour
    {
        public Song song;
        XMLManager xMLManager;
        public float basicSpeed = 2f;
        [SerializeField]
        TrackBuilder trackBuilder;
        public List<TrackEditor> trackEditors = new List<TrackEditor>();
        // Start is called before the first frame update
        void Start()
        {
            xMLManager = new XMLManager();
            Load();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }
        }
        void Save()
        {
            song = new Song(song);
            foreach(var t in trackEditors)
            {
                t.PrepareToSave();
                song.tracks.Add(t.track);
            }
            song.basicSpeed = basicSpeed;
            xMLManager.SaveSong(song);
            Debug.Log("Save");


        }

        void Load()
        {
            song = xMLManager.LoadSong(song.title);
            CleanSong();
            LoadTracks();

        }

        void LoadTracks()
        {
            foreach (var t in song.tracks)
            {
                TrackEditor trackEditor = trackBuilder.AddTrack();
                trackEditor.LoadTrack(t);
            }
        }
        void CleanSong()
        {
            foreach (var t in trackEditors)
            {
                Destroy(t);
            }
            trackEditors.Clear();
        }


    }

}

