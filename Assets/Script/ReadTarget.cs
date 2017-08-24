using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class ReadTarget : MonoBehaviour, ITrackableEventHandler
{

    private TrackableBehaviour mTrackableBehaviour;

    private Contador cont;

    void Start()
    {
       cont = gameObject.GetComponent<Contador>();

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
        /*
        else
        {
            OnTrackingLost();
        }*/
    }
    private void OnTrackingFound()
    {
        cont.Conta();
        print("Ta lendo");

    }
}
