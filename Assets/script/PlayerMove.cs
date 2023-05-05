﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public int cooldown;
    public Transform player;
    public int y;
    public float vitesse;
    public float vitesseRotation;
    Animator animator;
    public int directionVariable;

    public int time1;
    public int time2;
    public int time3;

    void Start()
    {
        cooldown = 0;
        y = 0;
        vitesse = 0.2f;
        vitesseRotation = 0.2f;
        animator = GetComponent<Animator>();

        time1 =  Random.Range (200, 400);
        time2 =  Random.Range (500, 700);
        time3 =  Random.Range (900, 1100);

    }

    // Update is called once per frame
    void Update()
    {
        
        cooldown++;
        if(cooldown >= 0 && cooldown < time2)
        {
            player.transform.Translate(0,0,1*Time.deltaTime*vitesse);
            animator.SetBool("Walk",true);
        }
        
    }
}
