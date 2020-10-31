using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
   
	[Header("Settings")]
	public float speed = 5f;
	public float rotateSpeed = 70f;
	public CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	//public var velocidade = 30;

	void Awake()
	{
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		
		if (controller.isGrounded && Input.GetButton("Jump"))
		{
			moveDirection.y = jumpSpeed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		if (Input.GetKey(KeyCode.Q))
		{
			transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.E))
		{
			transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
		}

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		if (Input.GetKey(KeyCode.LeftShift))
		{
			speed = 13f;
		}
		Vector3 forward = transform.forward * v * speed * Time.deltaTime;
		Vector3 right = transform.right * h * speed * Time.deltaTime;
		speed = 5f;
		controller.Move(forward + right);
	}
}
