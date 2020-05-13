using UnityEngine.Networking;
using UnityEngine;

public class WeaponManager : NetworkBehaviour{

    [SerializeField]
    private string weaponLayerName = "Weapon";
    [SerializeField]
    private Transform weaponHolder;
    [SerializeField]
    private PlayerWeapon primaryWeapon;

    private PlayerWeapon curretWeapon;

    private void Start()
    {
        EquipWeapon(primaryWeapon);
    }

    void EquipWeapon(PlayerWeapon _weapon)
    {
        curretWeapon = _weapon;
        GameObject _weapinIns = (GameObject)Instantiate(_weapon.weaponGFX, weaponHolder.position, weaponHolder.rotation);
        _weapinIns.transform.SetParent(weaponHolder);

        if (isLocalPlayer)
        {
            _weapinIns.layer = LayerMask.NameToLayer(weaponLayerName);
        }
    }

    public PlayerWeapon GetCurrentWeapon()
    {
        return curretWeapon;
    }
}
