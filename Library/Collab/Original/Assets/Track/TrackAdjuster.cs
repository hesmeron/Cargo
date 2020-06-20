using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackAdjuster : MonoBehaviour
{
    public List<ObjectKeeper> tracks = new List<ObjectKeeper>();

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<tracks.Count; i++)
        {
            float x = 0.1f + (0.8f /(float) (tracks.Count + 1)) * (i + 1);
            tracks[i].minX = x;
            tracks[i].maxX = x;
        }
    }
}
