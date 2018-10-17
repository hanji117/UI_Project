﻿//Youtube
//Creating a Start Menu in Unity 5
//The sub menu will exit once it's built. but right now it doesn't work
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;//brackey-whenever you want to load to another scene 
//Side note I created this main menu following a fog spooky tutorial. There is more than 1
//way to create a main menu.

public class MenuScript : MonoBehaviour 
{

	public Canvas quitMenu;
	public Button startText;
	public Button exitText;


	// Use this for initialization
	void Start () 
	{
		quitMenu = quitMenu.GetComponent <Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;

	}

	public void ExitPress()
	{
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;

	}

	public void NoPress()
	{
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;

	}

	public void StartLevel()
	{
		SceneManager.LoadScene("Character Selection");
	}

	public void ExitGame()
	{
		Debug.Log("QUIT!");
		Application.Quit();
	}
}