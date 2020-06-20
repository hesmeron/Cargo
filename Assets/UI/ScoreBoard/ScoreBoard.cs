using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    Animator counterAnim;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("hasEnded", Player.hasSongEnded);
        counterAnim.SetBool("down", Player.hasSongEnded);
    }

    public void ShowScore()
    {
        counterAnim.SetBool("down", true);
    }
}
