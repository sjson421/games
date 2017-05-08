using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Jae Son

//Moves player along with Moving Platforms
public class CheckMovingCollision : MonoBehaviour {

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "MovingPlatform") 
		{
			transform.parent = other.transform;
		}
	}
	void OnCollisionExit(Collision other)
	{
		if (other.transform.tag == "MovingPlatform") 
		{
			transform.parent = null;
		}
	}
}
