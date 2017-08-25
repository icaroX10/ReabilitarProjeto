using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class ReadTarget : MonoBehaviour, ITrackableEventHandler
{

    private TrackableBehaviour mTrackableBehaviour;

    private Contador cont;
    public GameObject contador;
    public GameObject target;

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
        print(teste);
        if (teste)
        {
            print("Entrou no if");
            contador.GetComponent<Contador>().cond = true;

        }else
        {
            contador.GetComponent<Contador>().cond = false;
        }
        print("Ta lendo");
        
        
    }
    private void OnTrackingLost()
    {
        contador.GetComponent<Contador>().cond = false;
    }
}
