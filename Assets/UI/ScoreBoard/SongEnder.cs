using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beats;

public class SongEnder : MonoBehaviour
{
    public List<TrackView> tracks = new List<TrackView>();
    public ScoreBoard scoreBoard;
    // Start is called before the first frame update


    // Update is called once per frame
    void LateUpdate()
    {
        if (Player.started)
        {
            bool hasEnded = true;
            foreach(var t in tracks)
            {
                Debug.Log("Activation" + !t.gameObject.activeSelf);
                if (!t.hasEnded() && t.gameObject.activeSelf)
                {
                    hasEnded = false;
                }
            }
            Player.hasSongEnded = hasEnded;
            if (hasEnded)
            {
                scoreBoard.ShowScore();
            }
        }
    }

    public void ShowScore()
    {

    }
}
