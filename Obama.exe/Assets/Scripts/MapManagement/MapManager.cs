using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class MapManager : NetworkBehaviour
{
    [SerializeField]
    private Maps lobbyMap;
    [SerializeField]
    private Maps map001;
    [SerializeField]
    private Maps overtimeMap;
    [SerializeField]
    private string PLAYER;


    private Maps activeMap;

    private void Awake()
    {
        activeMap = lobbyMap;
    }

    [ClientRpc] //ClientRpc wird vom server objekt auf client ausgeführt
    public void RpcChangeMapTo(Maps _map)
    {
        //TOTO: Fix Issue: that Client doesnt get the new map (wont change on Client)
        Debug.Log("Changing Map to: " + _map.name);

        activeMap.map.SetActive(false);
        activeMap = _map;
        _map.map.SetActive(true); //nullreferenceExeption???!!!
        RpcSpawnPlayer(_map);

        Debug.Log("Changed Map to: " + _map.name);
    }

    public void RpcChangeMapTo(string _map)
    {
        if (lobbyMap.name == _map)
        {
            RpcChangeMapTo(lobbyMap);
        }
        else if (overtimeMap.name == _map)
        {
            RpcChangeMapTo(overtimeMap);
        }
        else if (map001.name == _map)
        {
            //Debug.Log("HELLO");
            RpcChangeMapTo(map001);
        }
    }

    [ClientRpc]
    private void RpcSpawnPlayer(Maps _map)
    {
        //TOTO: Fix Issue: that client isnt relocated
        GameObject[] temp = GameObject.FindGameObjectsWithTag(PLAYER);
        
        Transform _point1 = _map.spawnPoint1;
        Transform _point2 = _map.spawnPoint2;

        Debug.Log("RECLOCATING: Player 1");
        temp[0].transform.SetPositionAndRotation(_point1.position, _point1.rotation);
        Debug.Log("RECLOCATED: Player 1");

        if (GameManager.GetPlayerRegisterSize() == 2)
        {
            Debug.Log("RECLOCATING: Player 2");
            Debug.Log(temp[1].name);
            temp[1].transform.SetPositionAndRotation(_point2.position, _point2.rotation);
            Debug.Log("RECLOCATED: Player 2");
        }
    }

    public void ResetMapDefaults()
    {
        //TODO: set players to spawnpoints, reset spawntimers and spawns for items (reset the active Map for a new round)
        Debug.Log("Resetting active Map to Defaults");
        RpcSpawnPlayer(activeMap);
    }

    public void GoToRandomMap()
    {

    }
    public void GoToOvertime()
    {
        RpcChangeMapTo(overtimeMap);
    }

    public void GoToLobby()
    {
        RpcChangeMapTo(lobbyMap);
    }

    public Maps GetActiveMap()
    {
        return activeMap;
    }
}