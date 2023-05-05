using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1 : MonoBehaviour
{

    // Start is called before the first frame update
    public static int sceneIndex = 1;
    void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.tag == "LoadZone")
        {
            Debug.Log("LoadZone");
            SceneManager.LoadScene(sceneIndex);
            sceneIndex++;
        }*/
        if (collision.gameObject.tag == "LoadZone")
        {
            transform.position += new Vector3(0,100,0);
            Debug.Log("climb");
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
