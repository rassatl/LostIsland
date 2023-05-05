using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Internet : MonoBehaviour
{
    public string url = "www.google.com";
    public double chrono;
    public Button bouton;

    // Start is called before the first frame update
    void Start()
    {
        chrono = 0;
        bouton.onClick.AddListener(VerifierInternet);
    }

    // Update is called once per frame
    void Update()
    {
        chrono += Time.deltaTime;
    }

    public void VerifierInternet()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SendWebRequest();

        while (request.isDone || chrono >= 15);
        
        if (chrono >= 15)
        {
            request.Abort();
        }
    }
}
