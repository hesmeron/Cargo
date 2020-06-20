using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI {
    public static class Points
    {
        public static int points = 0;
        public static int maxPoints = 0;
        public static int pointsMultiplier = 0;
        public static float completion()
        {
            Debug.Log(maxPoints);
            return (float)points / maxPoints;
        }
    }

}

