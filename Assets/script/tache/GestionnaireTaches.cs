using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireTaches : MonoBehaviour
{
    
    public List<Tache> listeTaches;
    public GameObject uiTache;
    public GameObject canvas;
    public GameObject player;

    void Start()
    {
        listeTaches = new List<Tache>();
        listeTaches.Add(new Tache(1,"Construire une tente", 10, true, "architecte", 1));
        listeTaches.Add(new Tache(2,"Construire un bateau", 25, true, "architecte", 1));
        listeTaches.Add(new Tache(3,"Tuer un poulet", 25, true, null, 0));
        listeTaches.Add(new Tache(4,"Monter le mur", 240, false, "escalade", 2));
        listeTaches.Add(new Tache(5,"Ouvrir la grotte", 550, false, null, 0));
        listeTaches.Add(new Tache(6,"Aller sur la petite ile", 300, false, "nage", 2));
        listeTaches.Add(new Tache(7,"Allumer le feu", 300, false, "maitreDuFeu", 1));
        listeTaches.Add(new Tache(8,"Faire cuire un poulet", 30, false, null, 0));
        listeTaches.Add(new Tache(9,"Decouvrir un autre monde", 70, false, null, 0));
        listeTaches.Add(new Tache(10,"Traverser le petit lac", 40, false, "nage", 1));
        listeTaches.Add(new Tache(11,"Donner au squellette le cigare", 310, false, null, 0));
        listeTaches.Add(new Tache(12,"Ecrire SOS avec des rochers", 230, false, null, 0));
        UpdateList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activeTache(int id)
    {
        foreach (Tache uneTache in listeTaches)
        {
            if(uneTache.Id == id)
            {
                if(!(uneTache.Fait) && !(uneTache.Affiche))
                {
                    uneTache.Affiche = true;
                    UpdateList();
                }
                
            }
        }
    }

    public void desactiveTache(int id)
    {
        foreach (Tache uneTache in listeTaches)
        {
            if (uneTache.Id == id && !(uneTache.Fait))
            {
                uneTache.Affiche = false;
                uneTache.Fait = true;
                UpdateList();
                player.GetComponent<Player>().experience(uneTache.Xp);

            }
        }
    }

    public void UpdateList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i).gameObject;
            Destroy(child);
        }
        int nbTacheAffiche = 0;
        foreach(Tache uneTache in listeTaches)
        {
            if(uneTache.Affiche)
            {
                nbTacheAffiche++;
                GameObject laTache = MonoBehaviour.Instantiate(uiTache, new Vector3(1450, 900 - nbTacheAffiche * 80), transform.rotation);
                laTache.transform.parent = canvas.transform;
                laTache.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = uneTache.Name;

                string niveauCompetenceModif = "";
                if (uneTache.NiveauCompetence != 0)
                    niveauCompetenceModif = uneTache.NiveauCompetence.ToString();
                laTache.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = uneTache.Competence + " " + niveauCompetenceModif;
                uiTache.transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = uneTache.Xp.ToString()+" XP";

            }
        }
    }



}

public class Tache
{
    private int id;
    private string name;
    private int xp;
    private bool fait;
    private bool affiche;
    private string competence;
    private int niveauCompetence;

    public string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            this.name = value;
        }
    }

    public int Xp
    {
        get
        {
            return this.xp;
        }

        set
        {
            this.xp = value;
        }
    }

    public bool Fait
    {
        get
        {
            return this.fait;
        }

        set
        {
            this.fait = value;
            if(value)
            {
                Affiche = false;
            }
        }
    }

    public bool Affiche
    {
        get
        {
            return this.affiche;
        }

        set
        {
            this.affiche = value;
        }
    }

    public string Competence
    {
        get
        {
            return this.competence;
        }

        set
        {
            this.competence = value;
        }
    }

    public int NiveauCompetence
    {
        get
        {
            return this.niveauCompetence;
        }

        set
        {
            this.niveauCompetence = value;
        }
    }

    public int Id
    {
        get
        {
            return this.id;
        }

        set
        {
            this.id = value;
        }
    }

    public Tache(int id, string nom, int exp, bool affiche,string competence, int niveauCompetence)
    {
        this.Id = id;
        this.Name = nom;
        this.Xp = exp;
        this.Affiche = affiche;
        this.Competence = competence;
        this.NiveauCompetence = niveauCompetence;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

