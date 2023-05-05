using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ileFinal : MonoBehaviour
{
    public string namePlayer;
    public GameObject swim;

    void OnTriggerStay(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            if (Input.GetKeyDown("e"))
            {
                if(leCollider.GetComponent<Player>().harpon && leCollider.GetComponent<Player>().nage > 1)
                {
                    swim.gameObject.SetActive(true);
                    GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().desactiveTache(6); //desactive la tache
                    leCollider.transform.GetChild(11).gameObject.SetActive(true);
                    GameObject.Find("Sharks").gameObject.SetActive(false);
                    leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "C'est bon les requins sont mort je vais pouvoir aller de l'autre coter !";
                }

                else
                {
                    leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Il me manque soit un harpon pour tuer les requins soit je ne sais pas assez bien nager !";

                }
            }
            
        }
    }
    void OnTriggerEnter(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().activeTache(6); //active la tache (si pas encore activé)
            leCollider.transform.GetChild(11).gameObject.SetActive(true);
            if (leCollider.GetComponent<Player>().harpon)
            {
                leCollider.transform.GetChild(10).gameObject.SetActive(true);
                leCollider.transform.GetChild(10).gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Tirez sur les requin avec l'arpon (E)";

                leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Maintenant que j'ai l'arpon, je vais pouvoir les tuer !";
            }
            else
            {
                leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Hoo sur l'île là bas il y a mon sac à dos avec mon telephone sattelite ! mais il y a des requin je peut pas nager jusqu'à là bas... !";
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
