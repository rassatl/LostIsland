using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierePoisonScene6 : MonoBehaviour
{
    public string namePlayer;

    void OnTriggerEnter(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            leCollider.transform.GetChild(11).gameObject.SetActive(true);
            leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Hmm se n'est pas de l'eau mais bien du poison mortel si on le touche !";
        }
    }
    void OnTriggerExit(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            leCollider.transform.GetChild(11).gameObject.SetActive(false);
        }
    }
}
