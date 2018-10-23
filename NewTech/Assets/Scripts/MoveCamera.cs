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


		if(lookPos.y >= 0.88f || lookPos.y <= 0.12f){
			float tiltAroundX = Input.GetAxis("Mouse Y") * -tiltAngle;
			addition += tiltAroundX;
			Debug.Log(transform.localEulerAngles.y);
			Quaternion target = Quaternion.Euler(Mathf.Clamp(addition, -30f, 30f), transform.localEulerAngles.y, Mathf.Clamp(transform.rotation.z, -0f, 0f));
			transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
		}
        
		//transform.rotation = target;

		if(lookPos.x <= 0.2f && lookPos.x >= 0.01f){
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y - ((0.2f / lookPos.x) * 0.1f), transform.localEulerAngles.z);
		}
		if(lookPos.x <= 0.01f){
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y - 2, transform.localEulerAngles.z);
		}
		
		if(lookPos.x >= 0.8f){
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + ((lookPos.x - 0.8f) * 10), transform.localEulerAngles.z);
		}
	}
}
