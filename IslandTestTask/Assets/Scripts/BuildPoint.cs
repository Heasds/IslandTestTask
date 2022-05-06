using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildPoint : MonoBehaviour
{
    private ResorcesController resorcesController;
    public SaveLoadManager saveLoadManager;

    public List<Price> prices;
    public Image image;

    public GameObject buildingPrefab;
    public GameObject buildingPreview;

    public bool isBuild;
    public float timerMax;
    private float timer;

    private void Start()
    {
        resorcesController = GameObject.FindGameObjectWithTag("ResourcesController").GetComponent<ResorcesController>();

        for (int i = 0; i < prices.Count; i++)
        {
            prices[i].countText.text = prices[i].count.ToString();
        }

        if (isBuild)
        {
            Instantiate(buildingPrefab, buildingPreview.transform.position, buildingPreview.transform.rotation);

            resorcesController.buildingsCount++;
            resorcesController.UpdateText();

            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isBuildAvailable())
        {
            timer++;
            image.fillAmount = timer / timerMax;

            if (timer >= timerMax)
            {
                Build();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        timer = 0;
        image.fillAmount = timer;
    }

    private void Build()
    {
        for (int i = 0; i < prices.Count; i++)
        {
            prices[i].resource.count -= prices[i].count;
        }
        resorcesController.UpdateText();
        Instantiate(buildingPrefab, buildingPreview.transform.position, buildingPreview.transform.rotation);
        isBuild = true;

        resorcesController.buildingsCount++;
        resorcesController.UpdateText();
        saveLoadManager.OnSave();

        Destroy(gameObject);
    }

    private bool isBuildAvailable()
    {
        for (int i = 0; i < prices.Count; i++)
        {
            if (prices[i].count > prices[i].resource.count)
            {
                return false;
            }
        }
        return true;
    }
}
[System.Serializable]
public class Price
{
    public Resource resource;
    public TextMeshProUGUI countText;
    public int count;
}
