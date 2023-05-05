using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Animator anim;
    public GameObject chicken;
    private bool swordOut = false;
    private float time = 0;
    public AudioClip clip;
    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("Sword")|| anim.GetBool("Attack"))
            time += 0.015f;
        if (time > 0.617f && anim.GetBool("Sword"))
        {
            anim.SetBool("Sword", false);
            time = 0;
            transform.GetChild(2).gameObject.SetActive(true);
        }
        if (time > 0.8f && anim.GetBool("Attack"))
        {
            anim.SetBool("Attack", false);
            time = 0;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Sword"))
            anim.SetBool("Sword", false);
        if (Input.GetMouseButtonDown(0))
        {
            if (swordOut)
                anim.SetBool("Attack", true);
            else
            {
                anim.SetBool("Sword", true);
                swordOut = true; 
            }
                
        }
        else if (Input.GetMouseButtonDown(1))
        {
            swordOut = false;
            transform.GetChild(2).gameObject.SetActive(false);
        }

    }
    private void OnTriggerStay(Collider trigger)
    {
        if (trigger.gameObject.tag == "Chicken" && Input.GetMouseButtonDown(0) && swordOut)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
            GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().desactiveTache(3);
            GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().activeTache(8); //active la tache (si pas encore activé)
            MonoBehaviour.Instantiate(chicken, new Vector3(trigger.transform.position.x, trigger.transform.position.y+0.3f, trigger.transform.position.z), trigger.transform.rotation);
            Destroy(trigger.gameObject);            
        }
    }
}
