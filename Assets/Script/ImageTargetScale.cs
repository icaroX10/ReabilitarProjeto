using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTargetScale : MonoBehaviour {
    public Transform topL;
    public Transform topR;
    public Transform botL;
    public Transform botR;

    float x = Screen.width;
    float y = Screen.height;
    
    // Use this for initialization
    void Start () {
       print("Largura="+x+"Altura="+y);
        //borda.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
        
    }
	
	// Update is called once per frame
	void Update () {
        //Distancia do image target pra borda
        float width = Vector3.Distance(topL.position, topR.position);
        float height = Vector3.Distance(topR.position, botR.position);
        //print("A Largura é "+ width+ "A Altura é " + height);
    }
}
