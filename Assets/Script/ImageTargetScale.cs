using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTargetScale : MonoBehaviour {
    public Transform topL;
    public Transform topR;
    public Transform botL;
    public Transform botR;

    //public Transform fake;

    public Transform borda;
    //public Transform target;

    //float x = Screen.width;
    //float y = Screen.height;

    public Transform BtopL;
    public Transform BtopR;
    public Transform BbotL;
    public Transform BbotR;

    public Camera cam;
    public TextScript t;

    public bool dis;

    // Use this for initialization
    void Start () {
       //print("Largura="+x+"Altura="+y);
        dis = false;
        //fake.transform.position = new Vector3(borda.position.x, target.position.y, target.position.z);
        //borda.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));

    }


    /*
    public bool distancia(Transform borda,Transform target)
    {
        float dist = Vector3.Distance(borda.position, target.position);
        print(dist);
        if(dist < 10.0f)
        {
            return  dis = true;
        }else
        {
            return dis = false;
        }
    }
    */
    // Update is called once per frame
    void Update()
    {
        //Distancia do image target pra borda
        //Vector 3 do canto superio esquerdo image target
        Vector3 TopL = cam.WorldToScreenPoint(topL.position);
        //Vector 3 do canto superio esquerdo Moldura
        Vector3 BordaTopL = cam.WorldToScreenPoint(BtopL.position);
        //Vector 3 do canto superio esquerdo image target
        Vector3 botR = cam.WorldToScreenPoint(topR.position);
        //Vector 3 do canto superio esquerdo Moldura
        Vector3 BordaBotR = cam.WorldToScreenPoint(BtopR.position);
        //Canto superior esquerdo tem que ta dentro moldura

        if (TopL.x > BordaTopL.x && TopL.y < BordaTopL.y && botR.x < BordaBotR.x && botR.y < BordaBotR.y)
        {
            dis = true;
        }else
        {
            dis = false;
        }

        string ttt = "Top Target = X: " + TopL.x.ToString("f1") + "Borda = X:" + BordaTopL.x.ToString("f1") + "\nTarget = Y:" + TopL.y.ToString("f1") + "Borda = Y:"+ BordaTopL.y.ToString("f1")+ "\nBot Target = X: " + botR.x.ToString("f1") + "Borda = X:" + BordaBotR.x.ToString("f1") + "\nTarget = Y:" + botR.y.ToString("f1") + "Borda = Y:" + BordaBotR.y.ToString("f1");

        t.txt = ttt;

        //float width = Vector3.Distance(topL.position, topR.position);
        // float height = Vector3.Distance(topR.position, botR.position);

        //distancia(borda,target);
        //print("A Largura é "+ width+ "A Altura é " + height);
    }

}
