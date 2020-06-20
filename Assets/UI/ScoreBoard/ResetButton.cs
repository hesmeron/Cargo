using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beats;

public class ResetButton : MonoBehaviour
{
    SongView songView;
    // Start is called before the first frame update
    void Start()
    {
        songView = FindObjectOfType<SongView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("Reset");
        songView.Reset();
    }
}
