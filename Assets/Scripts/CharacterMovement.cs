using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
   
	[Header("Settings")]
	public float speed = 10f;
	public CharacterController controller;
	

	void Awake()
	{
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 forward = transform.forward * v * speed * Time.deltaTime;
		Vector3 right = transform.right * h * speed * Time.deltaTime;

		controller.Move(forward + right);
	}
}
