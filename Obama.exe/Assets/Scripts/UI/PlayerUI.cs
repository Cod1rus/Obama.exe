using UnityEngine;

public class PlayerUI : MonoBehaviour
{

    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    GameObject crosshair;

    private void Start()
    {
        PauseMenu.IsOn = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
            ToggleCrosshair();
        }
    }
    void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        PauseMenu.IsOn = pauseMenu.activeSelf;
    }

    void ToggleCrosshair()
    {
        crosshair.SetActive(!crosshair.activeSelf);       
    }
}
