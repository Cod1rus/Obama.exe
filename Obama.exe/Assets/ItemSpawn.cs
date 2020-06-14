using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField]
    private string[] weapons; //need to be the exact weapon names!!!!


    private void OnCollisionEnter(Collision collision)
    {
        float temp = Random.Range(0,1);
        if (temp <= 0.8f)
        {
            int temp1 = Random.Range(0, weapons.Length);
            if (collision.transform.tag == "Player")
            {
                collision.transform.GetComponent<WeaponManager>().ChangeWeaponTo(weapons[temp1]);
            }
        }
        else if(temp > 0.8f){
            //TODO: Give Player Powerup
            Debug.Log("Player get Power Up");
        }
    }
}