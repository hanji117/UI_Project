using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLuna : MonoBehaviour {

    private bool run;
    public Rigidbody rbody;
    private float inputH;//in the animator float parameter
    private float inputV;
	private Animator anim;// reference to the Animator tab in Unity.
	private CharacterController controller;//reference to the CharacterController tab
	//in unity.
	public float speed = 6.0f;//shows up in the inspector in Unity.
	public float turnspeed = 60.0f;//turn left to right
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;//gravity pull to the ground

	// Use this for initialization
	void Start () 
	{
       rbody = GetComponent<Rigidbody>();
       anim = gameObject.GetComponentInChildren<Animator> ();
       // anim = GetComponent<Animator> ();
       controller = GetComponent<CharacterController> (); //to move character around according to Darren Lile.
       run = false;
    }
	
	// Update is called once per frame
	void Update () 
	{
        
		//if (Input.GetKey ("up")) 
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S))
		{
			anim.SetInteger ("AnimPar", 1);
            //anim.SetBool("jump", true);
		} 
		else
		{
			anim.SetInteger ("AnimPar", 0);
		}

		if (controller.isGrounded) //will test to see if the character is on the ground.
		{
			moveDirection = transform.forward * Input.GetAxis ("Vertical") * speed;
		}
		
        /*
         Note: J and space for jump wouldn't work unless space was commented out
		if (Input.GetKey (KeyCode.J)) { //if we press J
			anim.SetBool ("jump", true);
		} 
		else 
		{
			anim.SetBool ("jump", false);

		}
        */

        /*
		if (Input.GetKey (KeyCode.F)|| Input.GetKeyDown ("1")|| Input.GetKeyDown ("2") ) { //if we press the F key, 1, or 2
			anim.SetBool ("cast spell attack", true);
		} 
		else 
		{
			anim.SetBool ("cast spell attack", false);

		}
		*/
        // Below from edPlayer script 
        if (Input.GetKeyDown("1"))
        {
            anim.Play("fallingBackAnimation", -1, 0f);
        } //-1 is the base layer where the animation is located. 0f is the start of the 
          //the animation 1f is the end

       // if (Input.GetKeyDown("2"))
       // {
            //print ("I pressed 1");
         //   anim.Play("jump00", -1, 0f);//-1 is for base(first) layer.
      //  }//0f (beginning)how far the animation starts playing at. If it was 0.5f it 
         //would start halfway on the animation clip. Goes from 0f-1f.

       
       

        if (Input.GetMouseButtonDown(0))
        {//0 left mouse Button, 1 right mouse Button, 2 middle mouse Button
            //int n = Random.Range(0, 2);//starting from 0. 2 numbers. 0 or 1. Random

            //if (n == 0)
            //{
            anim.Play("a_swordThrust", -1, 0f);
        }
        if (Input.GetMouseButtonDown(1))
        {
                anim.Play("a_spinning_sword_attack", -1, 0f);
        }

        if (Input.GetMouseButtonDown(2))
        {
            anim.Play("a_renewedSlash", -1, 0f);
        }

        //if (Input.GetKeyDown("E"))
        //This line of code (above) caused the character to not move and fall through the ground.
        if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("spinningKick", true);
        }
        else
        {
            anim.SetBool("spinningKick", false);
        }



        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }


        if (Input.GetKey(KeyCode.Space))
        { //if we press the space bar
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }

        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnspeed * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);//the controller 
        moveDirection.y -= gravity * Time.deltaTime;

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);//inputH in quotes is the inputH from parameter in the Animator tab.
                                        //The float number from the Animator tab is the 2nd parameter here (inputH w/o the "")
        anim.SetFloat("inputV", inputV);//

        anim.SetBool("run", run);

        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;

        if (moveZ <= 0f)
        { //if we're moving backwards we do that stuff
            moveX = 0f;
        }
        else if (run)
        {
            moveX *= 5f;
            moveZ *= 5f;
        }

        rbody.velocity = new Vector3(moveX, 0f, moveZ);
    

	}
}
