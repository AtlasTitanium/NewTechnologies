using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class MoveCamera : MonoBehaviour {
	private GazeAware Object;
	private Vector3 pos;
	void Start(){
		Object = GetComponent<GazeAware>();
	}
	void Update () {
		pos = TobiiAPI.GetGazePoint().Screen;
     	pos.z = 0;
		Vector2 mousePos = Camera.main.ScreenToViewportPoint(pos);
		//If player looks left
		if(mousePos.x <= 0.2f){
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + ((0.2f / mousePos.x) * -0.1f), transform.localEulerAngles.z);
		}
		/*
		if(mousePos.x <= 0.1f){
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y - 0.2f, transform.localEulerAngles.z);
		}
		if(mousePos.x <= 0.05f){
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y - 0.3f, transform.localEulerAngles.z);
		}
		*/
		//Debug.Log("First" + (0.2f / mousePos.x) * -0.15f);
		//Debug.Log("Second" + (0.2f * (mousePos.x * 10)) * 0.2f);

		//if player looks right
		if(mousePos.x >= 0.8f){
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (0.2f * (mousePos.x * 10)) * 0.2f, transform.localEulerAngles.z);
		}
		/*
		if(mousePos.x >= 0.9f){
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 0.2f, transform.localEulerAngles.z);
		}
		if(mousePos.x >= 0.95f){
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 0.3f, transform.localEulerAngles.z);
		}
		*/

		//If player looks up
		/* 
		if(mousePos.y >= 0.9f){
			if((transform.rotation.x *360) > 100){
				Debug.Log("it is");
				transform.eulerAngles = new Vector3(transform.eulerAngles.x + 0.5f, transform.eulerAngles.y, transform.eulerAngles.z);
			}
			if((transform.rotation.x * 360) <= 100){
				Debug.Log("eye in the roof");
				transform.eulerAngles = new Vector3(transform.eulerAngles.x - 0.5f, transform.eulerAngles.y, transform.eulerAngles.z);
			} else {
				transform.eulerAngles = transform.eulerAngles;
			}
		} else {
			if((transform.rotation.x * 360) >= 1){
				Debug.Log("eye to the ground");
				transform.eulerAngles = new Vector3(transform.eulerAngles.x + 0.5f, transform.eulerAngles.y, transform.eulerAngles.z);
			} else {
				transform.rotation = Quaternion.Euler(Mathf.Clamp(transform.rotation.x, -45,45),0,0);
			}
		}
		*/
	}
}
