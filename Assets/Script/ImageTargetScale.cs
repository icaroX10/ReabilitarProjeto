using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTargetScale : MonoBehaviour {
    public Transform topL;
    public Transform topR;
    public Transform botL;
    public Transform botR;

    public Transform borda;
    public Transform target;

    float x = Screen.width;
    float y = Screen.height;

    public bool dis;

    // Use this for initialization
    void Start () {
       print("Largura="+x+"Altura="+y);
        dis = false;
        //borda.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
        
    }
	
    public bool distancia(Transform borda,Transform target)
    {
        float dist = Vector3.Distance(borda.position, target.position);
        //print(dist);
        if(dist < 5.0f)
        {
            return  dis = true;
        }else
        {
            return dis = false;
        }
    }

	// Update is called once per frame
	void Update () {
        //Distancia do image target pra borda
        float width = Vector3.Distance(topL.position, topR.position);
        float height = Vector3.Distance(topR.position, botR.position);

        distancia(borda,target);
        //print("A Largura é "+ width+ "A Altura é " + height);
    }
}
