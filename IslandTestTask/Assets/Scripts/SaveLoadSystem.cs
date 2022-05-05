using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    public void Save(List<Resource> resources, List<BuildPoint> buildPoints)
    {
        for (int i = 0; i < resources.Count; i++)
        {
            PlayerPrefs.SetInt(resources[i].name, resources[i].count);
        }

        for (int i = 0; i < buildPoints.Count; i++)
        {
            PlayerPrefs.SetString(i.ToString(), buildPoints[i].isBuild.ToString());
        }

    }
}
