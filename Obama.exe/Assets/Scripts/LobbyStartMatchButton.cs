using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyStartMatchButton : MonoBehaviour
{
    [SerializeField]
    private string nextMap;
    [SerializeField]
    private MapManager mapManager;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("TEST");
        mapManager.CmdChangeMapTo(nextMap);
    }
}