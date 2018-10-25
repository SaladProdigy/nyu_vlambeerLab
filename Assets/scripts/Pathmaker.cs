using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// MAZE PROC GEN LAB
// all students: complete steps 1-6, as listed in this file
// optional: if you have extra time, complete the "extra tasks" to do at the very bottom

// STEP 1: ======================================================================================

//USAGE:put this script on a Sphere
//INTENT: it will move around, and drop a path of floor tiles behind it
public class Pathmaker : MonoBehaviour {

// STEP 2: ============================================================================================
// translate the pseudocode below

//	DECLARE CLASS MEMBER VARIABLES:

	private int Counter = 0;
	public Transform floorPrefab;
	public Transform pathmakerSpherePrefab;
	public int tileLimit;
	
	// you'll have to make a "pathmakerSphere" prefab later


	void Update () {

		
		
		float randomNumber = Random.Range(0.0f, 5f);
		
		Debug.Log("Generated Random Number");

		if (Counter < 150f)
		{
				
			if (randomNumber < 1f)
			{
				transform.Rotate(0f, 90f, 0f);
				
				Debug.Log("1");
			}
			else if (1f < randomNumber && randomNumber > 3f)
			{
				transform.Rotate(0f, -90f, 0f);
				
				Debug.Log("2");
			}
			else if (4f < randomNumber && randomNumber > 5f)
			{
				Instantiate(pathmakerSpherePrefab, this.transform.position , pathmakerSpherePrefab.rotation);
				
				Debug.Log("Instantiate Here");
				
			}
			
			Instantiate(floorPrefab, this.transform.position , floorPrefab.rotation);
			
			tileLimit++;

			transform.Translate(5f, 0f, 0f);

			Counter++;
		}
		else
		{
			Destroy(this);
		}

		if (tileLimit == 500)
		{
			Destroy(this);
		}

	}


} 

// STEP 5: ===================================================================================
// maybe randomize it even more?

// - randomize 2 more variables in Pathmaker.cs for each different Pathmaker... you would do this in Start()
// - maybe randomize each pathmaker's lifetime? maybe randomize the probability it will turn right? etc. if there's any number in your code, you can randomize it if you move it into a variable



// STEP 6:  =====================================================================================
// art pass, usability pass

// - move the game camera to a position high in the world, and then point it down, so we can see your world get generated
// - CHANGE THE DEFAULT UNITY COLORS, PLEASE, I'M BEGGING YOU
// - add more detail to your original floorTile placeholder -- and let it randomly pick one of 3 different floorTile models, etc. so for example, it could randomly pick a "normal" floor tile, or a cactus, or a rock, or a skull
//		- MODEL 3 DIFFERENT TILES IN MAYA! DON'T STOP USING MAYA OR YOU'LL FORGET IT ALL
//		- add a simple in-game restart button; let us press [R] to reload the scene and see a new level generation
// - with Text UI, name your proc generation system ("AwesomeGen", "RobertGen", etc.) and display Text UI that tells us we can press [R]



// OPTIONAL EXTRA TASKS TO DO, IF YOU WANT: ===================================================

// DYNAMIC CAMERA:
// position the camera to center itself based on your generated world...
// 1. keep a list of all your spawned tiles
// 2. then calculate the average position of all of them (use a for() loop to go through the whole list) 
// 3. then move your camera to that averaged center and make sure fieldOfView is wide enough?

// BETTER UI:
// learn how to use UI Sliders (https://unity3d.com/learn/tutorials/topics/user-interface-ui/ui-slider) 
// let us tweak various parameters and settings of our tech demo
// let us click a UI Button to reload the scene, so we don't even need the keyboard anymore!

// WALL GENERATION
// add a "wall pass" to your proc gen after it generates all the floors
// 1. raycast downwards around each floor tile (that'd be 8 raycasts per floor tile, in a square "ring" around each tile?)
// 2. if the raycast "fails" that means there's empty void there, so then instantiate a Wall tile prefab
// 3. ... repeat until walls surround your entire floorplan
// (technically, you will end up raycasting the same spot over and over... but the "proper" way to do this would involve keeping more lists and arrays to track all this data)
