using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class bateauFin : MonoBehaviour
{
    public string namePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("CanvasVie").SetActive(false);
                GameObject.Find("tacheCanvas").SetActive(false);
                SceneManager.LoadScene("AnimFin");

            }
        }
    }
}
