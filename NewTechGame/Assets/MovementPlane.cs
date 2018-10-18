using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class MovementPlane : MonoBehaviour {

	private GazeAware Object;
	private Vector3 pos;
	private Vector3 mousePos;
	private float step = 0.0f;
	public GameObject spherePrefab;
	private GameObject groundSphere;

	public LayerMask ignoreLayer;

	void Start(){
		Object = GetComponent<GazeAware>();
	}

	void Update(){
		moveToPlace();
		/*
		if(Input.GetKey(KeyCode.Space)){
			moveToPlace();
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			if(groundSphere != null){
				groundSphere.SetActive(false);
				step = 0;
			}
		}
		*/
	}

	public void moveToPlace(){
		pos = TobiiAPI.GetGazePoint().Screen;
     	pos.z = 0;

		mousePos = Input.mousePosition;
		 
		Ray ray = Camera.main.ScreenPointToRay(pos);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 5, ignoreLayer)) 
		{	
			Vector3 placePos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
			if(groundSphere == null){
				groundSphere = Instantiate(spherePrefab, placePos, Quaternion.identity);
			} else {
				groundSphere.SetActive(true);
				groundSphere.transform.position = placePos;
			}
			step += 0.01f;
			groundSphere.transform.GetComponent<Renderer>().material.color = new Color(1,Mathf.Lerp(1,0,step),Mathf.Lerp(1,0,step));	
			print("eye on floor");
			if(groundSphere.transform.GetComponent<Renderer>().material.color == Color.red){
				Camera.main.transform.position = new Vector3(groundSphere.transform.position.x, groundSphere.transform.position.y + 1, groundSphere.transform.position.z);
				step = 0.0f;
				groundSphere.SetActive(false);
			}
			
		} else {
			if(groundSphere != null){
				groundSphere.SetActive(false);
			}
			step = 0.0f;
		}
	}
	public void makeObjectTrackEyes(){
		Vector3 pos = TobiiAPI.GetGazePoint().Screen;
     	pos.z = 10;
     	pos = Camera.main.ScreenToWorldPoint(pos);
     	transform.position = Vector3.Lerp(transform.position, pos, 10*Time.deltaTime);
	}
}
