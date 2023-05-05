using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadZone : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    private void OnTriggerStay(Collider leCollider)
    {
        switch (leCollider.gameObject.tag)
        {
            case "LoadZoneEscalade":
                switch (SceneManager.GetActiveScene().name)
                {
                    case "Scene1":
                        print("Bonne scene");

                        SceneManager.LoadScene("Scene3");
                        Player.lastSpawnPos = transform.position = new Vector3(20.11f, 4f, -8.5f);
                        Player.lastSpawnRot = transform.rotation = new Quaternion(0, 31.85f, 0, 90);

                        break;
                    case "Scene3":
                        SceneManager.LoadScene("Scene1");
                        Player.lastSpawnPos = transform.position = new Vector3(13.22f, 3.79f, -5.03f);
                        Player.lastSpawnRot = transform.rotation = new Quaternion(0, -78.264f, 0, 90);
                        break;
                }
                break;
            case "LoadZoneCave":
                switch (SceneManager.GetActiveScene().name)
                {
                    case "Scene3":
                        print("Bonne scene");
                        transform.Find("Point Light").gameObject.SetActive(true);
                        SceneManager.LoadScene("Scene6");
                        Player.lastSpawnPos = transform.position = new Vector3(-13.23f, 25.14f, 9f);
                        Player.lastSpawnRot = transform.rotation = new Quaternion(0, 0, 0, 0);

                        break;
                    case "Scene6":
                        SceneManager.LoadScene("Scene3");
                        transform.Find("Point Light").gameObject.SetActive(false);
                        Player.lastSpawnPos = transform.position = new Vector3(0.652f, 3.93f, 3.588f);
                        Player.lastSpawnRot = transform.rotation = new Quaternion(0, 31.85f, 0, 90);
                        break;
                }
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {        
        switch (collision.gameObject.tag)
        {
            case "LoadZoneEscalade":
                print("LoadZoneEscalade");
                switch (SceneManager.GetActiveScene().name)
                {
                    case "Scene1":
                        print("Bonne scene");

                        SceneManager.LoadScene("Scene3");
                        Player.lastSpawnPos = transform.position = new Vector3(21.42f, 4.15f, -5.69f);
                        Player.lastSpawnRot = transform.rotation = new Quaternion(0, 31.85f, 0, 90);
                        
                        break;
                    case "Scene3":
                        SceneManager.LoadScene("Scene1");
                        Player.lastSpawnPos = transform.position = new Vector3(13.22f, 3.79f, -5.03f);
                        Player.lastSpawnRot = transform.rotation = new Quaternion(0, -78.264f, 0, 90);
                        break;
                }
                break;
            case "LoadZoneBoat1":
                switch (SceneManager.GetActiveScene().name)
                {
                    case "Scene1":
                        SceneManager.LoadScene("Scene2");
                        Player.lastSpawnPos = transform.position = new Vector3(77.85f, 30.8f, 16.93f);
                        Player.lastSpawnRot = transform.rotation = new Quaternion(0, -100.639f, 0, 90);
                        break;
                    case "Scene2":
                        SceneManager.LoadScene("Scene1");
                        Player.lastSpawnPos = transform.position = new Vector3(-1.27f, 3.4f, 8.93f);                        
                        Player.lastSpawnRot = transform.rotation = new Quaternion(0, 160, 0, 0);
                        break;


                }
                break;
            case "LoadZoneBoat2":
                switch (SceneManager.GetActiveScene().name)
                {
                    case "Scene2":
                        SceneManager.LoadScene("Scene4");
                        Player.lastSpawnPos = transform.position = new Vector3(46.42f, 162.2031f, -412.3979f);
                        Player.lastSpawnRot = transform.rotation = new Quaternion(0, -100.639f, 0, 90);
                        break;
                    case "Scene4":
                        SceneManager.LoadScene("Scene2");
                        print(transform.position);
                        Player.lastSpawnPos = transform.position = new Vector3(51.53f, 31.32f, 0.59f);
                        Player.lastSpawnRot = transform.rotation = new Quaternion(0, 160, 0, 0);
                        print(transform.position);
                        break;


                }

                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
