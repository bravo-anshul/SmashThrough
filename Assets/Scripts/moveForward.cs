using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour {

	private Rigidbody rb;
	public int speed;

	void Start () {

		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}

	void Update(){
		rb.velocity = speed * (rb.velocity.normalized);
	}

}
