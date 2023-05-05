using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScene3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Player").GetComponent<persistenceScene>().rocherScene3)
        {
            print("grotte libre");
            GameObject.Find("RocherGrotte").GetComponent<Animator>().enabled = false;
            GameObject.Find("RocherGrotte").gameObject.transform.position = new Vector3(2f, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
