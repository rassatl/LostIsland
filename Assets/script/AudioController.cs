using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip sound; //le son qui sera joué

   //cela permet de spécifier que dans l’Inspector de la scène, on pourra modifier les valeurs correspondantes (celles des variables “volume” et “pitch” grâce à un curseur à régler selon nos préférences.
    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 2.5f)]
    public float pitch;

    private AudioSource source; //gestion du son
    
    void Awake()
    {
        gameObject.AddComponent<AudioSource>(); //on ajoute au cube le conponent Audio Source
        source = GetComponent<AudioSource>(); //on affecte à "source" ledit component

        volume = 0.5f;
        pitch = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        source.clip = sound;
        source.volume = volume;
        source.pitch = pitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
            source.Play();

        source.volume = volume;
        source.pitch = pitch;
    }
}
