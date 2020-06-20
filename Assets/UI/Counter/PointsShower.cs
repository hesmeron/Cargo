using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsShower : MonoBehaviour
{
    public Counter c;

    void Update()
    {
        c.number = UI.Points.points; 
    }
}
