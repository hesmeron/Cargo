using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuliplierShower : MonoBehaviour
{
    public Counter c;

    void Update()
    {
        c.number = Player.multiplier;
    }
}
