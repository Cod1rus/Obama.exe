using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public MatchSettings matchSettings;
    [SerializeField]
    public static Timer timer;
    [SerializeField]
    private static MapManager mapManager;
    [SerializeField]
    private string overtimeMap;

    private SceneManager sceneManager;
    private static float roundTime;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one game manager in scene");
            return;
        }
        else
        {
            Debug.Log("Gamemanager Initalisiert!");
            instance = this;
        }
        timer = this.GetComponent<Timer>();
        roundTime = matchSettings.roundTime;
    }


    #region Match Management

    private static int numberOfRounds = 0;
    public static void StartMatch()
    {
        StartRound();
        Debug.Log("Startet round: " + numberOfRounds);
    }

    public static void StartRound()
    {
        numberOfRounds++;
        timer.StartTimer(roundTime);
    }

    public static void StartOvertime()
    {
        Debug.Log("Starting Overtime");
        mapManager.RpcChangeMapTo("Overtime");
    }   

    public static void NextRound()
    {
        if (numberOfRounds >= 3)
        {
            //TODO: Ending Match
            Debug.Log("Ending Match because of reached roundlimit");
        }
        mapManager.ResetMapDefaults();
        StartRound();
        Debug.Log("Starting Round: " + numberOfRounds);
    }

    #endregion

    #region LoadScenes

    public static void ChangeSceneTo(string _scene)
    {

        SceneManager.CreateScene(_scene);
        Debug.Log("created scene: " + _scene);
        SceneManager.LoadScene(_scene);
        Debug.Log("Changed Scene to " + _scene);      
    }

    #endregion
    
    #region Player tracking

    private const string PLAYER_ID_PREFIX = "Player ";

    public static Dictionary<string, Player> players = new Dictionary<string, Player>();



    public static void RegisterPlayer(string _netID, Player _player)
    {
        
        string _playerID = PLAYER_ID_PREFIX + _netID;
        players.Add(_playerID, _player);
        _player.transform.name = _playerID;
       
    }

    public static void DeRegisterPlayer(string _PlayerID)
    {
        players.Remove(_PlayerID);
    }

    public static Player getPlayer(string _playerID)
    {
        return players[_playerID];
    }

    public static int GetPlayerRegisterSize()
    {
        return players.Count;
    }





    // Visualize the Player Dicionary
    //private void OnGUI()
    //{
    //    GUILayout.BeginArea(new Rect(200, 200, 200, 500));
    //    GUILayout.BeginVertical();

    //    foreach (string _playerID in players.Keys)
    //    {
    //        GUILayout.Label(_playerID + " - " + players[_playerID].transform.name);
    //    }

    //    GUILayout.EndVertical();
    //    GUILayout.EndArea();
    //}
    #endregion

}
