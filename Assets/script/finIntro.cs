using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class finIntro : MonoBehaviour
{
    public double chrono;
    // Start is called before the first frame update
    void Start()
    {
        chrono = 0;
    }

    // Update is called once per frame
    void Update()
    {
        chrono += Time.deltaTime;
        if (chrono >= 20)
        {
            SceneManager.LoadScene("LoadingScene");
        }
    }
}
