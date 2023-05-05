using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toileAvionTrigger : MonoBehaviour
{
    public string namePlayer;
    public bool recupere;
    public int cooldown;

    private void Start() {
        recupere = false;
        cooldown = 0;
    }

    private void OnTriggerStay(Collider leCollider) {
        if(leCollider.name == namePlayer)
        {
            if (Input.GetKeyDown ("e") && cooldown == 0)
            {
                if(!recupere)
                {
                    recupere = true;
                    cooldown = 1;
                    leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Et hop parfait pour la tente !";
                }
                else
                {
                    cooldown = 1;
                    leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "J'ai déjà récupéré son contenu !";
                }
            }
        }
    }
    void OnTriggerEnter(Collider leCollider)
    {
        if(leCollider.name == namePlayer)
        {
            leCollider.transform.GetChild(10).gameObject.SetActive(true);
            leCollider.transform.GetChild(10).gameObject.transform.GetChild(1).GetComponent< UnityEngine.UI.Text> ().text = "Ouvrir le coffre (E)";

            leCollider.transform.GetChild(11).gameObject.SetActive(true);
            leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Ce coffre contient peut être quelque chose !";
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

    void Update()
    {
        if(cooldown > 0)
        {
            cooldown++;
        }
        if(cooldown > 200)
        {
            cooldown = 0;
        }
    }
}
