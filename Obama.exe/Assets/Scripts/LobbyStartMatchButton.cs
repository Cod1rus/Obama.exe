using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LobbyStartMatchButton : MonoBehaviour
{
    [SerializeField]
    private string nextMap;
    [SerializeField]
    private MapManager mapManager;


    private void OnCollisionEnter(Collision collision)
    {
        mapManager.RpcChangeMapTo(nextMap);
        //CmdChangeMap();
        GameManager.StartMatch();
    }
    //[Command]
    //private void CmdChangeMap()
    //{
    //    mapManager.RpcChangeMapTo(nextMap);
    //}
}