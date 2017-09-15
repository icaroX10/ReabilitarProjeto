using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frisbeScript : MonoBehaviour {

	public GameObject frisbe;
	public GameObject imTarget;
	public GameObject cantosVerde;
	public GameObject cantosVermelho;

	public Camera cam;

	public bool isActive;
	public bool isTrowed;

	private GameObject frisbeGO;

	private float dimVerde;
	private float dimVermelho;
	private float dimIMTarget;


	private Vector3 posInicialFrisbe;

	// Use this for initialization
	void Start () {
		frisbeGO = this.gameObject;
		isTrowed = false;

		this.GetComponent<Rigidbody> ().useGravity = false;

		posInicialFrisbe = new Vector3 (0, -0.5f, 1);
		frisbeGO.transform.position = posInicialFrisbe;
		//posFinalFrisbe = new Vector3 ();
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.LookAt (imTarget.transform.position);
		destroiAposTarget();

		if (isActive) {
			if (isTrowed) {
				direcionarFrisbe ();
			} else {
				/* TODO: Calcular a distância entre as duas molduras a fim de
				 * posicionar o frisbe entre as duas. Se basear na distância
				 * que o imTarget possui das duas (utilizar % relativo).
				 */
				calculaDimensao ();
			}
		} else {
			frisbeGO.transform.position = Vector3.zero;	
		}
	}

	void calculaDimensao(){
		Vector3 SupEsqVD = cam.WorldToScreenPoint(cantosVerde.transform.GetChild(0).transform.position);
		Vector3 InfDirVD = cam.WorldToScreenPoint(cantosVerde.transform.GetChild(1).transform.position);

		Vector3 SupEsqVM = cam.WorldToScreenPoint(cantosVermelho.transform.GetChild(0).transform.position);
		Vector3 InfDirVM = cam.WorldToScreenPoint(cantosVermelho.transform.GetChild(1).transform.position);

		Vector3 SupEsqIM = cam.WorldToScreenPoint(imTarget.transform.GetChild(0).transform.position);
		Vector3 InfDirIM = cam.WorldToScreenPoint(imTarget.transform.GetChild(1).transform.position);

		float diagVD = Vector3.Distance (SupEsqVD,InfDirVD);
		float diagVM = Vector3.Distance (SupEsqVM,InfDirVM);
		float diagIM = Vector3.Distance (SupEsqIM,InfDirIM);

		if (diagIM < diagVD)
			frisbeGO.transform.position = posInicialFrisbe;
		else {

			//float proximidade = diagIM / diagVM;
			float proximidade = diagIM / diagVD - 1; // Calculando melhor forma de mover o frisbe sem "saltos"

			frisbeGO.transform.position = new Vector3 (posInicialFrisbe.x, posInicialFrisbe.y, posInicialFrisbe.z + 2*proximidade);
		}

		//print (frisbeGO.transform.position.ToString());

		/* TODO: Identificar uma maneira de posicionar "Longitudinalmente" o objeto no eixo que liga as duas molduras  */
	}

	public void arremessar(){
		this.isTrowed = true;
		//this.GetComponent<Rigidbody> ().useGravity = true;

		//this.GetComponent<Rigidbody> ().AddForce (new Vector3(0,15.0f,15.0f) * 10.0f, ForceMode.Acceleration);
		this.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 13.0f, ForceMode.Acceleration);

	}

	public void direcionarFrisbe(){
		//Vector3 direcao = imTarget.transform.position - frisbeGO.transform.position;
		//this.GetComponent<Rigidbody> ().AddForce (direcao.);
		this.transform.LookAt(imTarget.transform.position);
	}

	public void destroiAposTarget(){
		if(frisbeGO.transform.position.z > imTarget.transform.position.z){
			Destroy (frisbeGO.gameObject);
		}
	}
}
