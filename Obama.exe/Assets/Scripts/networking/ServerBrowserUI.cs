using UnityEngine;

public class ServerBrowserUI : MonoBehaviour
{
    [SerializeField]
    private GameObject serverBrowserUI;
    
    public void ToggleServerBrowserUI(bool temp)
    {
        serverBrowserUI.SetActive(temp);
    }
}
