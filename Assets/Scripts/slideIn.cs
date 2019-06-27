using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideIn : MonoBehaviour {

	Animator anime;

	void Start(){
		anime = GetComponent<Animator> ();
	}

	public void mover(){
		anime.Play ("slideUp");
	}
}
