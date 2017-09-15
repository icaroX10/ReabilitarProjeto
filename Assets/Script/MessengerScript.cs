using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessengerScript : MonoBehaviour {

	public Camera cam;

	// Use this for initialization
	void Start () {
		// TODO: Verificar por que esse próprio objeto não está com sua posição modificando
		float width = Screen.width;
		float height = Screen.height;

		Vector3 novaPosicao = new Vector3 ( width/2, 25, 0 );

		transform.position = cam.ScreenToWorldPoint (novaPosicao);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
