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
        //TODO: Set active Map to Preplaced Lobby Prefab
        GameObject temp = GameObject.FindGameObjectWithTag(MAPTAG);
        activeMap = temp;
    }

    public void ChangeMapTo(GameObject _map)
    {
        ClearActiveMap();
        Instantiate<GameObject>(_map);
        activeMap = _map;
        Debug.Log("Map Changed to: " + _map.name);

        SpawnPlayers();
        Debug.Log("Repositioned Players");

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
        ChangeMapTo(overtimeMap);
    }

    public void GoToLobby()
    {
        ChangeMapTo(lobbyMap);
    }

    public void GoToRandomMap()
    {

    }

    private void SpawnPlayers()
    {
        //TODO: Teleport Player to Spawnpoints

        bool switcherino = true;
        GameObject[] temp2 = GameObject.FindGameObjectsWithTag(SPAWNPOINTTAG);
        for (int i = 0; i < GameManager.GetPlayerRegisterSize(); i++)
        {
            int temp = i + 1;
            string playerID = "Player " + temp;

            //Debug.Log(playerID);

            GameManager.getPlayer(playerID).transform.SetPositionAndRotation(temp2[i].transform.position, temp2[i].transform.rotation);
  
        }
    }
}