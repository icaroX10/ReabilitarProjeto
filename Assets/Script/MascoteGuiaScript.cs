using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MascoteGuiaScript : MonoBehaviour {
	
	private GameObject mascoteGuiador;
	private List<string> nomesMarcadores;
	private MessengerScript messenger;
	private Text balaoMensagem;
	private Text balaoFimPontuacao;
	private Text balaoFimElogio;

	// Mensagens padrão do Mascote
	const string texto0 = "<color=black>Aponte do dispositivo para o marcador</color> ";
	const string texto1 = "<color=magenta>Dobre</color> <color=black>seus braços!</color>";
	const string texto2 = "<color=lime>Estique</color> <color=black>seus braços!</color>";
	const string texto3 = "<color=black>Fase <color=lime>concluída</color>!\nClique em sair.</color>";
	const string texto4a = "<color=black>Você está no passo</color> ";
	const string texto4b = " <color=black>de</color> ";
	const string texto7 = "Parabéns!!! Você concluiu a fase!!!";
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

	public void InsereBalaoTexto(Text balao){
		balaoMensagem = balao;
	}
	public void InsereBalaoFim(Text pontuacao, Text elogio){
		balaoFimPontuacao = pontuacao;
		balaoFimElogio = elogio;
	}
	public void InsereNomesMarcadores(List<string> lista){
		nomesMarcadores = lista;
	}

	public void Ativador(bool status){
		gameObject.SetActive (status);
	}

	public void ApontarMarcador(int index){
		if(index < nomesMarcadores.Count)
			balaoMensagem.text = texto0 + "<color=red>"+nomesMarcadores[index]+"</color>";
	}

	public void DobrarBracos(){
		balaoMensagem.text = texto1;
	}

	public void EsticarBracos(){
		balaoMensagem.text = texto2;
	}

	public void FinalizarFase(float tempoInicio, float tempoMax){
		balaoFimElogio.text = texto7;

		balaoMensagem.text = texto3;
	}

	public void AvisaEstagio(int act, int max){
		balaoMensagem.text = texto4a + "<color=magenta>" + act + "</color>" + texto4b + "<color=magenta>" + max + "</color>";
	}
}
