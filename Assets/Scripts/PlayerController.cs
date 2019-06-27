using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, yMin, yMax;
}
	
public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public TouchPad tp;
	public Boundary boud;

	public int speed;
	public float mover;

	public slideIn si;
	public SlideDown slideDown;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){
		Vector2 direction = tp.GetDirection();
		Vector3 movement = new Vector3(direction.x*2,direction.y*2,mover);

		/*float moveH = Input.GetAxis("Horizontal");
		float moveV = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveH*2,moveV*2,mover);*/
		rb.velocity = (movement * speed);
		rb.rotation = Quaternion.Euler (Vector3.zero);

		if (rb.position.z > 270) {
			Application.LoadLevel(Application.loadedLevel);
		}
		if (rb.position.z > 120) {
			si.mover ();
		}
		if (rb.position.z > 185) {
			slideDown.mover ();
		}
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boud.xMin, boud.xMax),
			Mathf.Clamp (rb.position.y, boud.yMin, boud.yMax),
			Mathf.Clamp (rb.position.z, 0, 300)
		);
	}

	public void OnTriggerEnter(Collider other){
		if (other.tag == "glass_greyGreen") {
			CameraShaker.Instance.ShakeOnce (2f, 2f, .1f, 1f);
		}
		if (other.tag == "glass_greyRed") {
			CameraShaker.Instance.ShakeOnce (3f, 2f, .1f, 1f);
			//Application.LoadLevel(Application.loadedLevel);
		}
	}
		
}
