using UnityEngine;

public class PlayerUI : MonoBehaviour
{

    [SerializeField]
    GameObject pauseMenu;


    private void Start()
    {
        PauseMenu.IsOn = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }
    void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        PauseMenu.IsOn = pauseMenu.activeSelf;
    }
}
