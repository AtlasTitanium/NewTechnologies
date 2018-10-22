using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class MoveCamera : MonoBehaviour {
	private GazeAware Object;
	private Vector3 pos;
	private Vector2 mousePos;
	float smooth = 1f;
    float tiltAngle = 10.0f;
	private float addition;
	void Start(){
		Object = GetComponent<GazeAware>();
	}
	void Update () {
		pos = TobiiAPI.GetGazePoint().Screen;
     	pos.z = 0;
		mousePos = Input.mousePosition;
		Vector2 lookPos = Camera.main.ScreenToViewportPoint(mousePos);


		if(lookPos.y >= 0.8f || lookPos.y <= 0.2f){
			float tiltAroundX = Input.GetAxis("Mouse Y") * -tiltAngle;
			addition += tiltAroundX;
			Quaternion target = Quaternion.Euler(Mathf.Clamp(addition, -30f, 30f), transform.rotation.y, transform.rotation.z);
			transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
		}
        
		//transform.rotation = target;

		if(lookPos.x <= 0.2f){
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y - ((0.2f / lookPos.x) * 0.1f), transform.localEulerAngles.z);
		}
		
		if(lookPos.x >= 0.8f){
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + ((lookPos.x - 0.8f) * 10), transform.localEulerAngles.z);
		}
	}
}

/* 
/*
		pos = TobiiAPI.GetGazePoint().Screen;
     	pos.z = 0;
		Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		//If player looks left
		if(mousePos.x <= 0.2f){
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + ((0.2f / mousePos.x) * -0.1f), transform.localEulerAngles.z);
		}
		
		if(mousePos.x <= 0.1f){
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y - 0.2f, transform.localEulerAngles.z);
		}
		if(mousePos.x <= 0.05f){
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y - 0.3f, transform.localEulerAngles.z);
		}
		
		//Debug.Log("First" + (0.2f / mousePos.x) * -0.15f);
		//Debug.Log("Second" + (0.2f * (mousePos.x * 10)) * 0.2f);

		//if player looks right
		if(mousePos.x >= 0.8f){
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (0.2f * (mousePos.x * 10)) * 0.2f, transform.localEulerAngles.z);
		}
		
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

		/*
		if(mousePos.y >= 0.9f){
			step = 0;
			Debug.Log("looking up");
			Debug.Log(transform.localEulerAngles.x);
			
			//transform.localEulerAngles = new Vector3(Mathf.Clamp(transform.localEulerAngles.x, -50, 50) - 0.5f, transform.localEulerAngles.y, transform.localEulerAngles.z);

			//rot = Input.GetAxis("Mouse Y") * 10;
			transform.Rotate(0, 0, (-mousePos.y - 0.9f), Space.Self);
			transform.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.x, -50, 50) - 0.5f, transform.eulerAngles.y, transform.eulerAngles.z);
		}
		if(mousePos.y <= 0.1f){
			step = 0;
			Debug.Log("looking down");
			Debug.Log(transform.localEulerAngles.x);

			//transform.localEulerAngles = new Vector3(Mathf.Clamp(transform.localEulerAngles.x, -50, 50) + 0.5f, transform.localEulerAngles.y, transform.localEulerAngles.z);
			transform.Rotate(0, 0, (mousePos.y / 0.1f), Space.Self);
			transform.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.x, -50, 50), transform.eulerAngles.y, transform.eulerAngles.z);
		}
		if(mousePos.y >= 0.1f && mousePos.y <= 0.9f){
			step += Time.deltaTime;
			Debug.Log("return to 0");
			Mathf.Lerp(transform.eulerAngles.x, 0, step);
		}
		*/
		//float tiltAroundY = Input.GetAxis("Mouse X") * tiltAngle;

//transform.Rotate(0, 0, -rot, Space.Self);
//Debug.Log(transform.rotation.x);
//transform.rotation = new Vector3(Mathf.Clamp(transform.rotation.x, -0.5f, 0.5f), transform.rotation.y, transform.rotation.z);

