using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escalade : MonoBehaviour
{
    public string namePlayer;
    public int cooldown;

    private void Start()
    {
        cooldown = 0;
    }

    void Update()
    {
        if (cooldown > 0)
        {
            cooldown++;
        }
        if (cooldown > 200)
        {
            cooldown = 0;
        }
    }

    private void OnTriggerStay(Collider leCollider) {
        if(leCollider.name == namePlayer)
        {

            if(Input.GetKeyDown ("e"))
            {
                if(leCollider.GetComponent<Player>().escalade > 1 && cooldown == 0)
                {
                    print("chnagement de scene, vers scène 3");
                    cooldown = 1;
                    transform.gameObject.tag = "LoadZoneEscalade";
                    GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().desactiveTache(4); //desactive la tache
                    //changement de scène
                }
                else{
                    leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Je n'ai pas le niveau en escalade pour grimper la haut !";

                }
            }
        }
    }
    void OnTriggerEnter(Collider leCollider)
    {
        if(leCollider.name == namePlayer)
        {
            GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().activeTache(4); //Active la tache (si pas encore activé)

            leCollider.transform.GetChild(10).gameObject.SetActive(true);
            leCollider.transform.GetChild(10).gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Escalader (E)";

            leCollider.transform.GetChild(11).gameObject.SetActive(true);
            leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Il y a des bonne prise d'escalde ici !";
        }
    }
    void OnTriggerExit(Collider leCollider)
    {
        if(leCollider.name == namePlayer)
        {
            leCollider.transform.GetChild(10).gameObject.SetActive(false);
            leCollider.transform.GetChild(11).gameObject.SetActive(false);
        }
    }
}
