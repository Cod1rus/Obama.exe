﻿using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour
{
    [SerializeField]
    private const string PLAYER_TAG = "Player";
    public PlayerWeapon weapon;

    [SerializeField]
    private Camera PlayerCamera;

    [SerializeField]
    private LayerMask mask;




    private void Start()
    {
        if (PlayerCamera == null)
        {
            Debug.LogError("Player Shoot: No Camera referenced");
            this.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    [Client]
    void Shoot()
    {
        RaycastHit _hit;
        Debug.Log("We shot! (on client)");
        
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out _hit, weapon.range, mask))
        {            
            Debug.Log("We did a Raycast! (on client) we hit: " + _hit.collider.name);
            if (_hit.collider.tag == PLAYER_TAG)
            {
                Debug.Log("We hit a Player (on client)");
                CmdPlayerShot(_hit.collider.name, weapon.damage); 
            } 
        }
    }

    [Command]
    void CmdPlayerShot(string _PlayerID, int _damage)
    {
        Debug.Log(_PlayerID + "Got his face ripped");

        Player _player = GameManager.getPlayer(_PlayerID);
        _player.RpcTakeDamage(_damage);
      
    }
}