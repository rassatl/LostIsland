using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caillouxLevierScene3 : MonoBehaviour
{

    public string namePlayer;
    public Animator animator;

    private void OnTriggerStay(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            if (Input.GetKeyDown("e") && leCollider.GetComponent<Player>().nbOs > 0)
            {
                print("je degage l'entré");
                animator.SetBool("roule", true);
                leCollider.GetComponent<persistenceScene>().rocherScene3 = true;
                GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().desactiveTache(5); //desactive la tache

            }
        }
    }
    void OnTriggerEnter(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().activeTache(5); //active la tache (si pas encore activé)

            leCollider.transform.GetChild(11).gameObject.SetActive(true);
            if(leCollider.GetComponent<Player>().nbOs == 0)
            {
                leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Peut être que en faisant levier sur ce rocher, je pourrait dégager l'entrée de la grotte !";
            }
            else
            {
                leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Mon os pourrait faire l'affaire !";
                leCollider.transform.GetChild(10).gameObject.SetActive(true);
                leCollider.transform.GetChild(10).gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Faire levier (E)";
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
