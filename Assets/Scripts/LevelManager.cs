
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    void Awake()
    {
        instance = this;
    }

    public void FailLevel()
    {
        UIManager.instance.OpenFailPanel();
    }

    public void WinLevel()
    {
        UIManager.instance.OpenWinPanel();
    }
}
