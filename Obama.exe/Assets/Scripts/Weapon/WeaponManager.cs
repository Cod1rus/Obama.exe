using UnityEngine.Networking;
using UnityEngine;

public class WeaponManager : NetworkBehaviour{

    [SerializeField]
    private string weaponLayerName = "Weapon";
    [SerializeField]
    private Transform weaponHolder;
    [SerializeField]
    private PlayerWeapon primaryWeapon;
    [SerializeField]
    private PlayerWeapon wirstBreaker;
    [SerializeField]
    private PlayerWeapon rpg;
    [SerializeField]
    private PlayerWeapon bonkMaster9000;
    [SerializeField]
    private PlayerWeapon schwererGustav;
    [SerializeField]
    private PlayerWeapon automaticSniperRifle;

    private PlayerWeapon curretWeapon;

    private void Start()
    {
        EquipWeapon(primaryWeapon);
    }

    void EquipWeapon(PlayerWeapon _weapon)
    {
        Debug.Log("Equipping Weapon: " + _weapon.name);

        curretWeapon = _weapon;

        _weapon.weaponGFX.SetActive(!_weapon.weaponGFX.activeSelf);
        //GameObject _weapinIns = Instantiate(_weapon.weaponGFX, weaponHolder.position, weaponHolder.rotation);
        //_weapinIns.transform.SetParent(weaponHolder);

        //if (isLocalPlayer)
        //{
        //    _weapinIns.layer = LayerMask.NameToLayer(weaponLayerName);
        //}


    }

    private void UnequipCurrentWeapon()
    {
        //PlayerWeapon temp = curretWeapon;
        //curretWeapon = null;
        ////TODO: Clean up old weapon to change to an new one
        //Destroy(temp.weaponGFX);
        curretWeapon.weaponGFX.SetActive(!curretWeapon.weaponGFX.activeSelf);

    }

    public PlayerWeapon GetCurrentWeapon()
    {
        return curretWeapon;
    }

    public void ChangeWeaponTo(string _weapon) //I know SWT1 prof would kill me xD
    {
        UnequipCurrentWeapon();
        if (_weapon == primaryWeapon.name)
        {
            EquipWeapon(primaryWeapon);
        }
        else if (_weapon == wirstBreaker.name)
        {
            EquipWeapon(wirstBreaker);
        }
        else if (_weapon == rpg.name)
        {
            EquipWeapon(rpg);
        }
        else if (_weapon == bonkMaster9000.name)
        {
            EquipWeapon(bonkMaster9000);
        }
        else if (_weapon == schwererGustav.name)
        {
            EquipWeapon(schwererGustav);
        }
        else if (_weapon == automaticSniperRifle.name)
        {
            EquipWeapon(automaticSniperRifle);
        }
    }
    private PlayerWeapon ChangeToRandomWeapon()
    {
        int temp = Random.Range(0,5);
        if (temp == 0)
        {
            return primaryWeapon;
        }
        else if (temp == 1)
        {
            return wirstBreaker;
        }
        else if (temp == 2)
        {
            return rpg;
        }
        else if (temp == 3)
        {
            return bonkMaster9000;
        }
        else if (temp == 4)
        {
            return schwererGustav;
        }
        else if (temp == 5)
        {
            return automaticSniperRifle;
        }
        return primaryWeapon;
    }
}
