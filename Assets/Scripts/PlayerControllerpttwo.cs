using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerpttwo : MonoBehaviour
{
    // Start is called before the first frame updat
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 6.0f;
    [SerializeField] float walkSpeed = 4.0f;
    [SerializeField] float sprintSpeed = 6.0f;
    [SerializeField] float acceleration = 18.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    private float MouseX;
    private float MouseY;
    private float cameraPitch = 0.0f;
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.0f;
    [SerializeField] bool lockCursor = true;
    public delegate void PlayerKilled();
    public static event PlayerKilled OnPlayerKilled;
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;
    private void Start()
    {
        controller = GetComponent<CharacterController>();

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
         
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        controller.Move(move * Time.deltaTime * playerSpeed);
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight *  -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            die();
        }


        UpdateMouseLook();
        ControlSpeed();

    }

    void UpdateMouseLook()
    {
        //Camera crap
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;

        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7)
            groundedPlayer = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
            groundedPlayer = false;
    }
    void die()
    {
        Destroy(gameObject);

        if(OnPlayerKilled != null)
        {
            OnPlayerKilled();
        }
    }

    void ControlSpeed()
    {
        if(Input.GetKey(sprintKey) && groundedPlayer)
        {
            playerSpeed = Mathf.Lerp(playerSpeed, sprintSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            playerSpeed = Mathf.Lerp(playerSpeed, walkSpeed, acceleration * Time.deltaTime);
        }
    }



}

