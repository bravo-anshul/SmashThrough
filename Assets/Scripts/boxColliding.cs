using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxColliding : MonoBehaviour {

	public Break glass;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player")
			glass.change();
	}
}
