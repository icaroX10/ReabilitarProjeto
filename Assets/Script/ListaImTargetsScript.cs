using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaImTargetsScript : MonoBehaviour {

	private int lastActive;
	private List<Transform> lista;

	void Start(){
		lista = Listar ();
		foreach(Transform go in lista){
			go.gameObject.SetActive (false);
		}
		ativaTarget (0); // Ativando o primeiro marcador do circuito
	}

	public List<Transform> Listar(){
		List<Transform> lista = new List<Transform>();

		int max = transform.childCount;
		for (int id = 0; id < max; ++id) {
			lista.Add (transform.GetChild(id).transform);
		}
		return lista;
	}

	public Transform Get(int index){
		return lista [index];
	}

	public void AtivaTarget(int index){
		if (index == lastActive)
			return;
		ativaTarget (index);
	}

	private void ativaTarget(int index){
		transform.GetChild (lastActive).gameObject.SetActive(false);
		transform.GetChild (index).gameObject.SetActive(true);
		lastActive = index;
	}

}
