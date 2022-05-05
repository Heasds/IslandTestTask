using System.Collections;
using UnityEngine;

public class ResourcePoint : MonoBehaviour
{
    private ResorcesController resorcesController;
    private SphereCollider sphereCollider;

    [SerializeField] private ParticleSystem fx;
    [SerializeField] private Resource extractiveResource;

    public Transform mesh;
    public Vector3 scaleStep;
    [Range(1,5)] public float recoveryTime;

    private void Start()
    {
        resorcesController = GameObject.FindGameObjectWithTag("ResourcesController").GetComponent<ResorcesController>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(RecoveryPoint());
    }

    public void ExtractResource()
    {
        if (mesh.localScale.x > 0.3)
        {
            fx.Play();
            mesh.localScale -= scaleStep;
            resorcesController.ChangeResourceValue(extractiveResource, 1);
        }
        else
        {
            sphereCollider.enabled = false;
            StartCoroutine(RecoveryPoint());
        }
    }

    public IEnumerator RecoveryPoint()
    {
        if (mesh.localScale.x < 1)
        {
            mesh.localScale += scaleStep;
            yield return new WaitForSeconds(recoveryTime / (1 / scaleStep.x));
            StartCoroutine(RecoveryPoint());
        }
        else
        {
            StopCoroutine(RecoveryPoint());
            sphereCollider.enabled = true;
        }
    }
}
