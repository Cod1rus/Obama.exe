using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    GameObject crosshair;

    [SerializeField]
    GameObject ammocount;

    [SerializeField]
    GameObject score;

    [SerializeField]
    GameObject[] deathScreen;

    GameObject activeDeathScreen;



    private int deathScreenIndex = 0;

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
            ToggleAmmocount();

        }
        UpdateScore();
        //UpdateAmmocount();
    }
    public void UpdateScore()
    {
        score.GetComponent<Text>().text = "Score: " + GameManager.getScorePlayerOne() + " : " + GameManager.getScorePlayerTwo();
    }

    void UpdateAmmocount(){
        ammocount.GetComponent<Text>().text = "Ammunition: ";
    }
    #region TOGGEL UI
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

    void ToggleAmmocount()
    {
        ammocount.SetActive(!ammocount.activeSelf);
    }

    #region Toggle DeathScreen
    public void ToggleDeathScreenOn()
    {
        int temp = Random.Range(0, deathScreen.Length);

        deathScreen[temp].SetActive(!deathScreen[temp].activeSelf);
        deathScreenIndex = temp;      
    }

    public void ToggleDeathScreenOff()
    {
        deathScreen[deathScreenIndex].SetActive(!deathScreen[deathScreenIndex].activeSelf);
    }
    #endregion

    #endregion
}