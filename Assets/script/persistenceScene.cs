using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistenceScene : MonoBehaviour
{
    public List<bool> listArbreScene1;
    public bool rocherScene3;

    // Start is called before the first frame update
    void Start()
    {
        listArbreScene1 = new List<bool>() { false, false, false, false, false, false, false, false, false, false };
        rocherScene3 = false;        
    }

}
