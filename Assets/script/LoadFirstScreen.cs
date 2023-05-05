using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFirstScreen : MonoBehaviour
{
    public Player perso;
    private string scene = "Scene1";
    // Start is called before the first frame update
    void Start()
    {
        if (Boutons.newPart)
        {
            PlayerPrefs.DeleteAll();
            scene = "Scene1";
            perso.GetComponent<Player>().pv = 100;
            perso.GetComponent<Player>().xp = 0;
            perso.GetComponent<Player>().nage = 0;
            perso.GetComponent<Player>().escalade = 0;
            perso.GetComponent<Player>().maitreDuFeu = 0;
            perso.GetComponent<Player>().architecte = 1;
            perso.GetComponent<Player>().nbPouletCru = 0;
            perso.GetComponent<Player>().nbPouletCuit = 0;
            perso.GetComponent<Player>().nbSilex = 0;
            perso.GetComponent<Player>().nbOs = 0;
            perso.GetComponent<Player>().harpon = false;
            perso.GetComponent<Player>().goldCigare = false;
            SceneManager.LoadScene(scene);
        }
        else if (Database.connected)        
            Database.Get(perso);        
        else
        {
            scene = PlayerPrefs.GetString("scene");
            perso.GetComponent<Player>().pv = PlayerPrefs.GetInt("pv");
            perso.GetComponent<Player>().xp = PlayerPrefs.GetInt("xp");
            perso.GetComponent<PlayerH>().lvlPlayer = PlayerPrefs.GetInt("lvl");
            perso.GetComponent<Player>().nage = PlayerPrefs.GetInt("nage");
            perso.GetComponent<Player>().escalade = PlayerPrefs.GetInt("escalade");
            perso.GetComponent<Player>().maitreDuFeu = PlayerPrefs.GetInt("maitreDuFeu");
            perso.GetComponent<Player>().architecte = PlayerPrefs.GetInt("architecte");
            perso.GetComponent<Player>().nbPouletCru = PlayerPrefs.GetInt("nbPouletCru");
            perso.GetComponent<Player>().nbPouletCuit = PlayerPrefs.GetInt("nbPouletCuit");
            perso.GetComponent<Player>().nbSilex = PlayerPrefs.GetInt("nbSilex");
            perso.GetComponent<Player>().nbOs = PlayerPrefs.GetInt("nbOs");
            perso.GetComponent<Player>().harpon = PlayerPrefs.GetInt("harpon") == 1;
            perso.GetComponent<Player>().goldCigare = PlayerPrefs.GetInt("goldCigare") == 1;
            perso.transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
            perso.transform.rotation = new Quaternion(PlayerPrefs.GetFloat("rx"), PlayerPrefs.GetFloat("ry"), PlayerPrefs.GetFloat("rz"), PlayerPrefs.GetFloat("rw"));

            Player.lastSpawnPos = new Vector3(PlayerPrefs.GetFloat("sx"), PlayerPrefs.GetFloat("sy"), PlayerPrefs.GetFloat("sz"));
            Player.lastSpawnRot = new Quaternion(PlayerPrefs.GetFloat("srx"), PlayerPrefs.GetFloat("sry"), PlayerPrefs.GetFloat("srz"), PlayerPrefs.GetFloat("srw"));
            for (int i = 0; i < perso.GetComponent<persistenceScene>().listArbreScene1.Count; i++)
                perso.GetComponent<persistenceScene>().listArbreScene1[i] = PlayerPrefs.GetInt("arbre" + i) == 1;
            perso.GetComponent<persistenceScene>().rocherScene3 = PlayerPrefs.GetInt("rocher") == 1;
            foreach (Tache t in GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().listeTaches)
            {
                string values = PlayerPrefs.GetString(t.Name);
                t.Affiche = values[0] == '1';
                t.Fait = values[1] == '1';
            }

            SceneManager.LoadScene(scene);

            perso.GetComponent<Player>().StartPersistance();
        }

        
        if (scene == "Scene6")
        {
            perso.transform.Find("Point Light").gameObject.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
