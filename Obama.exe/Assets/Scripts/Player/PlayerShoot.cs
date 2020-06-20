using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(WeaponManager))]
public class PlayerShoot : NetworkBehaviour
{
    
    [SerializeField]
    private const string PLAYER_TAG = "Player";

    [SerializeField]
    private Camera PlayerCamera;
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private Player player;

    private WeaponManager weaponManager;
    private PlayerWeapon currentWeapon;

    private void Start()
    {
        if (PlayerCamera == null)
        {
            Debug.LogError("Player Shoot: No Camera referenced");
            this.enabled = false;
        }
        weaponManager = GetComponent<WeaponManager>();
    }

    private void Update()
    {
        if (PauseMenu.IsOn)
        {
            return;
        }

        currentWeapon = weaponManager.GetCurrentWeapon();

        if (currentWeapon.fireRate <= 0){
            if (Input.GetButtonDown("Fire1")){
                Shoot();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                InvokeRepeating("Shoot", 0f, 1f / currentWeapon.fireRate);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                CancelInvoke("Shoot");
            }
                
        }

    }

    [Client]
    void Shoot()
    {
        RaycastHit _hit;
        Debug.Log("We shot! (on client)");
        
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out _hit, currentWeapon.range, mask))
        {            
            Debug.Log("We did a Raycast! (on client) we hit: " + _hit.collider.name);
            if (_hit.collider.tag == PLAYER_TAG)
            {
                Debug.Log("We hit a Player (on client)");
                CmdPlayerShot(_hit.collider.name, currentWeapon.damage);
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
