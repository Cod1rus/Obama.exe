using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Player : NetworkBehaviour
{
    public float damageDealt = 0;
    private float damageTaken = 0;
    private float hpRecoverd = 0;
    private int id = 9000;

    private GameObject ui;

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
    [SerializeField]
    private Collider collider;

    private bool[] wasEnabled;



    public void Setup()
    {

        //speichert zustand aller Componenten
        wasEnabled = new bool[disableOnDeath.Length];
        for (int i = 0; i < wasEnabled.Length; i++){
            wasEnabled[i] = disableOnDeath[i].enabled;
        }
        //ui = GameObject.Find(PLAYERUINAME);
        SetDefaults();

    }

    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            RpcTakeDamage(999999);
        }
    }



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
        //Collider _col = GetComponent<Collider>();//sollten wir mehr Collider brauchen MUSS das umgeschrieben werden!!!!!!! (bitte melden falls der Fall)
        if (collider != null)
        {
            // _col.enabled = false;
            collider.enabled = false;
        }

        Debug.Log(transform.name + " is DEAD");
        GameManager.SetScore(id);

        ui.GetComponent<PlayerUI>().ToggleDeathScreenOn();


        StartCoroutine(Respawn());
    }


    public IEnumerator Respawn ()
    {
        yield return new WaitForSeconds(GameManager.instance.matchSettings.respawnTime);
        SetDefaults();
        Transform _spawnPoint = NetworkManager.singleton.GetStartPosition();
        transform.position = _spawnPoint.position;
        transform.rotation = _spawnPoint.rotation;

        ui.GetComponent<PlayerUI>().ToggleDeathScreenOff();//


        Debug.Log("Respawned: " + transform.name);
    }

    public void SetPlayerUiRefernce(GameObject _ui)
    {
        ui = _ui;
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
        //Collider _col = GetComponent<Collider>();//sollten wir mehr Collider brauchen MUSS das umgeschrieben werden!!!!!!! (bitte melden falls der Fall)
        if (collider != null)
        {
            collider.enabled = true;
        }
    }

    public void SetID(int _id)
    {
        id = _id;
        Debug.Log("ID SET TO: " + id);
    }

    public void PickUpItem()
    {

    }
}