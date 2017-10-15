using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentificadorJeb : MonoBehaviour {

	private Camera cam;
	private GameObject imTarget;
	private float dimensaoMax;
	private float dimensaoMin;

	private float tempoParaDelay;

	private float precisao = 0.1f;

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
		float dist = Vector3.Distance (im0, im1);

		bool retorno = dist >= dimensaoMax*(1.0f - precisao) && dist < dimensaoMax*(1.0f + precisao);
		if (retorno)
			tempoParaDelay = Time.time;
		
		return  retorno;
	}

	public bool DobrouBraco(){
		Vector3 im0 = cam.WorldToScreenPoint (imTarget.transform.GetChild (0).transform.position);
		Vector3 im1 = cam.WorldToScreenPoint (imTarget.transform.GetChild (1).transform.position);
		float dist = Vector3.Distance (im0, im1);

		bool retorno = dist >= dimensaoMin*(1.0f - precisao) && dist < dimensaoMin*(1.0f + precisao);
		if (retorno && tempoParaDelay + 1.0f > Time.time)
			return false;

		return retorno;
	}
}
