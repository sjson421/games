using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	public GameObject player = new GameObject();

	void Update () {
		if (player.transform.position.x >= transform.position.x - 1  && player.transform.position.x <= transform.position.x + 1 && 
            player.transform.position.y >= transform.position.y - 2  && player.transform.position.y <= transform.position.y + 2 &&
            player.transform.position.z >= transform.position.z-.5 && player.transform.position.z <= transform.position.z + .5) {

			Vector3 temp = Physics.gravity;
			temp.y = -9.81f;
			Physics.gravity = temp;
			SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex+1);
		}
	}
}
	