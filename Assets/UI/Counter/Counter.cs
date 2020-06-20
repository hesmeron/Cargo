using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public List<Number> numbers = new List<Number>();
    [SerializeField]
    bool invisibleZero = false;
    public int number;
    
    public bool wasAlreadyX;

    void Update()
    {
        if (invisibleZero) { 
            TextFromString();
        }
        else
        {
            CalculateText();
        }
    }

    void CalculateText()
    {
        numbers[0].number = number % 10;
        for (int i = 1; i < numbers.Count; i++)
        {
            int newNumber = number % (int)Mathf.Pow(10f, i + 1) / (int)(Mathf.Pow(10f, i));

            if (newNumber == 0 && invisibleZero)
            {
                if (!wasAlreadyX)
                {
                    wasAlreadyX = true;
                    newNumber = 10;
                }
                else
                {
                    newNumber = -1;
                }

            }
            else if (wasAlreadyX)
            {
                numbers[i - 1].number = 0;
            }
            numbers[i].number = newNumber;
        }
    }

    void TextFromString()
    {
        wasAlreadyX = false;
        string numberText = number.ToString();
        int j = 1, newNumber = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            if (j <= numberText.Length)
            {
                char c = numberText[numberText.Length - j];
                Debug.Log("Char" + c);
                newNumber = (int)c - 48;
                j++;
            }

            else if (invisibleZero)
            {
                if (!wasAlreadyX)
                {
                    wasAlreadyX = true;
                    newNumber = 10;
                }
                else
                {
                    newNumber = -1;
                }

            }


            numbers[i].number = newNumber;
        }
    }
    
}
