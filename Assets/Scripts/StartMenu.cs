using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject controlsPanel;
    public GameObject aboutPanel;

    public void OnStartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnControls()
    {
        mainMenuPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void OnAbout()
    {
        mainMenuPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }

    public void OnQuit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    public void OnBack()
    {
        controlsPanel.SetActive(false);
        aboutPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
