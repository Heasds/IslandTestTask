using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResorcesController : MonoBehaviour
{
    public int buildingsCount;
    public TextMeshProUGUI buildingsCountText;

    public List<ResourcePharameters> resourcePharameters;

    private void Start()
    {
        UpdateText();
    }

    public void ChangeResourceValue(Resource resource, int value)
    {
        for (int i = 0; i < resourcePharameters.Count; i++)
        {
            if (resourcePharameters[i].resource == resource)
            {
                ResourcePharameters resPh = resourcePharameters[i];
                resPh.resource.count += value;
                UpdateText();
            }
        }
    }

    public void UpdateText()
    {
        for (int i = 0; i < resourcePharameters.Count; i++)
        {
            resourcePharameters[i].resourceCountText.text = resourcePharameters[i].resource.count.ToString();
        }

        buildingsCountText.text = buildingsCount.ToString();
    }
}
[System.Serializable]
public class ResourcePharameters
{
    public Resource resource;
    public TextMeshProUGUI resourceCountText;
}
