using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecupCompetence : MonoBehaviour
{
    public string namePlayer;
    public GameObject competence;
    public GameObject competenceRecup;
    public string competenceName;
    private void OnTriggerStay(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            if (Input.GetKeyDown("e"))
            {
                switch (competenceName)
                {
                    case "Maitre Du Feu":
                        leCollider.GetComponent<Player>().SetCompetence("maitreDuFeu", 1);
                        break;
                    case "Nageur":
                        leCollider.GetComponent<Player>().SetCompetence("nage", 1);
                        break;
                    case "Grimpeur":
                        if(leCollider.GetComponent<Player>().escalade == 0)
                            leCollider.GetComponent<Player>().SetCompetence("escalade", 1);
                        break;
                }
                
                leCollider.transform.GetChild(10).gameObject.SetActive(false);
                competenceRecup.SetActive(true);
                competence.SetActive(false);
                leCollider.transform.GetChild(11).gameObject.SetActive(false);
            }
        }
    }
    void OnTriggerEnter(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            leCollider.transform.GetChild(10).gameObject.SetActive(true);
            leCollider.transform.GetChild(10).gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Apprendre compétence <"+ competenceName+ "> (E)";

            leCollider.transform.GetChild(11).gameObject.SetActive(true);
            leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "J'ai l'impression que cette objet magique pourrait m'apprendre quelque chose !";
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
