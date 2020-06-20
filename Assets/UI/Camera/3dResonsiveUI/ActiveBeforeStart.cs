using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBeforeStart : MonoBehaviour
{
    public bool activeBeforeStart = true;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target.SetActive(activeBeforeStart != Player.started);
    }
}
