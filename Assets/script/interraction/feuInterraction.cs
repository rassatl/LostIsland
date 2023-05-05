using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feuInterraction : MonoBehaviour
{
    public string namePlayer;
    public bool allumer;
    public bool silex;
    public GameObject leFeuDeCamp;
    public GameObject chicken;
    public Item chickenItem;
    public Item rowChickenItem;
    public bool cuit;
    public int cooldown;
    public int count;
    private GameObject player;

    private GameObject inventoryManager;


    void Start()
    {
        allumer = false;
        cuit = false;
        cooldown = 0;
        count = 0;
        GameObject.Find("barProgressCuisson").transform.localScale = new Vector3(0, 0.07f, 0);
        inventoryManager = GameObject.Find("InventoryManager");
    }
    private void OnTriggerStay(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            if (Input.GetKeyDown("e"))
            {
                if(!(allumer) && leCollider.GetComponent<Player>().nbSilex > 0 && leCollider.GetComponent<Player>().maitreDuFeu > 0)
                {
                    leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Allluummmerrrr le feuuuuuuuuu !";
                    allumer = true;
                    leFeuDeCamp.SetActive(true);
                    GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().desactiveTache(7); //desactive la tache
                }
                else if(!(allumer) && !(leCollider.GetComponent<Player>().maitreDuFeu > 0))
                {
                    leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Mais comment faire un feu ? il faut que je trouve la technique !";
                }
                else if (!(allumer) && leCollider.GetComponent<Player>().maitreDuFeu > 0 && !(leCollider.GetComponent<Player>().nbSilex > 0))
                {
                    leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Bon, il me reste plus qu'à trouver un silex pour allumer le feu !";
                }else if(allumer && leCollider.GetComponent<Player>().nbPouletCru > 0 && !(cuit))
                {
                    inventoryManager.GetComponent<InventoryManager>().Remove(rowChickenItem);
                    inventoryManager.GetComponent<InventoryManager>().ListItems();
                    leCollider.transform.GetChild(10).gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Faire cuire du poulet (E)";
                    leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Aller hop un poulet sur le feu !";
                    leCollider.GetComponent<Player>().nbPouletCru--;
                    player = leCollider.gameObject;
                    cooldown = 1;
                    cuit = true;
               
                    GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().desactiveTache(8); //desactive la tache
                    GameObject lePouletSurLeFeu = MonoBehaviour.Instantiate(chicken, new Vector3(75.89f, 31.36f,20.27f), transform.rotation);
                    lePouletSurLeFeu.transform.parent = this.transform;
                    lePouletSurLeFeu.transform.localScale = new Vector3(3.85f, 3.85f, 3.85f);
                }
                else if (allumer && leCollider.GetComponent<Player>().nbPouletCru == 0)
                {
                    leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Il me faut du poulet cru !";

                }


            }
        }
    }
    void OnTriggerEnter(Collider leCollider)
    {
        GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().activeTache(7); //active la tache (si pas encore activé)


        if (leCollider.name == namePlayer)
        {
            leCollider.transform.GetChild(10).gameObject.SetActive(true);
            if(allumer)
            {
                leCollider.transform.GetChild(10).gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Faire cuire du poulet (E)";
            }
            else
            {
                leCollider.transform.GetChild(10).gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Faire du feu (E)";
            }
            

            leCollider.transform.GetChild(11).gameObject.SetActive(true);
            leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Hmm il faudrais que je fasse du poulet ici !";
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

    void Update()
    {
        if(cooldown > 0)
        {
            cooldown++;
            if(cooldown > 100)
            {
                count++;
                GameObject.Find("barProgressCuisson").transform.localScale += new Vector3(0.1f, 0f, 0f);
                GameObject.Find("barProgressCuisson").transform.Translate(0.06f, 0, 0);
                cooldown = 1;
            }
            if (count > 5)
            {
                cooldown = 0;
                count = 0;
                player.GetComponent<Player>().nbPouletCuit++;
                Destroy(transform.GetChild(2).gameObject);
                GameObject.Find("barProgressCuisson").transform.Translate(-0.06f*6, 0, 0);
                GameObject.Find("barProgressCuisson").transform.localScale -= new Vector3(0.1f*6, 0f, 0f);
                cuit = false;
                inventoryManager.GetComponent<InventoryManager>().UpdateInventory(chickenItem);
                inventoryManager.GetComponent<InventoryManager>().ListItems();


            }

        }
    }


}
