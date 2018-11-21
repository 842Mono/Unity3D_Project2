using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlane : MonoBehaviour {

    // Use this for initialization

    float speed;
    public static float AirPlanePosition;
    public GameObject player;

    void Start () {
        speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        speed = speed + 0.2f;
        transform.Translate(0, 0, Time.deltaTime*speed);
        AirPlanePosition=transform.position.z;

        if (AirPlanePosition > 700)
        {
            player.SetActive(true);
        }

        if (AirPlanePosition > 1500)
            speed = 0;
    }
}
