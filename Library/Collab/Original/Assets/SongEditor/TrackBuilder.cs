using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBuilder : MonoBehaviour
{
    public TrackAdjuster trackAdjuster;
    public GameObject trackPrefab;
    public KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTrack()
    {
        GameObject trackObject = Instantiate(trackPrefab);
        trackObject.GetComponent<TrackEditor>().SetTrack(key);
        trackAdjuster.tracks.Add(trackObject.GetComponent<ObjectKeeper>());

    }
}
