using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerH : MonoBehaviour
{
    public int viePlayer;
    public int viePlayerMax = 100;

    public int expPlayer;
    public int expMax = 800;
    public int expMin = 0;

    public int lvlPlayer;
    public int lvlPlayerMin = 0;
    public int lvlPlayerMax = 3;

    public HealthBar healthBar;
    public ExperienceBar experienceBar;

    public static PlayerH Instance;

    public void Awake()
    {
        Instance = this;
    }

    //set la vie au début
    void Start()
    {
        viePlayer = viePlayerMax;
        healthBar.SetMaxHealth(viePlayerMax);
        lvlPlayer = lvlPlayerMin;
        expPlayer = expMin;
        experienceBar.SetDefaultXp(expMin, lvlPlayer);
    }

    //méthode qui diminue la vie quand on appuie sur espace
    void Update()
    {

        



    }



    //méthode qui augmente la vie
    public void degat(int degat)
    {
        viePlayer -= degat;

        healthBar.SetHealth(viePlayer);
        healthBar.slider.value = viePlayer;
        GetComponent<Player>().pv -= degat;
        /*
        if(viePlayer <= 0)
        {
            Anim.SetBool("IsDead", true);
        }*/
    }



    //méthode qui diminue la vie
    public void soins(int soin)
    {
        viePlayer += soin;
        healthBar.slider.value = viePlayer;

        if (viePlayer > viePlayerMax)
        {
            viePlayer = viePlayerMax;
        }
    }
}
