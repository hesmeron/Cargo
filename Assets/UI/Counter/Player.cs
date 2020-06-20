using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player  {
    static public int points = 0;
    static public int multiplier = 1;
    static public bool isActive = false;
    public static bool started = false;
    public static bool isCommissarEnabled = false;
    public static bool hasSongEnded = false;
    public static float songSpeed = 2;
    public static float basicSpeed = 2;
    public static float speedChange = 0.5f;
    public static Animator uiAnimator;
    public static SlowDownEffect slow, fast;
    public static bool isBuilding = false;
    public static CameraControler camera;
    public static FeedbackView feedbackView;
    public static void Reset()
    {
        multiplier = 1;
        UI.Points.points = 0;
        UI.Points.maxPoints = 0;
        songSpeed = basicSpeed;
    }
    public static void SetBasicSpeed(float speed)
    {
        basicSpeed = speed;
        songSpeed = speed;
    }
    public static void SpeedUp()
    {
        songSpeed += speedChange;
        Player.multiplier += 10;
    }
    public static void SlowDown()
    {
        Player.multiplier += 10;
        songSpeed -= speedChange;
        if(songSpeed < basicSpeed)
        {
            songSpeed = basicSpeed;
        }
    }
    public static void TakePunishment()
    {
        Player.multiplier = Player.multiplier / 2;
        Player.songSpeed = basicSpeed;
    }

    // Use this for initialization

}
