using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseMotherFucker : MonoBehaviour
{
    public string namePlayer;
    public GameObject Surprise;

    private void OnTriggerStay(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            if (Input.GetKeyDown("e"))
            {
                Surprise.SetActive(true);
            }
        }
    }
}
