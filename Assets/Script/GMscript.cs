using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMscript : MonoBehaviour {

	public Camera cam;

	public GameObject ImageTarget;
	public GameObject CantosDobrado;
	public GameObject CantosEsticado;
	//public GameObject Stdout;

	public GameObject frisbe;
	private GameObject frisbeGO;
	private frisbeScript frisbeScrpt;

	//private ImageTargetScale imTargetScript;

	private bool definido1;
	private bool definido2;

	public TextScript t;
	public ReadTarget imDetector;

	public TextMesh messenger;
	private string messengerTxt;
	private Rect messengerRect;
	private GUIStyle messengerStyle;

	private float temp;

	private bool calibrarBtn;
	private bool reiniciarBtn;

	private float recemCalibrado = 0.0f;


	// Textos de output
	const string texto0 = "Aponte o dispositivo para o marcador!";
	const string texto1 = "Dobre os braços e toque em calibrar.";
	const string texto2 = "Estique os braços e toque em calibrar.";
	const string texto3 = "Calibrado!";
	const string texto4 = "Aponte para o marcador no. ";
	const string texto5 = "Descalibrado!";
	// Fim Textos


	//private Transform ImageTargetTransform;
	//private Transform CantosDobrado

	// Use this for initialization
	void Start () {
		//imTargetScript = ImageTarget.GetComponent<ImageTargetScale> ();

		definido1 = false;
		definido2 = false;

		// ---------------------------
		//print (texto1);
		messengerTxt = texto0;
		// ---------------------------

		inicializaMessenger ();
	}
	// Update is called once per frame
	void Update () {
		posicionaMessenger ();

		if (reiniciarBtn)
			resetarCalibracao ();

		if (imDetector.isFound) {

			if (!(definido1 && definido2))
				calibraMargens ();
			else {
				if (Time.time < recemCalibrado + 2.0f)
					messengerTxt = texto3;
				else {
					if(!frisbeGO)
						criaFrisbe ();

					if (verificaPosicao (CantosDobrado.transform, 20.0f)) {
						messengerTxt = "Marcador próximo da calibragem DOBRADA!\n";
					} else {
						messengerTxt = "\n";
					} if (verificaPosicao (CantosEsticado.transform, 20.0f)) {
						messengerTxt += "Marcador próximo da calibragem ESTICADA!\n";
						frisbeScrpt.arremessar ();
					} else {
						messengerTxt += "\n";
					}
				}
			}
		} else {
			if (!(definido1 && definido2))
				messengerTxt = texto0;
		}

		if (frisbeGO)
			frisbeScrpt.isActive = imDetector.isFound;


		// DEBUGANDO POSICIONAMENTO DO IMTARGET E DOS FAKES
		t.txt = "";/* "IT: TL=(" + ImageTarget.transform.GetChild (0).transform.position.x + "," + ImageTarget.transform.GetChild (0).transform.position.y + ") " +
			"BR=(" + ImageTarget.transform.GetChild (1).transform.position.x + "," + ImageTarget.transform.GetChild (1).transform.position.y + ") \n" +

			"CD: TL=(" + CantosDobrado.transform.GetChild (0).transform.position.x + "," + CantosDobrado.transform.GetChild (0).transform.position.y + ") " +
			"BR=(" + CantosDobrado.transform.GetChild (1).transform.position.x + "," + CantosDobrado.transform.GetChild (1).transform.position.y + ") \n" +

			"CE: TL=(" + CantosEsticado.transform.GetChild (0).transform.position.x + "," + CantosEsticado.transform.GetChild (0).transform.position.y + ") " +
			"BR=(" + CantosEsticado.transform.GetChild (1).transform.position.x + "," + CantosEsticado.transform.GetChild (1).transform.position.y + ") \n";
			*/
	}

	void resetarCalibracao(){
		definido1 = definido2 = false;
		CantosDobrado.GetComponent<SpawnaCantos> ().zeraCantosPosicoes ();
		CantosEsticado.GetComponent<SpawnaCantos> ().zeraCantosPosicoes ();
		if(frisbeGO)
			Destroy (frisbeGO.gameObject);
	}

	void calibraMargens(){
		if (!definido1) {
			messengerTxt = texto1;

			if (calibrarBtn) {
				CantosDobrado.transform.GetChild (0).transform.position = ImageTarget.transform.GetChild (0).transform.position;
				CantosDobrado.transform.GetChild (1).transform.position = ImageTarget.transform.GetChild (1).transform.position;
				temp = Time.time;

				CantosDobrado.GetComponent<SpawnaCantos> ().setaCantosPosicoes ();

				definido1 = true;
			}

		}

		if (definido1 && !definido2) {
			//print (texto2);
			messengerTxt = texto2;

			if (calibrarBtn && Time.time > temp + 2.0f) {
				CantosEsticado.GetComponent<SpawnaCantos> ().setaSEeID (
					ImageTarget.transform.GetChild (0).transform.position,
					ImageTarget.transform.GetChild (1).transform.position);
				CantosEsticado.GetComponent<SpawnaCantos> ().setaCantosPosicoes ();

				recemCalibrado = Time.time;
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
	}

	void OnGUI(){
		calibrarBtn = GUI.RepeatButton (new Rect (0, 0, 100.0f, 100.0f), "<b>Calibrar</b>");
		reiniciarBtn = GUI.RepeatButton (new Rect (Screen.width - 100.0f, 0, 100.0f, 100.0f), "<b>Reiniciar</b>");
		GUI.Label (messengerRect, "<color=white>"+messengerTxt+"</color>", messengerStyle);


	}

	void inicializaMessenger(){

		messengerStyle = GUIStyle.none;

		messengerStyle.wordWrap = true;
		messengerStyle.alignment = TextAnchor.UpperCenter;

		posicionaMessenger ();
	}
	void posicionaMessenger(){
		messengerStyle.fontSize = (int) (Screen.height*0.08f);
		float alt = messengerStyle.lineHeight;
		messengerRect = new Rect (0, Screen.height - 2*alt, Screen.width, 2*alt);
	}

	void criaFrisbe(){
		frisbeGO = Instantiate (frisbe,Vector3.zero, Quaternion.identity) as GameObject;
		frisbeScrpt = frisbeGO.GetComponent<frisbeScript> ();

		frisbeScrpt.cam = cam;
		frisbeScrpt.cantosVerde = CantosDobrado;
		frisbeScrpt.cantosVermelho = CantosEsticado;
		frisbeScrpt.imTarget = ImageTarget;
	}

}
