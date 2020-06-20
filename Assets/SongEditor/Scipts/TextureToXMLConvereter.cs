using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureToXMLConvereter : MonoBehaviour
{
    XMLManager xMLManager = new XMLManager();
    TextureReader textureReader;
    [SerializeField]
    string title= "Kalinka";
    [SerializeField]
    Texture2D texture;
    // Start is called before the first frame update
    void Start()
    {
        textureReader = new TextureReader(texture, title);
        Song song = textureReader.ReadFromTexture();
        xMLManager.SaveSong(song);
        
    }
}
