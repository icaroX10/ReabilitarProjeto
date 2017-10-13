using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentificadorJeb : MonoBehaviour {

	private Camera cam;
	private GameObject imTarget;
	private float dimensaoMax;
	private float dimensaoMin;

	private float tempoParaDelay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		tempoParaDelay = 0;
	}

	public void InsereImTarget(GameObject im){
		imTarget = im;
	}

	public void InsereCamera(Camera c){
		cam = c;
	}

	public void SetaDimensaoPJeb(float dimMin,float dimMax){
		dimensaoMax = dimMax;
		dimensaoMin = dimMin;
	}

	public bool EsticouBraco(){
		Vector3 im0 = cam.WorldToScreenPoint (imTarget.transform.GetChild (0).transform.position);
		Vector3 im1 = cam.WorldToScreenPoint (imTarget.transform.GetChild (1).transform.position);

		bool retorno = Vector3.Distance (im0, im1) >= dimensaoMax*0.9f;
		if (retorno)
			tempoParaDelay = Time.time;
		
		return  retorno;
	}

	public bool DobrouBraco(){
		Vector3 im0 = cam.WorldToScreenPoint (imTarget.transform.GetChild (0).transform.position);
		Vector3 im1 = cam.WorldToScreenPoint (imTarget.transform.GetChild (1).transform.position);

		bool retorno = Vector3.Distance (im0, im1) <= dimensaoMin*1.1f;
		if (retorno && tempoParaDelay + 1.0f > Time.time)
			return false;

		return retorno;
	}
}
