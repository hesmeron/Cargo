using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraPositionButton : MonoBehaviour
{
    [SerializeField]
    CameraControler camera;
    public Transform target;


    void OnMouseDown()
    {
        if (Player.isActive)
        {
            camera.target = target;
        }

    }
}
