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

	private int textLength = 68;
	private bool passavel = true;

	private string[] msg;
	private string[] msgAct;

	private int cenaAct = 0;
	private int subCenaAct = 0;

	// TODO: Checar se o toque foi fora do btn Skip para avançar uma fala na scene.
	// http://answers.unity3d.com/questions/947856/how-to-detect-click-outside-ui-panel.html

	private float start;

	// Use this for initialization
	void Start () {
		// Carregamento das imagens do tutorial a serem usadas como background do Canvas
		imagens = new List<Sprite> (Resources.LoadAll<Sprite> ("imagensTutorial/"));
		background.sprite = imagens [idImagens++];
		msg = textoFalasAsset.text.Split('\n');
		msgAct = msg [cenaAct++].Split(new string[] {"<fala>"}, System.StringSplitOptions.None);
		textoFalas.text = msgAct [subCenaAct++];
		//passaTexto ();

		//print ("DEBUG: " + msg);
		//string[] k = msg.Split('\n');
		//foreach (var s in k) {
		//	print ("DEGUB:: " + s);
		//}
		//print ("DEBUGAO "+readLine(msg));

		start = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		//if(passarFala()){
			
		//	start = Time.time;
		//}
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

	public void passaTexto(){
		if (subCenaAct < msgAct.Length) {
			if (passavel) {
				StartCoroutine ("printaLetras");
			}
		} else {
			subCenaAct = 0;
			msgAct = msg [cenaAct++].Split (new string[] {"<fala>"}, System.StringSplitOptions.None);
			//textoFalas.text = msgAct [subCenaAct++];
			if (passavel) {
				StartCoroutine ("printaLetras");
			}
			if (cenaAct < msg.Length) {
				if (idImagens < imagens.Count) {
					background.sprite = imagens [idImagens++];
				} else {
					print ("Faltam imagens para as cenas!");
				}
			} else {
				print ("fim do tutorial");
			}

		}

	}

	public IEnumerator printaLetras(){
		passavel = false;
		textoFalas.text = "";

		// TODO:TODO:TODO:TODO:TODO:TODO:
		// TODO:TODO: Parei na implementação do corte da palavra que não cabe no buffer.
		// TODO:TODO: Junto com isso, preciso implementar o click da setinha para passar
		// TODO:TODO: o resto da mensagem que está para entrar no buffer.
		// TODO:TODO:TODO:TODO:TODO:TODO:


		int ultimaPalavra = msgAct [subCenaAct].LastIndexOf (' ', textLength);
		int fimUltPalavra = msgAct [subCenaAct].IndexOf (' ', ultimaPalavra);
		if (textLength < fimUltPalavra) print(""); // PALAVRA NÃO CABE COMPLETAMENTE NA EXIBIÇÃO

		for (int i = 0; i < msgAct[subCenaAct].Length && i < textLength-3; ++i) {
			textoFalas.text += msgAct[subCenaAct][i];
			yield return new WaitForSeconds(0.05f);
		}
		for (int i = 0; i < 3; ++i) {
			textoFalas.text += ".";
			yield return new WaitForSeconds(0.05f);
		}
		subCenaAct++;
		passavel = true;
		yield break;
	}

	public void skipaTutorial(){
		// Carregar scene de início de usabilidade
		SceneManager.LoadSceneAsync("usabilidade");
	}


}
