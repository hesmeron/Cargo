using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SongEditor;
using Beats;

public class TrackBuilder : MonoBehaviour
{
    public TrackAdjuster trackAdjuster;
    public GameObject trackPrefab;
    public SongEditor.SongEditor songEditor;
    public KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
        songEditor = FindObjectOfType<SongEditor.SongEditor>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public TrackEditor AddTrack()
    {
        GameObject trackObject = Instantiate(trackPrefab);
        trackObject.GetComponent<TrackView>().isInEditing = true;
        TrackEditor trackEditor = trackObject.GetComponent<TrackEditor>();
        trackEditor.SetTrack(key);
        trackAdjuster.tracks.Add(trackObject.GetComponent<ObjectKeeper>());
        songEditor.trackEditors.Add(trackEditor);
        return trackEditor;

    }

    public void AddTrackThroughUI()
    {
        AddTrack();
    }

}
