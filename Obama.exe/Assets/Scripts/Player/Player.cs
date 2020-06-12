using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Player : NetworkBehaviour
{


    public float damageDealt = 0;
    private float damageTaken = 0;
    private float hpRecoverd = 0;
    private int points = 0;


    [SyncVar]
    public bool _isDead = false;


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

    //private void Update()
    //{
    //    if (!isLocalPlayer)
    //    {
    //        return;
    //    }
    //    if (Input.GetKeyDown(KeyCode.K))
    //    {
    //        RpcTakeDamage(999999);
    //    }

    //}



    [ClientRpc]
    public void RpcTakeDamage(int _amount)
    {
        if (isDead){
            return;
        }

        currentHealth -= _amount;
        Debug.Log(transform.name + " now has " + currentHealth + " health!");
        damageTaken += _amount;

        if (currentHealth <= 0){
            Debug.Log(transform.name + " has Died!!");
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
        StartCoroutine(Respawn());
    }


    public IEnumerator Respawn ()
    {
        yield return new WaitForSeconds(GameManager.instance.matchSettings.respawnTime);
        SetDefaults();
        Transform _spawnPoint = NetworkManager.singleton.GetStartPosition();
        transform.position = _spawnPoint.position;
        transform.rotation = _spawnPoint.rotation;
        Debug.Log("Respawned: " + transform.name);
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