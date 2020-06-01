using UnityEngine;

public class PlayerUI : MonoBehaviour
{

    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    GameObject crosshair;

    [SerializeField]
    GameObject ammocount;

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
            Toggleammocount();

        }
    }
    void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        PauseMenu.IsOn = pauseMenu.activeSelf;
        if (pauseMenu.active == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (pauseMenu.active == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void ToggleCrosshair()
    {
        crosshair.SetActive(!crosshair.activeSelf);       
    }

    void Toggleammocount()
    {
        ammocount.SetActive(!ammocount.activeSelf);
    }
}
