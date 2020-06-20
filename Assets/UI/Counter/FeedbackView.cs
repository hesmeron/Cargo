using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackView : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        Player.feedbackView = this;
    }
    public void ShowPlus()
    {
        Instantiate(prefab, this.transform);
    }
}
