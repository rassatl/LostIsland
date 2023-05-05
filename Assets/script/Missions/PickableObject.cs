using System.Collections;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float forceLancer;
    private const float DISTANCE_ATTRAPE = 1.9f;

    private bool hasPlayer = false;
    private bool beingCarried = false;
    private bool touched = false;

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        if (dist <= DISTANCE_ATTRAPE)
            hasPlayer = true;
        else
            hasPlayer = false;

        if (hasPlayer && Input.GetKey(KeyCode.E))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = player;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            beingCarried = true;
        }

        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * forceLancer);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
    }

    void OnTriggerEnter()
    {
        if (beingCarried)
            touched = true;
    }
}
