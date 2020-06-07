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

    
    private void Start()
    {
        activeMap = lobbyMap;
        this.gameObject.SetActive(true);
    }

    [Command]
    public void CmdChangeMapTo(Maps _map)
    {
        
        Debug.Log("Changing Map to: " + _map.name);

        activeMap.map.SetActive(false);

        activeMap = _map;
        _map.map.SetActive(true);

        SpawnPlayer(_map.spawnPoint1, _map.spawnPoint2);


        Debug.Log("Changed Map to: " + _map.name);
    }


    public void CmdChangeMapTo(string _map)
    {
        if (lobbyMap.name == _map)
        {
            CmdChangeMapTo(lobbyMap);
        }
        else if (overtimeMap.name == _map)
        {
            CmdChangeMapTo(overtimeMap);
        }
        else if(map001.name == _map)
        {
            CmdChangeMapTo(map001);
        }

    }

    private void SpawnPlayer(Transform _point1, Transform _point2)
    {
        //TOTO: Spawn Players on Right Map Prefab in Scene
        GameObject[] temp = GameObject.FindGameObjectsWithTag(PLAYER);

        Debug.Log("RECLOCATING: Player 1");
        temp[0].transform.SetPositionAndRotation(_point1.position, _point1.rotation);

        if (GameManager.GetPlayerRegisterSize() == 2)
        {
            Debug.Log("RECLOCATING: Player 2");
            temp[1].transform.SetPositionAndRotation(_point2.position, _point2.rotation);
        }


        Debug.Log("Relocated Players");
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

    public Maps GetActiveMap()
    {
        return activeMap;
    }
}