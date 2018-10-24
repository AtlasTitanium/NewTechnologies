using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
public class PickupObject : MonoBehaviour {

	private GazeAware Object;
	private Vector3 pos;
	private Vector3 mousePos;
	private float step = 0.0f;
	private bool holding = false;
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

		if(!holding){
			if(Camera.main.GetComponent<MoveCamera>().enabled){
				Ray ray = Camera.main.ScreenPointToRay(mousePos);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, 10)) 
				{
					if(hit.transform.GetComponent<PickupObject>()){
						step += 0.01f;
						transform.GetComponent<Renderer>().material.SetColor("_OutlineColor", new Color(Mathf.Lerp(0,1,step),0,0));	
						print("eye on object");
						if(transform.GetComponent<Renderer>().material.GetColor("_OutlineColor") == Color.red){
							transform.GetComponent<Renderer>().material.SetColor("_OutlineColor", new Color(0,0,0));
							step = 0.0f;
							transform.parent = Camera.main.transform;
							transform.localPosition = new Vector3(0.82f,-0.34f,1);
							transform.rotation = Quaternion.identity;
							transform.GetComponent<Rigidbody>().useGravity = false;
							holding = true;
						}
					}else {
						step = 0.0f;
						transform.GetComponent<Renderer>().material.SetColor("_OutlineColor", new Color(0,0,0));
					}	
				} 
			}
		} else {
			if(Input.GetKeyDown(KeyCode.Space)){
				transform.GetComponent<Rigidbody>().useGravity = true;
				transform.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 250);
				transform.parent = null;
				holding = false;
			}
		}
		
	}
}
