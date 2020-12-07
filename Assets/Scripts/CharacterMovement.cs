 using JetBrains.Annotations;
using Photon.Pun;
using System.Collections.Specialized;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	private PhotonView PV;
	private CharacterController myCC;

	//[Header("Settings")]
	private float speed;
	private float moveSpeed = 13f;
	private float sprintSpeed = 23f;
	private float rotateSpeed = 280f;
	private Vector3 moveDirection = Vector3.zero;
	private float jumpSpeed = 30.0F;
	private float gravity = 50.0F;
	private float maxVelocity = 200f;
	//public var velocidade = 30;

	Vector3 syncPos = Vector3.zero;
	Quaternion syncRot = Quaternion.identity;

    private void Start()
    {
		PV = GetComponent<PhotonView>();
		if (PV.IsMine){
			GetComponentInChildren<Camera>().enabled = true;
			GetComponentInChildren<AudioListener>().enabled = true;
		}
		myCC = GetComponent<CharacterController>();
    }
	
	void BasicMovement()
    {
		if (!PhotonChatManager.typing)
		{
			if (myCC.isGrounded && Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
			if (myCC.isGrounded && moveDirection.y < 0)
			{
				moveDirection.y = 0;
			}
			else
			{
				moveDirection.y -= gravity * Time.deltaTime;
			}
			myCC.Move(moveDirection * Time.deltaTime);
			if (Input.GetKey(KeyCode.W))
			{
				myCC.Move(transform.forward * Time.deltaTime * speed);
			}
			if (Input.GetKey(KeyCode.A))
			{
				myCC.Move(-transform.right * Time.deltaTime * speed);
			}
			if (Input.GetKey(KeyCode.S))
			{
				myCC.Move(-transform.forward * Time.deltaTime * speed);
			}
			if (Input.GetKey(KeyCode.D))
			{
				myCC.Move(transform.right * Time.deltaTime * speed);
			} 
		}
	}

	void BasicRotation()
	{
		if (!PhotonChatManager.typing)
		{
			if (Input.GetKey(KeyCode.Q))
			{
				transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
			}

			if (Input.GetKey(KeyCode.E))
			{
				transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
			}
		}
	}


	void Update()
	{
		if (!PhotonChatManager.typing)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				speed = sprintSpeed;
			}
			else
			{
				speed = moveSpeed;
			}
			if (PV.IsMine)
			{
				BasicMovement();
				BasicRotation();
			}
		}
	}

		/* depricated of UPDATE
		if (enabled) { 
			if (controller.isGrounded && Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
			moveDirection.y -= gravity * Time.deltaTime;
			if (enabled) { }
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
			controller.Move(forward);
			controller.Move(right);
		}
		//else
			//photonView.RPC("posChangeRPC", photonView.Owner, forward + right);
	}
	*/

	/* DEPRICATED
	 * Im using Photon Transform View instead of sending RPCs
	[PunRPC]
	public void posChangeRPC(Vector3 posChange)
    {
		transform.position += posChange;
    }
	*/
}
