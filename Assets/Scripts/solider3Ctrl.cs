using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solider3Ctrl : MonoBehaviour
{
	public Animator enemy2Animator;
    public static bool dead;

    public AudioSource dead2Sound;
    // Use this for initialization
    void Start () {
        dead = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{

        if (Screen.pause)
            return;

        enemy2Animator.SetBool("dead", true);
        dead2Sound.Play();
        dead = true;

    }
}
