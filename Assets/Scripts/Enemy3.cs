using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour {

    // Use this for initialization


    float speed;
    float startTime;
    float rotationTime;
    bool startRotation;

	void Start () {
        speed = 0.015f;
        startRotation = false;
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {


        if (Screen.pause)
            return;

        if (!solider3Ctrl.dead)
        {

            if (!startRotation)
                transform.Translate(0, 0, speed);


            float x = Time.time - startTime;
            if (x > 7)
            {
                startTime = Time.time;
                startRotation = true;
                rotationTime = Time.time;
            }

            if (startRotation)
            {
                float y = Time.time - rotationTime;
                transform.Rotate(0, 1.5f, 0);
                if (y > 2)
                {
                    startRotation = false;
                }

            }

        }
	}
}
