
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void BtnOpenLevel(int levelIndex)
    {
        SceneManager.LoadScene("Game" + levelIndex);
    }
}
