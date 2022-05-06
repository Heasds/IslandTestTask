using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePoint : MonoBehaviour
{
    public List<GameObject> meshPieces;
    public int activePiece;
    public bool isReady;
    private ResorcesController resorcesController;
    private CharacterGrindController character;

    [SerializeField] private ParticleSystem fx;
    [SerializeField] private Resource extractiveResource;

    public Transform mesh;
    [Range(1,5)] public float recoveryTime;

    private void Start()
    {
        isReady = true;
        activePiece = 0;
        resorcesController = GameObject.FindGameObjectWithTag("ResourcesController").GetComponent<ResorcesController>();

        for (int i = 0; i < mesh.childCount; i++)
        {
            meshPieces.Add(mesh.GetChild(i).gameObject);
        }

    }
    public void ExtractResource()
    {
        if (activePiece < meshPieces.Count && isReady)
        {
            resorcesController.ChangeResourceValue(extractiveResource, 1);
            fx.Play();
            meshPieces[activePiece].SetActive(false);
            activePiece++;
        }

        //if (mesh.localScale.x > 0.3)
        //{
        //    fx.Play();
        //    mesh.localScale -= scaleStep;
        //}
        //else
        //{
        //    sphereCollider.enabled = false;
        //    StartCoroutine(RecoveryPoint());
        //}
    }

    public IEnumerator RecoveryPoint()
    {
        if (activePiece > 0)
        {
            yield return new WaitForSeconds(recoveryTime);
            activePiece--;
            meshPieces[activePiece].SetActive(true);
            StartCoroutine(RecoveryPoint());
        }
        else
        {
            StopCoroutine(RecoveryPoint());
            isReady = true;
        }
    }
}
