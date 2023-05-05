using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Slider slider;
    public Text text;

    public Sprite sprite0;
    public Sprite sprite1;
    public Sprite sprite2;

    //met au lancement les values de base
    public void SetDefaultXp(int xp, int lvl)
    {
        slider.value = xp;
        slider.minValue = xp;
        lvl = 0;
        text.text = "Level : " + lvl;
        GameObject.Find("XP").GetComponent<Image>().sprite = sprite0;
    }


    //add l'xp obtenu
    public int AddLvl(int xp, int lvl)
    {
        slider.value = xp;
        lvl++;
        text.text = "Level : " + lvl;
        switch (lvl)
        {
            case 1:
                GameObject.Find("XP").GetComponent<Image>().sprite = sprite1;
                GameObject.Find("Player").GetComponent<Player>().SetCompetence("escalade", 2);
                break;
            case 2:
                GameObject.Find("XP").GetComponent<Image>().sprite = sprite2;
                GameObject.Find("Player").GetComponent<Player>().SetCompetence("nage", 2);
                break;
            default:
                GameObject.Find("XP").GetComponent<Image>().sprite = sprite2;
                break;
        }
        return lvl;
    }       
}
