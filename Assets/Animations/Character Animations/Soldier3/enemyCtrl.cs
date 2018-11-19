using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCtrl : MonoBehaviour
{
	public Animator walkAnimator;
	public Animator positionAnimator;
	// public callbackScript script;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		Debug.Log("enemy clicked.");
		Vector3 elTarget = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z);
		Debug.Log(elTarget);
		enemy.transform.position = elTarget;
		walkAnimator.SetBool("dead", true);
		// positionAnimator.SetBool("dead", true);
		positionAnimator.speed = 0;
		// this.transform.position.Set(currentPos.x, currentPos.y, currentPos.z);
		// Debug.Log(currentPos);
	}
}
