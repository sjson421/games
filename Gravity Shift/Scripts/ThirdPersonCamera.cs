using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

	public GameObject target;
	public GameObject lookAt;
	public float rotateSpeed = 5;
	Vector3 offsetTarget;
	Vector3 offsetLookAt;

	void Start() 
	{
		offsetTarget = target.transform.position - transform.position;
		offsetLookAt = lookAt.transform.position - transform.position;
	}

	void LateUpdate() 
	{
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		float vertical = -Input.GetAxis("Mouse Y") * rotateSpeed;

		target.transform.Rotate(0, horizontal, 0);
		lookAt.transform.Rotate (vertical, 0, 0);
	}
}