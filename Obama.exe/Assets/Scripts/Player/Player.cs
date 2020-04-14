using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    [SyncVar]
    private bool _isDead = false;


    public bool isDead
    {
        get { return _isDead; }
        protected set { _isDead = value; }
    }
    [SyncVar]
    private int currentHealth;


    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private Behaviour[] disableOnDeath;

    private bool[] wasEnabled;



    public void Setup()
    {

        //speichert zustand aller Componenten
        wasEnabled = new bool[disableOnDeath.Length];
        for (int i = 0; i < wasEnabled.Length; i++){
            wasEnabled[i] = disableOnDeath[i].enabled;
        }

        SetDefaults();
    }



    [ClientRpc]
    public void RpcTakeDamage(int _amount)
    {
        if (isDead){
            return;
        }

        currentHealth -= _amount;
        Debug.Log(transform.name + " now has " + currentHealth + " health!");

        if (currentHealth <= 0){
            Die();
        }
    }


    private void Die()
    {
        isDead = true;

        for (int i = 0; i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = false;
        }
        Collider _col = GetComponent<Collider>();//sollten wir mehr Collider brauchen MUSS das umgeschrieben werden!!!!!!! (bitte melden falls der Fall)
        if (_col != null)
        {
            _col.enabled = false;
        }

        Debug.Log(transform.name + " is DEAD");

        // Call Respawn (w round logic)
    }


    public void SetDefaults()
    {
        isDead = false;

        currentHealth = maxHealth;

        //setzt alle Componenten in den Normalen zustand zurück
        for (int i = 0; i< disableOnDeath.Length; i++){
            disableOnDeath[i].enabled = wasEnabled[i];
        }

        // der Collider muss seperat gehandled werden da Collider nicht von Behaviour erbt!!!
        Collider _col = GetComponent<Collider>();//sollten wir mehr Collider brauchen MUSS das umgeschrieben werden!!!!!!! (bitte melden falls der Fall)
        if (_col != null)
        {
            _col.enabled = true;
        }
    }
}