using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{
    public List<GameObject> numbers = new List<GameObject>();
    public int number = 0;

    public void Update()
    {
        foreach(var n in numbers)
        {
            n.SetActive(false);
        }
        if(number >= 0)
        {
            numbers[number].SetActive(true);
        }
        
    }
}
