using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPrincipalScript : MonoBehaviour {

	private SalvaDadosEntreScenes salvador;
	public UnityEngine.UI.Button botaoJogar;

	// Use this for initialization
	void Start () {
		salvador = gameObject.AddComponent<SalvaDadosEntreScenes> ();
		if (!salvador.EstaCalibrado ())
			botaoJogar.interactable = false;
	}
	
	// Update is called once per frame

	void Update () {
		/*if (jogar)
			SceneManager.LoadSceneAsync ("jogar");
		else if (calibrar)
			SceneManager.LoadSceneAsync ("base");*/	
	}

    public void Jogar()
    {
        SceneManager.LoadSceneAsync("jogar");
    }

    public void Calibrar()
    {
        SceneManager.LoadSceneAsync("calibragem");
    }

}
