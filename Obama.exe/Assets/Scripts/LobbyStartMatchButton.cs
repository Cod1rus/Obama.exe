using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyStartMatchButton : MonoBehaviour
{
    [SerializeField]
    private GameObject nextMap;
    [SerializeField]
    private MapManager mapManager;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("TEST");
        mapManager.ChangeMapTo(nextMap);
    }
}