using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentificadorJeb : MonoBehaviour {

	private Camera cam;
	private GameObject imTarget;
	private float dimensao;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InsereImTarget(GameObject im){
		imTarget = im;
	}

	public void InsereCamera(Camera c){
		cam = c;
	}

	public void SetaDimensaoPJeb(float dim){
		dimensao = dimensao;
	}

	public bool EsticouBraco(){
		Vector3 im0 = cam.WorldToScreenPoint (imTarget.transform.GetChild (0).transform.position);
		Vector3 im1 = cam.WorldToScreenPoint (imTarget.transform.GetChild (1).transform.position);

		return  Vector3.Distance (im0, im1) >= dimensao*0.9f;
	}

}
