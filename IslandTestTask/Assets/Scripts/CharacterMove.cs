using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Vector3 startPos;
    private Vector3 startRotation;
    private Vector3 velocity;

    private CharacterController characterController;
    private Animator animator;
    public Joystick joystick;

    public float gravity = -9;
    public float moveSpeed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        startRotation = transform.rotation.eulerAngles;
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 joystickDir = new Vector2(joystick.Horizontal, joystick.Vertical);

        if (joystickDir.magnitude > 0.1f)
        {
            animator.SetBool("Run", true);

            float angel = Vector2.SignedAngle(Vector2.up, joystickDir);
            var newRotation = startRotation;
            newRotation.y -= angel;
            transform.localRotation = Quaternion.Euler(newRotation);

            Vector3 moveVector = transform.forward;
            characterController.Move(moveVector * (Time.deltaTime * moveSpeed));
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (!characterController.isGrounded)
        {
            velocity.y -= gravity * -2f * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
    }
}