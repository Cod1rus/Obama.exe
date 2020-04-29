using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainmenu;

    public void PlayGame()
    {
        Debug.Log("Starting Game");
        mainmenu.SetActive(false);
    }
}
