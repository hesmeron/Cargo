using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Mouse
{

    public static LayerMask mask = 11;
    public static Vector3 MouseWorldPosition()
    {
        Vector3 mousePosition = -Vector3.one;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 10000f, 9))
        {
            mousePosition = hit.point;
        }
        return mousePosition;
    }
}
