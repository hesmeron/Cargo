using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class Text3D : MonoBehaviour
    {
        [SerializeField]
        string text;
        [SerializeField]
        float characterSize;
        float currentXPosition, currentPositionY;
        [SerializeField]
        int maxLineLength;
        int currentLineLength;
        [SerializeField]
        List<GameObject> alphabet;
        List<GameObject> currentText;

    }

}
