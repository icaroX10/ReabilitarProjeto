using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vuforia;
using UnityEngine.SceneManagement;

public class InGameGMScript : MonoBehaviour
{
	public Camera cam;
	public GameObject listaPai;
	public GameObject mascoteGuiaGO;

	private MessengerScript messenger;
	private ListaImTargetsScript listaIMTargetScript;
	private GerenciadorCircuitoScript gerenciadorCircuito;
	private SalvaDadosEntreScenes salvador;
	private MascoteGuiaScript mascoteGuia;
	private ReadTarget imDetector;
	private IdentificadorJeb identificaJeb;

	// Bertolino: Série de objetos a serem retirados e convertê-los em List
	public GameObject frisbe;
	private GameObject frisbeGO;
	private frisbeScript frisbeScrpt;

	private bool exitBtn = false;
	private bool circuitoImpossivel = false;

	private bool bracoDobrado = false;
	private bool bracoEsticado = false;

	private int ultimoMarcador = -1;

	private float tempoParaMarcadores = 0.0f;

	private bool teste = false;

	// Use this for initialization
	void Start () {
		listaIMTargetScript = listaPai.gameObject.GetComponent<ListaImTargetsScript> (); listaIMTargetScript.Iniciailizar ();
		messenger = gameObject.AddComponent<MessengerScript> ();
		gerenciadorCircuito = gameObject.AddComponent<GerenciadorCircuitoScript> ();
		salvador = gameObject.AddComponent<SalvaDadosEntreScenes> ();
		mascoteGuia = mascoteGuiaGO.gameObject.GetComponent<MascoteGuiaScript> ();
		identificaJeb = gameObject.AddComponent<IdentificadorJeb> ();

		// TODO: Deletar quando implementar o substituto -------
		List<int> x = new List<int>(); x.Add(0); x.Add(1); x.Add(2);
		salvador.SalvarCircuito(x);

		List<string> y = new List<string> (); y.Add ("Leão"); y.Add ("Golfinho"); y.Add ("Besouro");
		salvador.SalvarNomesMarcadores (y);
		// FIM: Deletar quando implementar o substituto ------

		// Checando se existe o circuito
		if (!listaIMTargetScript.ChecaSeExisteOCircuito (salvador.LerCircuito ()))
			CircuitoInexistente ();
		// FIM: Checando se existe o circuito

		messenger.InsereRect (new Rect(0, 0, Screen.width, Screen.height/4.0f));
		gerenciadorCircuito.InsereCircuito (salvador.LerCircuito());
		salvador.InsereCamera (cam);

		mascoteGuia.InsereNomesMarcadores (salvador.LerNomesMarcadores());

		imDetector = listaIMTargetScript.LerReadTarget (0);

		identificaJeb.InsereImTarget (listaIMTargetScript.Get(0).gameObject);
		identificaJeb.InsereCamera (cam);
		identificaJeb.SetaDimensaoPJeb (salvador.LerDimensaoMin(), salvador.LerDimensaoMax());




		mascoteGuia.Ativador (true);

		print (Time.time);
	}
	
	// Update is called once per frame
	void Update () {
		messenger.messengerTxt = "<color=white>"+Time.time.ToString()+ "\nTempoParaMarcadores: "+tempoParaMarcadores.ToString()+" if- "+teste.ToString()+"</color>";

		if (exitBtn)
			voltarMenuPrincipal ();
		if (circuitoImpossivel)
			return;

		//mascoteGuia.AvisaEstagio (gerenciadorCircuito.PassoAtual()+1, gerenciadorCircuito.PassoMaximo());
		if (gerenciadorCircuito.TemProximo ()) {
			if (ultimoMarcador != gerenciadorCircuito.MarcadorAtual ()) {
				print ("Estamos no marcador no: " + gerenciadorCircuito.MarcadorAtual ());
				listaIMTargetScript.AtivaTarget (gerenciadorCircuito.MarcadorAtual ());
				mascoteGuia.ApontarMarcador (gerenciadorCircuito.MarcadorAtual ());
				imDetector = listaIMTargetScript.LerReadTarget (gerenciadorCircuito.MarcadorAtual ());
				identificaJeb.InsereImTarget (listaIMTargetScript.Get(gerenciadorCircuito.MarcadorAtual ()).gameObject);
				ultimoMarcador = gerenciadorCircuito.MarcadorAtual ();
			}

			if (imDetector.isFound) {
				//mascoteGuia.Ativador (false);
//				(Time.time < recemCalibrado + 2.0f)
				if (teste = (tempoParaMarcadores < Time.time)) {
					if (!bracoDobrado && identificaJeb.DobrouBraco ()) {
						print ("ENTROU BRACO DOBRADO");

						mascoteGuia.EsticarBracos ();

						bracoDobrado = true;
					} else if (!bracoEsticado && identificaJeb.EsticouBraco ()) {
						print ("ENTROU BRACO ESTICADO");

						mascoteGuia.DobrarBracos ();

						bracoEsticado = true;
						//bracoDobrado = !bracoEsticado;
					} else if (bracoDobrado && bracoEsticado && identificaJeb.DobrouBraco ()) {
						print ("ENTROU BRACO DOBRADO NOVAMENTE");
						gerenciadorCircuito.AvancarPasso ();

						tempoParaMarcadores = Time.time + 2.0f;
						//mascoteGuia.EsticarBracos ();

						bracoDobrado = false;
						bracoEsticado = false;
						//bracoEsticado = !bracoDobrado;
					} else if(!bracoDobrado && !bracoEsticado) {
						//print ("ENTROU BRACO SEM DOBRAR E ESTICAR");
						mascoteGuia.DobrarBracos ();
					}
				} else {
					mascoteGuia.AvisaEstagio (gerenciadorCircuito.PassoAtual()+1, gerenciadorCircuito.PassoMaximo());
				}
			} else {
				//mascoteGuia.Ativador (true);
				mascoteGuia.ApontarMarcador (gerenciadorCircuito.MarcadorAtual ());
			}
		} else {
			mascoteGuia.FinalizarFase ();
			//mascoteGuia.Ativador (false);
		}
		/*
		if (frisbeGO)
			frisbeScrpt.isActive = imDetector.isFound;*/
	}

	void OnGUI(){
		exitBtn = GUI.RepeatButton (new Rect (Screen.width - 100.0f, Screen.height - 100.0f, 100.0f, 100.0f), "<b>Sair</b>");
	}

	void voltarMenuPrincipal(){
		SceneManager.LoadSceneAsync ("jogar");
	}

	/* // Bertolino: A retirar para o InGame
	void criaFrisbe(){
		frisbeGO = Instantiate (frisbe,Vector3.zero, Quaternion.identity) as GameObject;
		frisbeScrpt = frisbeGO.GetComponent<frisbeScript> ();

		frisbeScrpt.cam = cam;
		frisbeScrpt.cantosVerde = CantosDobrado;
		frisbeScrpt.cantosVermelho = CantosEsticado;
		frisbeScrpt.imTarget = ImageTarget;
		frisbeScrpt.kitten = Kitten;
	}*/

	private void CircuitoInexistente(){
		messenger.messengerTxt = "<color=white>O circuito inserido é impossível!\nSaia e reinsira o circuito!!!</color>";
		circuitoImpossivel = true;
		print ("Circuito impossivel!");
	}

}

