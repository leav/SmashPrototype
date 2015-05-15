using UnityEngine;
using System.Collections;

public class SmashController : MonoBehaviour
{

	public int wsadForceSpeed = 100;
	public int layerSelectable = 8;
	public GameObject selected;
	public GameObject selectedDown;
	public Material selectedMaterial;
	public Material unselectedMaterial;
	public Vector3 posDown;
	public Vector3 posUp;

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			selectedDown = GetRaycastSelectable ();
			posDown = GetClickPos (selectedDown);
		} else if (Input.GetMouseButtonUp (0)) {
			posUp = GetClickPos (selectedDown);
			if (selected) { // already an object selected
				if (selected == selectedDown) {
					Debug.Log ("Smashing!");
				} else {
					ChangeMaterial (selected, unselectedMaterial);
					selected = selectedDown;
					ChangeMaterial (selected, selectedMaterial);
				}
			} else { // nothing selected yet
				GameObject selectedUp = GetRaycastSelectable ();
				if (selectedDown == selectedUp) {
					ChangeMaterial (selected, unselectedMaterial);
					selected = selectedDown;
					ChangeMaterial (selected, selectedMaterial);
				}
			}
		}
	}

	void FixedUpdate ()
	{
		if (selected) {
			Rigidbody rb = selected.GetComponent<Rigidbody> ();

			float horizontal = Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis ("Vertical");
		
			if (horizontal != 0 || vertical != 0) {
				Vector3 movement = new Vector3 (horizontal, 0, vertical);
				rb.AddForce (movement * wsadForceSpeed, ForceMode.Force);
			}
		}
	}

	GameObject GetRaycastSelectable ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;
		var layerMask = 1 << layerSelectable; // Selectable only
		if (Physics.Raycast (ray, out hitInfo, Mathf.Infinity, layerMask) && hitInfo.collider) {
			Debug.DrawLine (ray.origin, hitInfo.point);
			return hitInfo.collider.gameObject;
		}
		return null;
	}

	void ChangeMaterial (GameObject o, Material m)
	{
		if (o) {
			MeshRenderer renderer = o.GetComponent<MeshRenderer> ();
			renderer.material = m;
		}
	}

	Vector3 GetClickPos (GameObject o)
	{
		if (!o)
			return Vector3.zero;
		Plane objectPlane = new Plane (Vector3.up, o.transform.position);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float rayDistance;
		if (objectPlane.Raycast (ray, out rayDistance)) {
			return ray.GetPoint (rayDistance);
		}
		return Vector3.zero;
	}

}
