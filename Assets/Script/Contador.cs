using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Contador : MonoBehaviour {
    public float cont = 3.0f;
    public GameObject contador;
    public bool cond;
    
    void Start()
    {
        cond = false;
    }
    // Update is called once per frame
    void Update () {
        if (cond)
        {
            if (cont > 0.0f)
            {
                cont -= Time.deltaTime;
            }
            
        }
        GetComponent<TextMesh>().text = cont.ToString("f0");
    }
}
