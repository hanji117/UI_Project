using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour {

	public Animator anim;
	public Rigidbody rbody;

	private bool run;
	private float inputH;
	private float inputV;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();//for the animator to show up
		//in the inspector for unityChan.
		rbody = GetComponent<Rigidbody>();
		run = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown ("1")) {
			anim.Play ("001", -1, 0f);
		}
		if (Input.GetKeyDown ("2")) {
			//print ("I pressed 1");
			anim.Play ("a_runFixed", -1, 0f);//-1 is for base(first) layer.
		}//0f (beginning)how far the animation starts playing at. If it was 0.5f it 
		//would start halfway on the animation clip. Goes from 0f-1f.

		if (Input.GetKeyDown ("3")) {
			anim.Play ("a_slash", -1, 0f);
		}
		if (Input.GetKeyDown ("4")) {
			anim.Play ("a_spinning_sword_attack", -1, 0f);
		}

		if (Input.GetMouseButtonDown (0)) {//0 left mouse Button, 1 right mouse Button, 2 middle mouse Button
			int n = Random.Range (0, 2);//starting from 0. 2 numbers. 0 or 1. Random

			if (n == 0) {
				anim.Play ("a_spellCast", -1, 0f);
			} else {
				anim.Play ("a_staffCast", -1, 0f);
			}


		}

		if (Input.GetKey (KeyCode.LeftShift)) 
		{
			run = true;
		} else
		{
			run = false;
		}

		if (Input.GetKey (KeyCode.Space)) { //if we press the space bar
			anim.SetBool ("jump", true);
		} 
		else 
		{
			anim.SetBool ("jump", false);
		}

		inputH = Input.GetAxis ("Horizontal");
		inputV = Input.GetAxis ("Vertical");

		anim.SetFloat ("inputH", inputH);//inputH in quotes is the inputH from parameter in the Animator tab.
		//The float number from the Animator tab is the 2nd parameter here (inputH w/o the "")
		anim.SetFloat ("inputV", inputV);//
		anim.SetBool ("run", run);
		float moveX = inputH * 20f * Time.deltaTime;
		float moveZ = inputV * 50f * Time.deltaTime;

		if (moveZ <= 0f) { //if we're moving backwards we do that stuff
			moveX = 0f;
		} else if (run) 
		{
			moveX *= 5f;
			moveZ *= 5f;
		}

		rbody.velocity = new Vector3 (moveX, 0f, moveZ);
	}
}
