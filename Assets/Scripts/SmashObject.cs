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
		return Mathf.Sqrt (2.0f * 9.81f * 0.8f * moveDistance);
	}

	public float getInitialSpeed(float dist) {
		return Mathf.Sqrt (2.0f * 9.81f * 0.8f * dist);
	}
}
