using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
   
	[Header("Settings")]
	public float speed = 10f;
	public float rotateSpeed = 70f;
	public CharacterController controller;
	//public var velocidade = 30;

	void Awake()
	{
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Q))
		{
			transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
			return;
		}

		if (Input.GetKey(KeyCode.E))
		{
			transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
			return;
		}
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 forward = transform.forward * v * speed * Time.deltaTime;
		Vector3 right = transform.right * h * speed * Time.deltaTime;

		controller.Move(forward + right);
	}
}
