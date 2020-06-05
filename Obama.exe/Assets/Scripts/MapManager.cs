using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MapManager : NetworkBehaviour
{
    [SerializeField]
    private GameObject[] mapList;
    [SerializeField]
    private GameObject lobbyMap;
    [SerializeField]
    private GameObject overtimeMap;
    [SerializeField]
    private string MAPTAG;
    [SerializeField]
    private string SPAWNPOINTTAG;
    [SerializeField]
    private Transform mapLocation;
    [SerializeField]
    private Transform spawnPoint001;
    [SerializeField]
    private Transform spawnPoint002;



    private GameObject activeMap;
    private void Start()
    {
        GameObject temp = GameObject.FindGameObjectWithTag(MAPTAG);
        activeMap = temp;
    }

    [Command]
    public void CmdChangeMapTo(GameObject _map)
    {
        ClearActiveMap();
        Instantiate<GameObject>(_map);
        activeMap = _map;
        Debug.Log("Map Changed to: " + _map.name);

        SpawnPlayers();
        Debug.Log("Repositioned Players");

        GameManager.StartRound();

    }

    void ClearActiveMap()
    {
        if (activeMap != null)
        {
            Destroy(activeMap);
            Debug.Log("Active Map cleared out!");
        }
    }

    public void GoToOvertime()
    {
        CmdChangeMapTo(overtimeMap);
    }

    public void GoToLobby()
    {
        CmdChangeMapTo(lobbyMap);
    }

    public void GoToRandomMap()
    {

    }

    //[ClientRpc]
    private void SpawnPlayers()
    {
        GameObject[] temp2 = GameObject.FindGameObjectsWithTag(SPAWNPOINTTAG);
        GameObject[] temp3 = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(temp3.Length);
        for (int i = 0; i < temp3.Length; i++)
        {
            //int temp = i + 1;
            //string playerID = "Player " + temp;

            //Debug.Log(playerID);

            //GameManager.getPlayer(playerID).transform.SetPositionAndRotation(temp2[i].transform.position, temp2[i].transform.rotation);

            temp3[i].transform.SetPositionAndRotation(temp2[i].transform.position, temp2[i].transform.rotation);
        }
    }
}