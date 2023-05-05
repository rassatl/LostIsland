using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flecheScene2 : MonoBehaviour
{
    public string namePlayer;

    void OnTriggerEnter(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().activeTache(9); //active la tache (si pas encore activé)

            leCollider.transform.GetChild(11).gameObject.SetActive(true);
           leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Hmm cette flèche a été créé par quequ'un ! Elle indique peut être un autre monde ! Il me faut un bateau !";
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
