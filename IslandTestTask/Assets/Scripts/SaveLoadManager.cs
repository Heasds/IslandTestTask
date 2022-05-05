using UnityEngine;
using System.Collections.Generic;

public class SaveLoadManager : MonoBehaviour
{
    public SaveLoadSystem saveLoadSystem;
    public List<Resource> resources;
    public List<BuildPoint> buildPoints;

    private void Awake()
    {
        OnLoad();
    }
    private void OnApplicationQuit()
    {
        OnSave();
    }

    public void OnSave()
    {
        saveLoadSystem.Save(resources, buildPoints);
    }

    public void OnLoad()
    {
        for (int i = 0; i < resources.Count; i++)
        {
            resources[i].count = PlayerPrefs.GetInt(resources[i].name);
        }

        for (int i = 0; i < buildPoints.Count; i++)
        {
            if (PlayerPrefs.GetString(i.ToString()) == "True") buildPoints[i].isBuild = true;
            else buildPoints[i].isBuild = false;
        }

    }

    public void ResetSave()
    {
        for (int i = 0; i < resources.Count; i++)
        {
            PlayerPrefs.SetInt(resources[i].name, 0);
        }

        for (int i = 0; i < buildPoints.Count; i++)
        {
            PlayerPrefs.SetString(i.ToString(), "False");
        }
    }
}

