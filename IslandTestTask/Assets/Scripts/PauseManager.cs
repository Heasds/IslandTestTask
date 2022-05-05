using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public SaveLoadManager saveLoadManager;

    public void PauseButton()
    {
        Time.timeScale = 0;
    }
    public void ContinueButton()
    {
        Time.timeScale = 1;
    } 

    public void ResetProgress()
    {
        Time.timeScale = 1;
        saveLoadManager.ResetSave();
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        saveLoadManager.OnSave();
        Application.Quit();
    }
}
