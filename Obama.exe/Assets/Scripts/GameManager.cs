﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public MatchSettings matchSettings;


    private SceneManager sceneManager;
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
        
    }



    #region LoadScenes

    public static void ChangeSceneTo(string _scene)
    {
        Debug.Log("Changed Scene to " + _scene);
        SceneManager.LoadScene(_scene);
    }

    #endregion


    #region Player tracking

    private const string PLAYER_ID_PREFIX = "Player ";

    private static Dictionary<string, Player> players = new Dictionary<string, Player>();

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
