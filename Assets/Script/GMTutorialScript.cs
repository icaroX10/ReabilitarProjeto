using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GMTutorialScript : MonoBehaviour {

	public List<Sprite> imagens;
	public int idImagens = 0;

	public Image background;

	public Text textoFalas;
	public TextAsset textoFalasAsset;

	private string msg;


	// TODO: Checar se o toque foi fora do btn Skip para avançar uma fala na scene.
	// http://answers.unity3d.com/questions/947856/how-to-detect-click-outside-ui-panel.html

	private float start;

	// Use this for initialization
	void Start () {
		// Carregamento das imagens do tutorial a serem usadas como background do Canvas
		imagens = new List<Sprite> (Resources.LoadAll<Sprite> ("imagensTutorial/"));
		msg = textoFalasAsset.text;
	
		//print ("DEBUG: " + msg);
		string[] k = msg.Split('\n');
		foreach (var s in k) {
			print ("DEGUB:: " + s);
		}
		//print ("DEBUGAO "+readLine(msg));

		start = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(passarFala()){
			if (idImagens < imagens.Count) {
				print (idImagens);
				background.sprite = imagens [idImagens++];
			}
			start = Time.time;
		}
	}

	private bool passarFala(){
		return Time.time >= start + 2.0f;
	}

	private string readLine(string str){
		return str.Substring(
			str.IndexOf (">")+1,
			str.IndexOf ("\n")
		);
	}

	public void skipaTutorial(){
		// Carregar scene de início de usabilidade
		SceneManager.LoadSceneAsync("usabilidade");
	}
}
