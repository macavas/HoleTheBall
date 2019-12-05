
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject failPanel;
    public GameObject winPanel;
    public GameObject pausePanel;
    public GameObject gamePanel;

    public bool isInGameMode;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        failPanel.SetActive(false);
        pausePanel.SetActive(false);
        winPanel.SetActive(false);
        gamePanel.SetActive(true);
        isInGameMode = true;
    }

    
    public void OpenWinPanel()
    {
        winPanel.SetActive(true);
        gamePanel.SetActive(false);
        isInGameMode = false;
    }
    public void OpenFailPanel()
    {
        failPanel.SetActive(true);
        gamePanel.SetActive(false);
        isInGameMode = false;
    }

    public void BtnOpenNextLevel()
    {
        int sceneIndexToOpen = SceneManager.GetActiveScene().buildIndex + 1;
        if(sceneIndexToOpen == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            SceneManager.LoadScene("Game" + sceneIndexToOpen);
        } 
        
    }
    public void BtnOpenPausePanel()
    {
        isInGameMode = false;
        Time.timeScale = 0f;
        gamePanel.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void BtnClosePausePanel()
    {
        Time.timeScale = 1f;
        gamePanel.SetActive(true);
        pausePanel.SetActive(false);
        isInGameMode = true;
    }
    public void BtnRestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BtnOpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
