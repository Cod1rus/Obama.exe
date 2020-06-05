using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Networking;

public class HostGame : MonoBehaviour
{
    [SerializeField]
    private uint roomsize = 2;
    [SerializeField]
    ServerBrowserUI serverBrowserUI;
    [SerializeField]
    private string lobbyScene;
    [SerializeField]
    private GameObject lobbyMap;

    private string  roomName;

    private NetworkManager networkManager;

    private GameManager gameManager;
    private MapManager mapManager;


    private void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
    }


    public void SetRoomName(string _name)
    {
        roomName = _name;
    }

    public void CreateRoom()
    {
        if (roomName != "" && roomName != null)
        {
            Debug.Log("Creating Room: " + roomName +" with Room for: " + roomsize + " Dudes!");

            //create Room
            networkManager.matchMaker.CreateMatch(roomName, roomsize, true, "" /*passwort*/ , ""/*publicClientAddress*/, ""/*privateClientAddress*/, 0/*eloScoreForMatch*/, 0/*requestDomain*/, networkManager.OnMatchCreate /*callback*/);

            if (serverBrowserUI != null)
            {
                serverBrowserUI.ToggleServerBrowserUI(false);
            }

            //SceneManager.CreateScene(lobbyScene);
            GameManager.ChangeSceneTo(lobbyScene);
            //Instantiate<GameObject>(lobbyMap);
        }
    }
}
