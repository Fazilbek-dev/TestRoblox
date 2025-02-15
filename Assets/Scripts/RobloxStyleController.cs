using UnityEngine;

public class RobloxStyleController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float gravity = 9.81f;

    [Header("Camera Settings")]
    public Transform cameraPivot;
    public float rotationSpeed = 5f;

    private CharacterController controller;
    private Vector3 velocity;
    private Transform cam;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        Move();
        RotateCharacter();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = cam.forward * vertical + cam.right * horizontal;
        moveDirection.y = 0;
        moveDirection.Normalize();

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (controller.isGrounded)
        {
            velocity.y = -gravity * Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpForce;
            }
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);
    }

    void RotateCharacter()
    {
        Vector3 lookDirection = new Vector3(cam.forward.x, 0, cam.forward.z).normalized;
        if (lookDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}