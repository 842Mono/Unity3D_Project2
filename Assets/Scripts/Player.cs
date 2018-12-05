using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float speedY;
    public GameObject parachut;
    public Animator animator;


    public GameObject mainCamera;
    public GameObject playerCamera;

    public static float playerHeightPosition;

	// Use this for initialization
	void Start () {
        speedY = 0;
        mainCamera.SetActive(false);
        playerCamera.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {

        if (Screen.pause)
            return;

        if (transform.position.y > 3.5)
        {
            if (transform.position.y > 180)
                moveDown();
            else
                moveDownParachut();

        }
        else{
            parachut.SetActive(false);
            playerCamera.SetActive(false);
            mainCamera.SetActive(true);
            animator.SetBool("idle", true);
        }

        if (transform.position.y < 200)
        {
            parachut.SetActive(true);
        }

        if (transform.position.y < 280)
        {
            animator.SetBool("Hanging", true);
        }

        playerHeightPosition = transform.position.y;

    }

    void moveDown()
    {
        speedY = speedY - 0.2f;
        transform.Translate(0, Time.deltaTime* speedY,0);
    }

    void moveDownParachut()
    {
        transform.Translate(0, Time.deltaTime * speedY * 0.25f, 0);
    }
}
