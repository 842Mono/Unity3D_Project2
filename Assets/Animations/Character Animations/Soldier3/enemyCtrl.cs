using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCtrl : MonoBehaviour
{
	public Animator walkAnimator;
	public Animator positionAnimator;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		Debug.Log("enemy clicked.");
		Vector3 currentPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		Debug.Log(currentPos);
		walkAnimator.SetBool("dead", true);
		positionAnimator.SetBool("dead", true);
		this.transform.position.Set(currentPos.x, currentPos.y, currentPos.z);
		Debug.Log(currentPos);
	}
}
