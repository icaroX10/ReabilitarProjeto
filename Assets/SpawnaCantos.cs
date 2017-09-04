using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnaCantos : MonoBehaviour {

	public GameObject CantoSE;
	public GameObject CantoSD;
	public GameObject CantoIE;
	public GameObject CantoID;

	private Vector3 SupEsq;
	private Vector3 InfDir;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setaCantosPosicoes(){
		SupEsq = transform.GetChild (0).transform.position;
		InfDir = transform.GetChild (1).transform.position;
		float zMedio = (SupEsq.z + InfDir.z) / 2;

		CantoSE.transform.position = new Vector3 ( SupEsq.x, SupEsq.y, zMedio );
		CantoSD.transform.position = new Vector3 ( InfDir.x, SupEsq.y, zMedio );
		CantoID.transform.position = new Vector3 ( InfDir.x, InfDir.y, zMedio );
		CantoIE.transform.position = new Vector3 ( SupEsq.x, InfDir.y, zMedio );



	}
}
