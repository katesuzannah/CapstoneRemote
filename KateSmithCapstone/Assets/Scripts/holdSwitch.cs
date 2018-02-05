using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdSwitch : MonoBehaviour {

	public LayerMask myRaycastMask;
	GameObject currentlyHeld;
	Rigidbody currentRB;
	Collider[] currentColliders;

	void Start () {
	}

	void Update () {
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit rayHit = new RaycastHit ();

		//If you click
		if (Input.GetMouseButtonDown(0)) {
			//If you're currently holding something
			if (currentlyHeld != null) {
				//Drop it
				currentlyHeld.transform.SetParent (null);
				currentRB.isKinematic = false;
				currentlyHeld.GetComponent<rotateObject> ().enabled = false;
				currentRB.detectCollisions = true;
				foreach(Collider col in currentColliders) {
					col.enabled = true;
				}
			}
			//If the ray hits something on the layer mask
			if (Physics.Raycast (ray, out rayHit, 5f, myRaycastMask)) {
				if (rayHit.collider.tag == "Pickup") {
					currentlyHeld = rayHit.collider.gameObject;
					currentlyHeld.transform.position = transform.position;
					currentlyHeld.transform.SetParent (Camera.main.transform);
					currentRB = currentlyHeld.GetComponent<Rigidbody> ();
					currentRB.isKinematic = true;
					currentlyHeld.GetComponent<rotateObject> ().enabled = true;
					currentRB.detectCollisions = false;
					currentColliders = currentlyHeld.GetComponentsInChildren<Collider> ();
					foreach(Collider col in currentColliders) {
						col.enabled = false;
					}
				}
			}
		}
	}
}