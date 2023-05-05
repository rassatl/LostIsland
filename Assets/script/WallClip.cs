using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClip : MonoBehaviour
{

    void OnCollisionEnter(Collision collision){
        Debug.Log("collision");
    }

}
