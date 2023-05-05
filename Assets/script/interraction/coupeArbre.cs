using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coupeArbre : MonoBehaviour
{
    public string namePlayer;
    public Animator anim;
    public bool couper;
    public int indexArbre;

    void Start()
    {
        couper = false;
    }


    private void OnTriggerStay(Collider leCollider) {
        if(leCollider.name == namePlayer && couper == false)
        {
            if(Input.GetKeyDown ("e"))
            {
                anim.SetBool("coupe",true);
                couper = true;                
                leCollider.transform.GetChild(10).gameObject.SetActive(false);
                leCollider.GetComponent<persistenceScene>().listArbreScene1[indexArbre] = true;

                float radius = 0.1f;
                List<GameObject> listeObjets = new List<GameObject>();
                for (int i = 0; i < 3; i++)
                {
                    listeObjets.Add(MonoBehaviour.Instantiate(GameObject.Find("Modele_Bois")));
                    listeObjets[i].name = gameObject.name + "_" + i;
                    listeObjets[i].transform.position = new Vector3(gameObject.transform.position.x, Random.Range(gameObject.transform.position.y + 1 + radius, gameObject.transform.position.y + 10), gameObject.transform.position.z );
                    listeObjets[i].AddComponent<PickableObject>();
                    listeObjets[i].GetComponent<PickableObject>().player = GameObject.Find(ZoneDepot.NOMOBJET_JOUEUR).transform;
                    listeObjets[i].GetComponent<PickableObject>().playerCam = GameObject.Find(ZoneDepot.NOMOBJET_CAMERA).transform;
                    listeObjets[i].transform.parent = GameObject.Find(ZoneDepot.NOMOBJET_CONTENT_OBJETS_COLLECTABLE).transform;
                }


            }
        }
    }

    void OnTriggerEnter(Collider leCollider)
    {
        if(leCollider.name == namePlayer && couper == false)
        {
            leCollider.transform.GetChild(10).gameObject.SetActive(true);
            leCollider.transform.GetChild(10).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Couper l'arbre (E)";
        }
    }
    void OnTriggerExit(Collider leCollider)
    {
        if(leCollider.name == namePlayer && couper == false)
        {
            leCollider.transform.GetChild(10).gameObject.SetActive(false);
        }
    }
}
