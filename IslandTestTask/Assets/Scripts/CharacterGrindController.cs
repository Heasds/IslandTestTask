using UnityEngine;

public class CharacterGrindController : MonoBehaviour
{
    private ResourcePoint resourcePoint;
    private Animator animator;


    [SerializeField] [Range(1f,5f)] private float extractSpeed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("Extract Speed", extractSpeed);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ResourcePoint>() != null)
        {
            resourcePoint = other.GetComponent<ResourcePoint>();
            animator.SetBool("Extract", resourcePoint.isReady);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Extract", false);
        resourcePoint = null;
    }

    public void MineResources()
    {
        if (resourcePoint != null)
        {
            if (resourcePoint.isReady)
            {
                resourcePoint.ExtractResource();
            }

            if (resourcePoint.activePiece == resourcePoint.meshPieces.Count) 
            {
                resourcePoint.isReady = false;
                StartCoroutine(resourcePoint.RecoveryPoint());
            }
        }
    }
}
