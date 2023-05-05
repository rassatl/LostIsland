using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squelletteInterraction : MonoBehaviour
{
    public string namePlayer;
    private GameObject inventoryManager;
    public Item harponItem;
    public Item cigareItem;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;

    private bool activeSound;
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager");
        activeSound = false;

    }

    void OnTriggerStay(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            if (Input.GetKeyDown("e") && leCollider.GetComponent<Player>().goldCigare)
            {
                inventoryManager.GetComponent<InventoryManager>().Remove(cigareItem);
                inventoryManager.GetComponent<InventoryManager>().UpdateInventory(harponItem); //pour l'inventaire
                inventoryManager.GetComponent<InventoryManager>().ListItems();
                leCollider.GetComponent<Player>().goldCigare = false;
                leCollider.GetComponent<Player>().harpon = true;
                leCollider.transform.GetChild(11).gameObject.SetActive(true);
                leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Un échange...particulier ! Mais merci pour l'arpon";
            }
        }
    }
    void OnTriggerEnter(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            if (leCollider.GetComponent<Player>().goldCigare)
            {
                GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().desactiveTache(11); //desactive la tache 

                leCollider.transform.GetChild(10).gameObject.SetActive(true);
                leCollider.transform.GetChild(10).gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Donner le cigare (E)";
            }
            else
            {
                GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().activeTache(11); //active la tache (si pas encore activé)
                                                                                                   //conv avec le squellette
                if (!activeSound)
                {
                    activeSound = true;
                    gameObject.GetComponent<AudioSource>().PlayOneShot(clip1);
                    StartCoroutine(playSound2());
                }
                

            }


        }
    }

    IEnumerator playSound2()
    {
        yield return new WaitForSeconds(clip1.length+1);
        gameObject.GetComponent<AudioSource>().PlayOneShot(clip2);
        StartCoroutine(playSound3());
    }

    IEnumerator playSound3()
    {
        yield return new WaitForSeconds(clip2.length+0.5f);
        gameObject.GetComponent<AudioSource>().PlayOneShot(clip3);
        StartCoroutine(playSound4());
    }
    IEnumerator playSound4()
    {
        yield return new WaitForSeconds(clip3.length+0.5f);
        gameObject.GetComponent<AudioSource>().PlayOneShot(clip4);
        StartCoroutine(playSoundFinish());        
    }
    IEnumerator playSoundFinish()
    {
        yield return new WaitForSeconds(clip4.length+0.5f);
        activeSound = false;
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
