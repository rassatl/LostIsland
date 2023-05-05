using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class Death : MonoBehaviour
{
    public AudioClip clip;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "mort")
        {
            Mort();
        }
        if (collision.gameObject.tag == "Damage")
        {
            Damage(10);
            if (player.pv <= 0)
            {
                Mort();
            }
        }
    }

    public void Update()
    {

    }

    public void Mort()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
        player.pv = player.GetComponent<PlayerH>().viePlayerMax; // met la vie default
        GameObject.Find("Health Bar").GetComponent<HealthBar>().slider.value = player.pv;// met le slider vie default
        transform.position = Player.lastSpawnPos;
        transform.rotation = Player.lastSpawnRot;
    }

    public void Damage(int degat)
    {
        player.GetComponent<PlayerH>().degat(degat);
    }
}
