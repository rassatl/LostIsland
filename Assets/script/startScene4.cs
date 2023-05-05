using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScene4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().desactiveTache(9); //desactive la tache
        GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().activeTache(12); //active la tache (si pas encore activé)
        GameObject.Find("Player").transform.GetChild(11).gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
