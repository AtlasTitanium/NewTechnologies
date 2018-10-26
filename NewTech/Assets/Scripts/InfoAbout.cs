using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class InfoAbout : MonoBehaviour {

	private GazeAware Object;
	private Vector3 pos;
	private Vector3 mousePos;
	private float step = 0.0f;
	void Start(){
		Object = GetComponent<GazeAware>();
	}

	void Update(){
		makeObjectCentered();
	}

	public void makeObjectCentered(){
		pos = TobiiAPI.GetGazePoint().Screen;
     	pos.z = 0;

		mousePos = Input.mousePosition;
		 
		Ray ray = Camera.main.ScreenPointToRay(pos);
		RaycastHit hit;
		
		if (Physics.Raycast (ray, out hit, 50)) 
		{
			step += 0.01f;
			transform.GetComponent<Renderer>().material.color = new Color(1,Mathf.Lerp(1,0,step),Mathf.Lerp(1,0,step));	
			print("eye on object");
			if(transform.GetComponent<Renderer>().material.color == Color.red){
				transform.GetComponent<Renderer>().material.color = new Color(1f,1f,1f);
				step = 0.0f;
				transform.position = new Vector3 (Random.Range(-2,2),Random.Range(-2,2),Random.Range(-2,2));
			}
		} else {
			step = 0.0f;
			transform.GetComponent<Renderer>().material.color = new Color(1f,1f,1f);
		}
	}
	public void makeObjectTrackEyes(){
		Vector3 pos = TobiiAPI.GetGazePoint().Screen;
     	pos.z = 10;
     	pos = Camera.main.ScreenToWorldPoint(pos);
     	transform.position = Vector3.Lerp(transform.position, pos, 10*Time.deltaTime);
	}
}
