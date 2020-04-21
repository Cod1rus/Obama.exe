using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class JoinGame : MonoBehaviour
{
    private NetworkManager networkManager;
    List<GameObject> roomList = new List<GameObject>();

    [SerializeField]
    private Text status;


    private void Start()
    {
        networkManager = NetworkLobbyManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
        RefreshRoomlList();
    }

    public void RefreshRoomlList()
    {
        networkManager.matchMaker.ListMatches(0, 20, "", false, 0, 0, OnMatchList);
        status.text = "Loading...";
    }

    public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
        status.text = "";
        if (matches == null)
        {
            status.text = "Couldn't get room list";
            return;
        }

        //foreach (MatchInfoSnapshot match in matches)
        //{
        //}
    }

    void ClearRoomList()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
        }
    }
}
