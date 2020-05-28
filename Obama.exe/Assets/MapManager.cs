using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] mapList;
    [SerializeField]
    private Transform lobbyMap;
    [SerializeField]
    private Transform overtimeMap;


    private void Start()
    {
        activeMap = lobbyMap;
    }

    private Transform activeMap;
    void ChangeMapTo(string _mapname)
    {
        clearActiveMap();
        //TODO: Map changing through instanciating and replacing the active Map prefap

        Debug.Log("Map Changed to: ");
    }
    void ChangeMapTo(Transform _map) //just for changing the map via a Transform pointer
    {       
        ChangeMapTo(_map.name);
    }

    void clearActiveMap()
    {
        //TODO: Clearing out the active Map prefab
        Debug.Log("Active Map cleared out!");
    }

    void GoToOvertime()
    {
        ChangeMapTo(overtimeMap);
    }
}
