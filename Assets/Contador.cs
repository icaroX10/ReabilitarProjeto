using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Contador : MonoBehaviour {
    private float cont = 100.0f;
    public GameObject contador;

    public void Conta()
    {
        if (cont > 0.0f)
        {
            cont -= Time.deltaTime;
            //print(cont);
        }
    }

    // Update is called once per frame
    void Update () {
        GetComponent<TextMesh>().text = cont.ToString("f0");
    }
}
