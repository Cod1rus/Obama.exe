using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jumppad : MonoBehaviour
{
    
    [SerializeField]
    private float JumpForce = 10;
    [SerializeField]
    private Transform [] jumpPoints;

    private void OnCollisionEnter(Collision collision)
    {
        //Vector3 newvelocity = -collision.contacts[0].normal.normalized * JumpForce;
        //newvelocity.x = 0f;
        //newvelocity.z = 0f;
        //collision.gameObject.GetComponent<Rigidbody>().AddForce(newvelocity, ForceMode.Impulse);
        int temp = Random.Range(0, jumpPoints.Length -1);
        collision.gameObject.transform.SetPositionAndRotation(jumpPoints[temp].position, jumpPoints[temp].rotation);

    }
}
