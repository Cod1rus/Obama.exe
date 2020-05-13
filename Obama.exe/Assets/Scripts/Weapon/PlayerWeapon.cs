
using UnityEngine;

[System.Serializable]
public class PlayerWeapon
{
    public string name = "Default";

    public int damage = 10;

    public float range = 100f;
    public float recoil = 0f; 
    public float fireRate = 0f; //if 0 = non automatic

    public GameObject weaponGFX;

}
