using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
public class MoveToPlace : MonoBehaviour {

	public GameObject CameraPlace;

	private GazeAware Object;
	private Vector3 pos;
	private Vector3 mousePos;
	private float step = 0.0f;

	void Start(){
		Object = GetComponent<GazeAware>();
	}

	void Update(){
		if(Camera.main.transform.position == CameraPlace.transform.position){
			GetComponent<MeshRenderer>().enabled = false;
		} else {
			GetComponent<MeshRenderer>().enabled = true;
			makeObjectCentered();
		}
	}

	public void makeObjectCentered(){
		pos = TobiiAPI.GetGazePoint().Screen;
     	pos.z = 0;

		mousePos = Input.mousePosition;

		if(Camera.main.GetComponent<MoveCamera>().enabled){
			Ray ray = Camera.main.ScreenPointToRay(mousePos);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 10)) 
			{
				if(hit.transform == this.transform){
					step += 0.01f;
					transform.GetComponent<Renderer>().material.color = new Color(Mathf.Lerp(0,1,step),0,0);	
					if(transform.GetComponent<Renderer>().material.color == Color.red){
						Camera.main.transform.position = CameraPlace.transform.position;
						step = 0;
					}
				} else {
					transform.GetComponent<Renderer>().material.color = new Color(0,0,0);
					step = 0;
				}
			}
		}
	}
}
