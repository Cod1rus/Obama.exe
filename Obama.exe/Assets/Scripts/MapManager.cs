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

    private GameObject activeMap;
    private void Start()
    {
        //TODO: Set active Map to Preplaced Lobby Prefab
        GameObject temp = GameObject.FindGameObjectWithTag(MAPTAG);
        activeMap = temp;
    }

    public void ChangeMapTo(GameObject _map) 
    {
        Debug.Log("TEST2");
        ClearActiveMap();
        Instantiate<GameObject>(_map);
        activeMap = _map;

        Debug.Log("Map Changed to: " + _map.name);
    }

    void ClearActiveMap()
    {
        if (activeMap != null)
        {
            Debug.Log("TEST3");
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
}
