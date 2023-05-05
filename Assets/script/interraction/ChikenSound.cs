using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChikenSound : MonoBehaviour
{
    private float tempsMs;
    private float actu;

    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        tempsMs = this.TireTemps()*(clip.length/2);
        actu = 0;
    }

    // Update is called once per frame
    void Update()
    {
        actu += Time.deltaTime;
        if (actu > tempsMs)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
            tempsMs = this.TireTemps()*clip.length;
            actu = 0;            
        }

    }    

    private float TireTemps()
    {
        return Random.Range(1.0f, 15.0f);
    }

}
