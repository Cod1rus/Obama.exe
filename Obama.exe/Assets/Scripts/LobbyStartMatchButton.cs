using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyStartMatchButton : MonoBehaviour
{
    [SerializeField]
    private string nextmap;

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.ChangeSceneTo(nextmap);
    }
}