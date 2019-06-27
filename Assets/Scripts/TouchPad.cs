using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchPad : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler {

	public float smoothing;
	private Vector2 origin;
	private Vector2 direction;
	private Vector2 smoothDirection;

	private bool touched;
	private int pointerId;


	void Awake(){
		direction = Vector2.zero;
		touched = false;
	}

	public void OnPointerDown(PointerEventData data){
		if (!touched) {
			touched = true;
			pointerId = data.pointerId;
			origin = data.position;
		}

	}

	public void OnDrag(PointerEventData data){
		if (data.pointerId == pointerId) {
			Vector2 currPosition = data.position;
			Vector2 rawDirection = currPosition - origin;
			direction = rawDirection.normalized;
		}
	}

	public void OnPointerUp(PointerEventData data){
		if (data.pointerId == pointerId) {
			touched = false;
			direction = Vector2.zero;
		}
	}

	public Vector2 GetDirection(){
		smoothDirection = Vector2.MoveTowards (smoothDirection, direction, smoothing);
		return smoothDirection;
	}
}
