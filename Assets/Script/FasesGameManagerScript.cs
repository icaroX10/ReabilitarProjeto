using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FasesGameManagerScript : MonoBehaviour {

	private bool exitBtn = false;
	private bool faseBtn = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (exitBtn)
			voltarParaMenuPrincipal ();

		if (faseBtn)
			entrarFase ();
	}

	void OnGUI(){
		exitBtn = GUI.RepeatButton (new Rect (Screen.width - 100.0f, Screen.height - 100.0f, 100.0f, 100.0f), "<b>Sair</b>");
		faseBtn= GUI.RepeatButton (new Rect (Screen.width/2.0f - 30.0f, Screen.height/2.0f - 30.0f, 60.0f, 60.0f), "<b><color=red>FASE 1</color></b>");
	}

	void voltarParaMenuPrincipal(){
		SceneManager.LoadSceneAsync ("menuInicial");
	}

	void entrarFase(){
		SceneManager.LoadSceneAsync ("ingame");
	}

}
