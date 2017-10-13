using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MascoteGuiaScript : MonoBehaviour {

	private GameObject mascoteGuiador;
	private List<string> nomesMarcadores;
	private MessengerScript messenger;

	// Mensagens padrão do Mascote
	const string texto0 = "<color=white>Aponte do dispositivo para o marcador</color> ";
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

}
