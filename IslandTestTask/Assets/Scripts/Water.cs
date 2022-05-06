using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    public SaveLoadManager saveLoadManager;

    private void OnTriggerEnter(Collider other)
    {
        saveLoadManager.OnSave();
        SceneManager.LoadScene(0);
    }  
    
    private void OnTriggerStay(Collider other)
    {
        saveLoadManager.OnSave();
        SceneManager.LoadScene(0);
    }
}
