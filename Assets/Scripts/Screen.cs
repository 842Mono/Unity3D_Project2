using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screen : MonoBehaviour {

    // Use this for initialization


    public Animator airPlane;
    public Animator player;
    public Animator solider2;
    public Animator solider3;
    public Animator parachut;

    public AudioSource gameSound;

    public GameObject pauseButton;
    public GameObject pauseMenu;

    public static bool pause;


	void Start () {
       gameSound.Play();
        pause = false;
	}
	
	// Update is called once per frame
	void Update () {

        if(solider2Ctrl.dead && solider3Ctrl.dead)
        {
            player.SetBool("enemyDead", true);

        }


	}

    public void onPause()
    {
        pause = !pause;

        if (pause)
        {
            pauseMenu.SetActive(true);
            pauseButton.SetActive(false);
            player.enabled = false;
            airPlane.enabled = false;
            solider2.enabled = false;
            solider3.enabled = false;
            parachut.enabled = false;
        }
        else
        {
            pauseMenu.SetActive(false);
            pauseButton.SetActive(true);
            player.enabled = true;
            airPlane.enabled = true;
            solider2.enabled = true;
            solider3.enabled = true;
            parachut.enabled = true;
        }
    }

    public void onQuit(){
        SceneManager.LoadScene("Main");
    }
}
