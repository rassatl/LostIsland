using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScene1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            
            if(GameObject.Find("Player").GetComponent<persistenceScene>().listArbreScene1[i])
            {
                GameObject.Find("arbre" + i).GetComponent<Animator>().enabled = false;
                GameObject.Find("arbre" + i).transform.rotation = new Quaternion(-180, 0, 0,0);
            }
        }
        
    }

}
