using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ReadTarget : MonoBehaviour, ITrackableEventHandler
{

    private TrackableBehaviour mTrackableBehaviour;

    private Contador cont;
    public GameObject contador;
    public GameObject target;
    public GameObject tela;
    public Text uiText;

    void Start()
    {
       //acont = gameObject.GetComponent<Contador>();

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
              TrackableBehaviour.Status previousStatus,
              TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }
    private void OnTrackingFound()
    {
        bool teste = target.GetComponent<ImageTargetScale>().dis;
        //print(teste);
        
        print("Entrou no if");
        contador.GetComponent<Contador>().cond = true;
        contador.GetComponent<MeshRenderer>().enabled = true;
        uiText.GetComponent<TextScript>().textUi.enabled = true;
        tela.GetComponent<SpriteRenderer>().enabled = true;



    }
    private void OnTrackingLost()
    {
        tela.GetComponent<SpriteRenderer>().enabled = false;
        contador.GetComponent<MeshRenderer>().enabled = false;
        uiText.GetComponent<TextScript>().textUi.enabled = false;
        contador.GetComponent<Contador>().cond = false;
    }
}
