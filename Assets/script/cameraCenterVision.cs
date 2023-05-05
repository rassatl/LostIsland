using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCenterVision : MonoBehaviour
{
    // Ce script fais tourner le canvas par rapport de où est le joueur 
    public Transform cam;
    void Start()
    {
        cam = GameObject.Find("Main Camera Player").transform;
    }
    void Update()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
