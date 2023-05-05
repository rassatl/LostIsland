using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonPilote : MonoBehaviour
{
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(clip1);
        StartCoroutine(playSound2());
    }

    IEnumerator playSound2()
    {
        yield return new WaitForSeconds(clip1.length + 0.1f);
        gameObject.GetComponent<AudioSource>().PlayOneShot(clip2);
        StartCoroutine(playSound3());
    }

    IEnumerator playSound3()
    {
        yield return new WaitForSeconds(clip2.length + 0.1f);
        gameObject.GetComponent<AudioSource>().PlayOneShot(clip3);
        StartCoroutine(playSound4());
    }
    IEnumerator playSound4()
    {
        yield return new WaitForSeconds(clip3.length + 0.1f);
        gameObject.GetComponent<AudioSource>().PlayOneShot(clip4);
    }


}
