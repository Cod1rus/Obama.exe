using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Maps lobbyMap;
    [SerializeField]
    private Maps map001;
    [SerializeField]
    private Maps overtimeMap;


    private Maps activeMap;

    
    private void Start()
    {
        activeMap = lobbyMap;
        this.gameObject.SetActive(true);
    }


    public void ChangeMapTo(Maps _map)
    {
        
        Debug.Log("Changing Map to: " + _map.name);

        activeMap.map.SetActive(false);

        activeMap = _map;
        _map.map.SetActive(true);

        SpawnPlayer(_map.spawnPoint1, _map.spawnPoint2);





        Debug.Log("Changed Map to: " + _map.name);
    }

    public void ChangeMapTo(string _map)
    {
        if (lobbyMap.name == _map)
        {
            ChangeMapTo(lobbyMap);
        }
        else if (overtimeMap.name == _map)
        {
            ChangeMapTo(overtimeMap);
        }
        else if(map001.name == _map)
        {
            ChangeMapTo(map001);
        }

    }

    private void SpawnPlayer(Transform _point1, Transform _point2)
    {
        //TOTO: Spawn Players on Right Map Prefab in Scene

            Debug.Log("RECLOCATING: Player 1");
            GameManager.getPlayer("Player 1").transform.SetPositionAndRotation(_point1.position, _point1.rotation);

            Debug.Log("RECLOCATING: Player 2");
            GameManager.getPlayer("Player 2").transform.SetPositionAndRotation(_point2.position, _point2.rotation);




        Debug.Log("Relocated Players");
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

    public Maps GetActiveMap()
    {
        return activeMap;
    }
}