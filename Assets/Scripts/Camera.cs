using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {


    public Transform airPlaneView;
    public Transform playerView;
    public Transform playerGroundView;
    public Transform playerWinView;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    public GameObject target;
    public GameObject targetImage;
    public GameObject pistol;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    float transitionSpeed;
    float startTime;

    bool TransitionPlaneStart;
    bool TransitionPlaneEnd;
    int transitionStartDistance;

    bool TransitionPlayerStart;
    bool TransitionPlayerEnd;
    float playerTransitionStartDistance;

    // Use this for initialization
    void Start()
    {
        transitionSpeed = 1.5f;
        transform.position = airPlaneView.position;
        TransitionPlaneStart = false;
        TransitionPlaneEnd = false;
        transitionStartDistance = 400;

        TransitionPlayerStart = false;
        TransitionPlayerEnd = false;
        playerTransitionStartDistance = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Screen.pause)
            return;

        if (AirPlane.AirPlanePosition< transitionStartDistance)
            transform.position = airPlaneView.position;
        
        if (TransitionPlaneEnd && Player.playerHeightPosition >= playerTransitionStartDistance)
        {
            transform.position = playerView.position;
            transform.rotation = playerView.rotation;
        }

        if(!TransitionPlaneStart && AirPlane.AirPlanePosition >= transitionStartDistance)
        {
            startTime = Time.time;
            TransitionPlaneStart = true;
        }

        if(AirPlane.AirPlanePosition >= transitionStartDistance)
        {
            float x = Time.time - startTime;
                if (x > 3){
                TransitionPlaneEnd = true;
                }
        }

        if (!TransitionPlayerStart && Player.playerHeightPosition <= playerTransitionStartDistance && AirPlane.AirPlanePosition > transitionStartDistance + 600)
        {
            startTime = Time.time;
            TransitionPlayerStart = true;
        }

        if (Player.playerHeightPosition <= playerTransitionStartDistance && AirPlane.AirPlanePosition > transitionStartDistance + 600)
        {
            float x = Time.time - startTime;
            if (x > 3)
            {
                TransitionPlayerEnd = true;
            }
        }

        if (TransitionPlayerEnd && !(solider2Ctrl.dead && solider3Ctrl.dead))
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");
            target.SetActive(true);
            pistol.SetActive(true);

            targetImage.transform.position = Input.mousePosition;

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }

        if(solider2Ctrl.dead && solider3Ctrl.dead)
        {
            target.SetActive(false);
            pistol.SetActive(false);
        }


    }

    void LateUpdate(){

        if (Screen.pause)
            return;

        if (AirPlane.AirPlanePosition > transitionStartDistance && !TransitionPlaneEnd)
        {
            transform.position = Vector3.Lerp(transform.position, playerView.position, Time.deltaTime * transitionSpeed);


            Vector3 currentAngle = new Vector3(
                Mathf.LerpAngle(transform.rotation.eulerAngles.x, playerView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
                Mathf.LerpAngle(transform.rotation.eulerAngles.y, playerView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
                Mathf.LerpAngle(transform.rotation.eulerAngles.z, playerView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

            transform.eulerAngles = currentAngle;
        }

        if (AirPlane.AirPlanePosition > transitionStartDistance+600 && Player.playerHeightPosition <= playerTransitionStartDistance && !TransitionPlayerEnd)
        {
            transform.position = Vector3.Lerp(transform.position, playerGroundView.position, Time.deltaTime * transitionSpeed);


            Vector3 currentAngle = new Vector3(
                Mathf.LerpAngle(transform.rotation.eulerAngles.x, playerGroundView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
                Mathf.LerpAngle(transform.rotation.eulerAngles.y, playerGroundView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
                Mathf.LerpAngle(transform.rotation.eulerAngles.z, playerGroundView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

            transform.eulerAngles = currentAngle;
        }

        if (solider2Ctrl.dead && solider3Ctrl.dead)

        {
            transform.position = Vector3.Lerp(transform.position, playerWinView.position, Time.deltaTime * transitionSpeed);


            Vector3 currentAngle = new Vector3(
                Mathf.LerpAngle(transform.rotation.eulerAngles.x, playerWinView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed*0.5f),
                Mathf.LerpAngle(transform.rotation.eulerAngles.y, playerWinView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed*0.5f),
                Mathf.LerpAngle(transform.rotation.eulerAngles.z, playerWinView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed*0.5f));

            transform.eulerAngles = currentAngle;

        }
    }


}
