using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    [SyncVar]
    private int currentHealth;

    private void Awake()
    {
        SetDefaults();
    }

    public void SetDefaults()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int _amount)
    {
        currentHealth -= _amount;
        Debug.Log(transform.name + "now has " + currentHealth + " health!");
    }

}
