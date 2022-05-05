using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform character;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - character.position;
    }

    private void Update()
    {
        transform.position = character.position + offset;
    }
}