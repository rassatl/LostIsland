using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocherAvantLacScene2 : MonoBehaviour
{
    public string namePlayer;

    void OnTriggerEnter(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            if (leCollider.GetComponent<Player>().nage > 0)
            {
                leCollider.transform.GetChild(11).gameObject.SetActive(true);
                leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "C'est bon je peux nager jusqu'à l'autre coté !";
                GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().desactiveTache(10); //desactive la tache 
            }
            else
            {
                GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().activeTache(10); //active la tache (si pas encore activé)

                leCollider.transform.GetChild(11).gameObject.SetActive(true);
                leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Je ne pourrais pas aller de l'autre coter sans savoir nager !";
            }

        }
    }
    void OnTriggerExit(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            leCollider.transform.GetChild(10).gameObject.SetActive(false);
            leCollider.transform.GetChild(11).gameObject.SetActive(false);
        }
    }
}
