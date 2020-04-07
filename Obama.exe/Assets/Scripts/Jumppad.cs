using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jumppad : MonoBehaviour
{
    GameObject[] Player;
    private float JumpForce = 10;


    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player"); 
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        Vector3 newvelocity = -collision.contacts[0].normal.normalized * JumpForce;
        newvelocity.x = 0f;
        newvelocity.z = 0f;
        collision.gameObject.GetComponent<Rigidbody>().AddForce(newvelocity, ForceMode.Impulse);
    }
}
