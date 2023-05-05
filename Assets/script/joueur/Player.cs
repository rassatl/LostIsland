using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    public GameObject perso;
    public GameObject canvasCompetence;
    public GameObject feu1;
    public GameObject nageur1;
    public GameObject nageur2;
    public GameObject grimpeur1;
    public GameObject grimpeur2;

    public static Vector3 lastSpawnPos = new Vector3(-6, 3, -10);
    public static Quaternion lastSpawnRot = new Quaternion(0, 0, 0, 0);
    public int pv = 100;
    public int xp = 0;
    public int lvl = 0;

    public int nage = 0;
    public int escalade = 0;
    public int maitreDuFeu = 0;
    public int architecte = 1;

    //inventaire
    public int nbPouletCru = 0;
    public int nbPouletCuit = 0;
    public int nbSilex = 0;
    public int nbOs = 0;
    public bool harpon = false;
    public bool goldCigare = false;

    public Item rawChickenItem;
    public Item chickenItem;
    public Item flintItem;
    public Item osItem;
    public Item harponItem;
    public Item goldCigareItem;
    private GameObject inventoryManager;


    public void Menu()
    {
        if (Database.connected)
        {
            Database.Set(perso.GetComponent<Player>());
        }
        else
        {
            PlayerPrefs.SetInt("pv", pv);
            PlayerPrefs.SetInt("xp", xp);
            PlayerPrefs.SetInt("lvl", lvl);
            PlayerPrefs.SetInt("nage", nage);
            PlayerPrefs.SetInt("escalade", escalade);
            PlayerPrefs.SetInt("maitreDuFeu", maitreDuFeu);
            PlayerPrefs.SetInt("architecte", architecte);
            PlayerPrefs.SetInt("nbPouletCru", nbPouletCru);
            PlayerPrefs.SetInt("nbPouletCuit", nbPouletCuit);
            PlayerPrefs.SetInt("nbSilex", nbSilex);
            PlayerPrefs.SetInt("nbOs", nbOs);
            PlayerPrefs.SetInt("harpon", harpon ? 1 : 0);
            PlayerPrefs.SetInt("goldCigare", goldCigare ? 1 : 0);
            PlayerPrefs.SetString("scene", SceneManager.GetActiveScene().name);
            PlayerPrefs.SetFloat("x", perso.transform.position.x);
            PlayerPrefs.SetFloat("y", perso.transform.position.y);
            PlayerPrefs.SetFloat("z", perso.transform.position.z);
            PlayerPrefs.SetFloat("rx", perso.transform.rotation.x);
            PlayerPrefs.SetFloat("ry", perso.transform.rotation.y);
            PlayerPrefs.SetFloat("rz", perso.transform.rotation.z);
            PlayerPrefs.SetFloat("rw", perso.transform.rotation.w);

            PlayerPrefs.SetFloat("sx", lastSpawnPos.x);
            PlayerPrefs.SetFloat("sy", lastSpawnPos.y);
            PlayerPrefs.SetFloat("sz", lastSpawnPos.z);
            PlayerPrefs.SetFloat("srx", lastSpawnRot.x);
            PlayerPrefs.SetFloat("sry", lastSpawnRot.y);
            PlayerPrefs.SetFloat("srz", lastSpawnRot.z);
            PlayerPrefs.SetFloat("srw", lastSpawnRot.w);
            foreach (Tache t in GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().listeTaches)
                PlayerPrefs.SetString(t.Name, (t.Affiche ? "1" : "0") + (t.Fait ? "1" : "0"));
                
            for (int i = 0; i < transform.GetComponent<persistenceScene>().listArbreScene1.Count; i++)
                PlayerPrefs.SetInt("arbre" + i, transform.GetComponent<persistenceScene>().listArbreScene1[i] ? 1 : 0);
            PlayerPrefs.SetInt("rocher", transform.GetComponent<persistenceScene>().rocherScene3 ? 1 : 0);
        }        

        SceneManager.LoadScene(0);
        Destroy(perso.gameObject);
    }

    

    public void SetCompetence(string name, int level)
    {
        switch(name)
        {
            case "nage":
                nage = level;
                break;
            case "escalade":
                escalade = level;
                break;
            case "maitreDuFeu":
                maitreDuFeu = level;
                break;
        }
        if (nage > 0)
            nageur1.GetComponent<RawImage>().color = Color.white;
        if (nage > 1)
            nageur2.GetComponent<RawImage>().color = Color.white;
        if (escalade > 0)
            grimpeur1.GetComponent<RawImage>().color = Color.white;
        if (escalade > 1)
            grimpeur2.GetComponent<RawImage>().color = Color.white;
        if (maitreDuFeu > 0)
            feu1.GetComponent<RawImage>().color = Color.white;
    }

    public void StartPersistance()
    {
        inventoryManager = GameObject.Find("InventoryManager");

        //persistance competence
        if (nage > 0)
            nageur1.GetComponent<RawImage>().color = Color.white;
        if (nage > 1)
            nageur2.GetComponent<RawImage>().color = Color.white;
        if (escalade > 0)
            grimpeur1.GetComponent<RawImage>().color = Color.white;
        if (escalade > 1)
            grimpeur2.GetComponent<RawImage>().color = Color.white;
        if (maitreDuFeu > 0)
            feu1.GetComponent<RawImage>().color = Color.white;

        //percistence inventaire
        for(int i = 0; i< nbPouletCru;i++)
        {
            inventoryManager.GetComponent<InventoryManager>().UpdateInventory(rawChickenItem);
        }
        for (int i = 0; i < nbPouletCuit; i++)
        {
            inventoryManager.GetComponent<InventoryManager>().UpdateInventory(chickenItem);
        }
        for (int i = 0; i < nbSilex; i++)
        {
            inventoryManager.GetComponent<InventoryManager>().UpdateInventory(flintItem);
        }
        for (int i = 0; i < nbOs; i++)
        {
            inventoryManager.GetComponent<InventoryManager>().UpdateInventory(osItem);
        }
        if (harpon)
        {
            inventoryManager.GetComponent<InventoryManager>().UpdateInventory(harponItem);
        }
        if (goldCigare)
        {
            inventoryManager.GetComponent<InventoryManager>().UpdateInventory(goldCigareItem);
        }
        inventoryManager.GetComponent<InventoryManager>().ListItems();

        //persistance vie et xp
        GameObject.Find("Health Bar").GetComponent<HealthBar>().slider.value = pv;
        GameObject.Find("Experience Bar").GetComponent<ExperienceBar>().slider.value = xp;
        GameObject.Find("Experience Bar").GetComponent<ExperienceBar>().text.text = "Level : " + lvl;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Menu();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(canvasCompetence.activeInHierarchy == true)
                canvasCompetence.SetActive(false);
            else
                canvasCompetence.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            SetCompetence("escalade", 2);
            SetCompetence("nage", 2);
            SetCompetence("maitreDuFeu", 1);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            transform.GetComponent<Death>().Mort();
        }
    }

    //méthode qui augmente l'xp
    public void experience(int xpAjout)
    {
        xp += xpAjout;
        GameObject.Find("Experience Bar").GetComponent<ExperienceBar>().slider.value = xp;
        GameObject.Find("Experience Bar").GetComponent<ExperienceBar>().text.text = "Level : " + lvl;


        if (xp > 700)
        {
            lvl = GameObject.Find("Experience Bar").GetComponent<ExperienceBar>().AddLvl(xp, lvl);
            xp -= 700;
            
        }
        /*
        expPlayer += xp;
        experienceBar.AddExp(expPlayer);*/
    }


}
