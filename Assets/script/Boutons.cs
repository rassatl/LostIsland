using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Boutons : MonoBehaviour
{
    public string url = "www.google.com";
    public bool internet;
    public double chrono;
    public static bool newPart;
    public UnityWebRequest request;

    // Start is called before the first frame update
    void Start()
    {
        request = UnityWebRequest.Get(url);
        GameObject.Find("Connexion").gameObject.SetActive(true);
        request.SendWebRequest();
        if (request.isDone)
        {
            internet = true;
        }
        else
        {
            internet = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Boutons de la scene Menu
    public void PlayButton()
    {
        if (!PlayerPrefs.HasKey("pv") && !Database.connected)
        {
            SceneManager.LoadScene("AnimAv");
            newPart = true;
        }
        else
        {
            newPart = false;
            SceneManager.LoadScene("LoadingScene");
        }            
    }
    public void NewPartButton()
    {
        SceneManager.LoadScene("AnimAv");
        newPart = true;
    }

    public void ConnexionButton()
    {
        // if (internet)
        // {
        SceneManager.LoadScene("Connexion");
        // }
        //else
        // {
        //     GameObject.Find("Connexion").gameObject.SetActive(false);
        // }
    }

    public void SettingButton()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    //Boutons de la scene Connexion
    public void ValiderButton()
    {
        string id = GameObject.Find("InputId").GetComponent<TMP_InputField>().text;
        string password = GameObject.Find("InputPassword").GetComponent<TMP_InputField>().text;

        GameObject.Find("Main Camera").GetComponent<Database>().Log(id, password);

        SceneManager.LoadScene("Menu");
    }

    //Boutons de la scene Settings
    public void RetourButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
