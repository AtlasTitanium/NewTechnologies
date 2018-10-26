using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class LookAtPlayer : MonoBehaviour {
	private GazeAware Object;
	private Vector3 pos;
	private Vector3 mousePos;
	private float step = 0.0f;
	private Vector3 lastSeen;
	private Vector3 newPos;

	void Start(){
		Object = GetComponent<GazeAware>();
		lastSeen = Camera.main.transform.position;
		transform.LookAt(lastSeen);
	}

	void Update () {
		pos = TobiiAPI.GetGazePoint().Screen;
     	pos.z = 0;

		mousePos = Input.mousePosition;

		Ray ray = Camera.main.ScreenPointToRay(pos);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 10)) 
		{
			if(hit.transform.GetComponent<LookAtPlayer>()){
				step += 0.05f;
				float x = (Mathf.Lerp(lastSeen.x, Camera.main.transform.position.x, step));
				float y = (Mathf.Lerp(lastSeen.y, Camera.main.transform.position.y, step));
				float z = (Mathf.Lerp(lastSeen.z, Camera.main.transform.position.z, step));
				newPos = new Vector3(x,y,z);
				transform.LookAt(newPos);
				if(newPos == Camera.main.transform.position){
					lastSeen = Camera.main.transform.position;
					step = 0;
				}				
			} else {
				lastSeen = newPos;
				step = 0;
			}
		} 
		
	}
}
