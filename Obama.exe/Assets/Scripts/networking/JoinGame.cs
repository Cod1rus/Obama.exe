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
    [SerializeField]
    private GameObject roomListItemPrefab;
    [SerializeField]
    private Transform roomListParent;
    [SerializeField]
    ServerBrowserUI serverBrowserUI;
    [SerializeField]
    private string lobbyScene;

    private GameManager gameManager;

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
        ClearRoomList();
        networkManager.matchMaker.ListMatches(0, 20, "", false, 0, 0, OnMatchList);
        status.text = "Loading...";
    }

    public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
        status.text = "";
        if (!success || matches == null)
        {
            status.text = "Couldn't get room list";
            return;
        }

        foreach (MatchInfoSnapshot match in matches)
        {
            GameObject _roomListItemGO = Instantiate(roomListItemPrefab);
            _roomListItemGO.transform.SetParent(roomListParent);

            RoomListItem _rooListItem = _roomListItemGO.GetComponent<RoomListItem>();
            if (_rooListItem != null)
            {
                _rooListItem.Setup(match, JoinRoom);
            }

            roomList.Add(_roomListItemGO);
        }

        if (roomList.Count == 0)
        {
            status.text = "No one wants to play!"; //keine Räume im moment vorhanden
        }
    }

    void ClearRoomList()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
        }

        roomList.Clear();
    }

    public void JoinRoom(MatchInfoSnapshot _match)
    {
        Debug.Log("Joining " + _match.name);
        networkManager.matchMaker.JoinMatch(_match.networkId, "", "", "", 0, 0, networkManager.OnMatchJoined);
        ClearRoomList();
        status.text = "Joining...";


        //serverBrowserUI.ToggleServerBrowserUI(false);

        GameManager.ChangeSceneTo(lobbyScene);
    }


}
