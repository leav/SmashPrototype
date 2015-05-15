using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 1;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (horizontal, 0, vertical);

		rb.AddForce (movement * speed,  ForceMode.Force);
	}
}
