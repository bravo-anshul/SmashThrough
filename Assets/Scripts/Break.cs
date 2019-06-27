using UnityEngine;
using System.Collections;

public class Break : MonoBehaviour 
{
	public Transform brokenObject;
	public float magnitudeCol, radius, power, upwards;

	public Material material;
	Renderer rend;

	void Start () 
	{
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
	}

	public void OnTriggerEnter(Collider other){
		if (other.tag != "Player")
			return;
		Destroy(gameObject);
		Instantiate(brokenObject, transform.position, transform.rotation);
		brokenObject.localScale = transform.localScale;
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);

		foreach (Collider hit in colliders)
		{
			if (hit.GetComponent<Rigidbody>())
			{
				hit.GetComponent<Rigidbody>().AddExplosionForce(power*10, explosionPos, radius, upwards);
			}
		}
	}

	public void change(){
		rend.sharedMaterial = material;
	}

	/*void OnCollisionEnter(Collision collision)
	{
		if (collision.relativeVelocity.magnitude > magnitudeCol)
		{
			Destroy(gameObject);
			Instantiate(brokenObject, transform.position, transform.rotation);
			brokenObject.localScale = transform.localScale;
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);

			foreach (Collider hit in colliders)
			{
				if (hit.GetComponent<Rigidbody>())
				{
					hit.GetComponent<Rigidbody>().AddExplosionForce(power*collision.relativeVelocity.magnitude, explosionPos, radius, upwards);
				}
			}
		}
	}*/
}
