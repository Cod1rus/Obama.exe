using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private string mainMenuScene;

    public static bool IsOn = false;

    
    private NetworkManager networkManager;
    private GameManager gameManager;


    private void Start()
    {
        networkManager = NetworkManager.singleton;
    }
    public void LeaveRoom()
    {
        MatchInfo matchInfo = networkManager.matchInfo;
        networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, networkManager.OnDropConnection);
        networkManager.OnStopHost();
        gameManager.ChangeSceneTo(mainMenuScene);
    }
}