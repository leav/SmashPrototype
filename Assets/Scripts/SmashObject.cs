using UnityEngine;
using System.Collections;

public class SmashObject : MonoBehaviour {

	public float moveDistance = 10;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	public float getMaxStartingSpeed () {
		return Mathf.Sqrt (2 * rb.drag * moveDistance);
	}
}
