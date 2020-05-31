using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
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
        bool switcherino = true;
        //TODO: Teleport Player to Spawnpoints
        for (int i = 0; i < GameManager.GetPlayerRegisterSize();i++)
        {
            int temp = i + 1;
            string playerID = "Player " + temp;
            if (switcherino)
            {
                Debug.Log(playerID);
                GameManager.players[playerID].transform.SetPositionAndRotation(spawnPoint001.position, spawnPoint001.rotation);
                //GameManager.getPlayer(PlayerID).transform.SetPositionAndRotation(spawnPoint001.position, spawnPoint001.rotation);
            }
            else if (!switcherino)
            {
                //GameManager.getPlayer(PlayerID).transform.SetPositionAndRotation(spawnPoint002.position, spawnPoint002.rotation);
                GameManager.players[playerID].transform.SetPositionAndRotation(spawnPoint002.position, spawnPoint002.rotation);
            }


        }
    }
}