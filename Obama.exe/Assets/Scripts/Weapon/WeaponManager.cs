using UnityEngine.Networking;
using UnityEngine;

public class WeaponManager : NetworkBehaviour{

    [SerializeField]
    private string weaponLayerName = "Weapon";
    //[SerializeField]
    //private Transform weaponHolder;
    //[SerializeField]
    //private PlayerWeapon primaryWeapon;
    //[SerializeField]
    //private PlayerWeapon wirstBreaker;
    //[SerializeField]
    //private PlayerWeapon rpg;
    //[SerializeField]
    //private PlayerWeapon bonkMaster9000;
    //[SerializeField]
    //private PlayerWeapon schwererGustav;
    //[SerializeField]
    //private PlayerWeapon automaticSniperRifle;

    [SerializeField]
    private  PlayerWeapon[] playerWeapon;


    private PlayerWeapon curretWeapon;

    //[SyncVar]
    private int currentWeaponID;

    [SerializeField]
    private int startWeaponID = 1;


    private void Start()
    {
        EquipWeapon(startWeaponID);
    }



    void EquipWeapon(PlayerWeapon _weapon)
    {
        Debug.Log("Equipping Weapon: " + _weapon.name);

        //curretWeapon = _weapon;

       // _weapon.weaponGFX.SetActive(!_weapon.weaponGFX.activeSelf);


        //GameObject _weapinIns = Instantiate(_weapon.weaponGFX, weaponHolder.position, weaponHolder.rotation);
        //_weapinIns.transform.SetParent(weaponHolder);

        //if (isLocalPlayer)
        //{
        //    _weapinIns.layer = LayerMask.NameToLayer(weaponLayerName);
        //}


    }
    void EquipWeapon(int _weaponID)
    {
        currentWeaponID = _weaponID;
        playerWeapon[_weaponID].weaponGFX.SetActive(!playerWeapon[_weaponID].weaponGFX.activeSelf);
        curretWeapon = playerWeapon[_weaponID];
    }

    private void UnequipCurrentWeapon()
    {
        //PlayerWeapon temp = curretWeapon;
        //curretWeapon = null;
        //Destroy(temp.weaponGFX);
        curretWeapon.weaponGFX.SetActive(!curretWeapon.weaponGFX.activeSelf);


    }

    public PlayerWeapon GetCurrentWeapon()
    {
        return curretWeapon;
    }

    //public void ChangeWeaponTo(string _weapon) //I know SWT1 prof would kill me xD
    //{
    //    UnequipCurrentWeapon();
    //    if (_weapon == primaryWeapon.name)
    //    {
    //        EquipWeapon(primaryWeapon);
    //    }
    //    else if (_weapon == wirstBreaker.name)
    //    {
    //        EquipWeapon(wirstBreaker);
    //    }
    //    else if (_weapon == rpg.name)
    //    {
    //        EquipWeapon(rpg);
    //    }
    //    else if (_weapon == bonkMaster9000.name)
    //    {
    //        EquipWeapon(bonkMaster9000);
    //    }
    //    else if (_weapon == schwererGustav.name)
    //    {
    //        EquipWeapon(schwererGustav);
    //    }
    //    else if (_weapon == automaticSniperRifle.name)
    //    {
    //        EquipWeapon(automaticSniperRifle);
    //    }
    //}
    

    public void ChangeToRandomWeapon()
    {
        UnequipCurrentWeapon();
        
        EquipWeapon(Random.Range(0, playerWeapon.Length));
    }
}
