using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MascoteGuiaScript : MonoBehaviour {

	private GameObject mascoteGuiador;
	private List<string> nomesMarcadores;
	private MessengerScript messenger;

	// Mensagens padrão do Mascote
	const string texto0 = "<color=white>Aponte do dispositivo para o marcador</color> ";
	const string texto1 = "<color=magenta>Dobre</color> <color=white>seus braços!</color>";
	const string texto2 = "<color=lime>Estique</color> <color=white>seus braços!</color>";
	const string texto3 = "<color=white>Fase <color=lime>concluída</color>!\nClique em sair.</color>";
	const string texto4a = "<color=white>Você está no passo</color> ";
	const string texto4b = " <color=white>de</color> ";
	// Fim mensagens padrão do Mascote

	// Use this for initialization
	void Start () {
		messenger = gameObject.AddComponent<MessengerScript> ();
		messenger.InsereRect (new Rect(0, Screen.height/2.0f, Screen.width, Screen.height/2.0f));
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void InsereMascote(GameObject mascoteGuiador){
		this.mascoteGuiador = mascoteGuiador;
	}

	public void InsereNomesMarcadores(List<string> lista){
		nomesMarcadores = lista;
	}

	public void Ativador(bool status){
		gameObject.SetActive (status);
	}

	public void ApontarMarcador(int index){
		if(index < nomesMarcadores.Count)
			messenger.messengerTxt = texto0 + "<color=red>"+nomesMarcadores[index]+"</color>";
	}

	public void DobrarBracos(){
		messenger.messengerTxt = texto1;
	}

	public void EsticarBracos(){
		messenger.messengerTxt = texto2;
	}

	public void FinalizarFase(){
		messenger.messengerTxt = texto3;
	}

	public void AvisaEstagio(int act, int max){
		messenger.messengerTxt = texto4a + "<color=magenta>" + act + "</color>" + texto4b + "<color=magenta>" + max + "</color>";
	}
}
