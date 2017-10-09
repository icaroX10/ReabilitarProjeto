using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPrincipalScript : MonoBehaviour {

	private bool calibrar;
	private bool jogar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

    /*
	void Update () {
		if (jogar)
			SceneManager.LoadSceneAsync ("jogar");
		else if (calibrar)
			SceneManager.LoadSceneAsync ("base");
		
	}

	void OnGUI(){
		jogar = GUI.RepeatButton (new Rect (Screen.width/2.0f - 50.0f, Screen.height/2.0f - 20.0f, 100.0f, 40.0f), "<b>JOGAR!</b>");
		calibrar = GUI.RepeatButton (new Rect (Screen.width/2.0f - 50.0f, Screen.height/2.0f + 20.0f, 100.0f, 40.0f), "<b>Calibrar</b>");

		//GUI.Label (messengerRect, "<color=white>"+messengerTxt+"</color>", messengerStyle);

	}
    */

    public void Jogar()
    {
        SceneManager.LoadSceneAsync("jogar");
    }

    public void Calibrar()
    {
        SceneManager.LoadSceneAsync("calibragem");
    }

}
