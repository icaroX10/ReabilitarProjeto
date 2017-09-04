using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMscript : MonoBehaviour {

	public Camera cam;

	public GameObject ImageTarget;
	public GameObject CantosDobrado;
	public GameObject CantosEsticado;
	//public GameObject Stdout;

	private bool definido1;
	private bool definido2;

	public TextScript t;
	public ReadTarget imDetector;

	public TextMesh messenger;

	private float temp;

	//private Transform ImageTargetTransform;
	//private Transform CantosDobrado

	// Use this for initialization
	void Start () {
		definido1 = false;
		definido2 = false;

		// ---------------------------
		string texto1 = "Aponte o dispositivo para o marcador, dobre os braços e toque na tela.";
		print (texto1);
		// ---------------------------

	}
	
	// Update is called once per frame
	void Update () {
		if (imDetector.isFound) {
			if (!(definido1 && definido2))
				calibraMargens ();

			if (verificaPosicao (CantosDobrado.transform, 20.0f))
				messenger.text = "Marcador próximo da calibragem DOBRADA!\n";
			else
				messenger.text = "\n";
			if (verificaPosicao (CantosEsticado.transform, 20.0f))
				messenger.text += "Marcador próximo da calibragem ESTICADA!\n";
			else
				messenger.text += "\n";
		}
		t.txt = "IT: TL=(" + ImageTarget.transform.GetChild (0).transform.position.x + "," + ImageTarget.transform.GetChild (0).transform.position.y + ") " +
			"BR=(" + ImageTarget.transform.GetChild (1).transform.position.x + "," + ImageTarget.transform.GetChild (1).transform.position.y + ") \n" +

			"CD: TL=(" + CantosDobrado.transform.GetChild (0).transform.position.x + "," + CantosDobrado.transform.GetChild (0).transform.position.y + ") " +
			"BR=(" + CantosDobrado.transform.GetChild (1).transform.position.x + "," + CantosDobrado.transform.GetChild (1).transform.position.y + ") \n" +

			"CE: TL=(" + CantosEsticado.transform.GetChild (0).transform.position.x + "," + CantosEsticado.transform.GetChild (0).transform.position.y + ") " +
			"BR=(" + CantosEsticado.transform.GetChild (1).transform.position.x + "," + CantosEsticado.transform.GetChild (1).transform.position.y + ") \n";
	}

	void calibraMargens(){
		if (!definido1) {


			if (Input.GetMouseButtonDown (0)) {
				CantosDobrado.transform.GetChild (0).transform.position = ImageTarget.transform.GetChild (0).transform.position;
				CantosDobrado.transform.GetChild (1).transform.position = ImageTarget.transform.GetChild (1).transform.position;
				temp = Time.time;

				CantosDobrado.GetComponent<SpawnaCantos> ().setaCantosPosicoes ();

				definido1 = true;
				// -----------------------
				string texto2 = "Aponte o dispositivo para o marcador, estique os braços e toque na tela.";
				print (texto2);
				// -----------------------
			}

		}

		if (definido1 && !definido2) {


			if (Input.GetMouseButtonDown (0) && Time.time > temp + 2.0f) {
				CantosEsticado.transform.GetChild (0).transform.position = ImageTarget.transform.GetChild (0).transform.position;
				CantosEsticado.transform.GetChild (1).transform.position = ImageTarget.transform.GetChild (1).transform.position;

				CantosEsticado.GetComponent<SpawnaCantos> ().setaCantosPosicoes ();

				definido2 = true;
			}
		}


	}

	private bool verificaPosicao(Transform paiT, float distancia){
		Vector3 child0 = cam.WorldToScreenPoint(paiT.GetChild(0).transform.position);
		Vector3 child1 = cam.WorldToScreenPoint(paiT.GetChild(1).transform.position);
		Vector3 im0 = cam.WorldToScreenPoint (ImageTarget.transform.GetChild (0).transform.position);
		Vector3 im1 = cam.WorldToScreenPoint (ImageTarget.transform.GetChild (1).transform.position);

		if (Vector3.Distance (child0, im0) < distancia &&
		    Vector3.Distance (child1, im1) < distancia) {
			return true;
		}

		return false;

		/*
		string ttt = "Top Target = X: " + TopL.x.ToString("f1") + "Borda = X:" + BordaTopL.x.ToString("f1") + "\nTarget = Y:" + TopL.y.ToString("f1") + "Borda = Y:"+ BordaTopL.y.ToString("f1")+ "\nBot Target = X: " + botR.x.ToString("f1") + "Borda = X:" + BordaBotR.x.ToString("f1") + "\nTarget = Y:" + botR.y.ToString("f1") + "Borda = Y:" + BordaBotR.y.ToString("f1");

		t.txt = ttt;

		float width = Vector3.Distance(topL.position, topR.position);
		 float height = Vector3.Distance(topR.position, botR.position);

		distancia(borda,target);
		print("A Largura é "+ width+ "A Altura é " + height);*/
	}
}
