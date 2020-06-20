using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beats;

public class ChooseSongButton : MonoBehaviour
{
    [SerializeField]
    SongView songView;
    [SerializeField]
    TextAsset songDocument;

    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if (Player.isActive && Player.camera.IsCloseEnoug())
        {
            Player.camera.ResetPosition();
            Player.started = true;
            songView.ChangeSong(songDocument);
        }

    }
}
