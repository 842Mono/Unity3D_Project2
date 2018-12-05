using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solider2Ctrl : MonoBehaviour {

    public Animator enemy3Animator;
    public static bool dead;

    public AudioSource dead1Sound;

    // Use this for initialization
    void Start () {
        dead = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Screen.pause)
            return;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }

	}



    void OnMouseDown()
    {

        if (Screen.pause)
            return;

        enemy3Animator.SetBool("dead", true);
        dead1Sound.Play();
        dead = true;

    }
}
