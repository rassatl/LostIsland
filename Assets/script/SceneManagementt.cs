using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{
    static int sceneIndex = 0;
    void Start()
    {
        sceneIndex++;
        SceneManager.LoadScene(sceneIndex) ;
    }
    void Update()
    {
        
    }
}
