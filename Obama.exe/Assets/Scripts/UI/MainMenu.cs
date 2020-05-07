using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainmenu;
    [SerializeField]
    private GameObject serverBrowser;

    public void PlayGame()
    {
        Debug.Log("Starting Game");
        mainmenu.SetActive(!mainmenu.activeSelf);
        serverBrowser.SetActive(!serverBrowser.activeSelf);
    }

    public void ExitGame(){
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void CallOptionsMenu()
    {
        Debug.Log("Options Menu Called");
    }
}
