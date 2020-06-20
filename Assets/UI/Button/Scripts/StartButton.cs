using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    CameraControler camera;
    forwardMovment fm;
    public Transform target;

    void Start()
    {
        fm = this.gameObject.GetComponent<forwardMovment>();
    }
    void OnMouseDown()
    {
        Player.started = true;
        camera.target = target;
        fm.enabled = true;
    }
}
