using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;

    public Camera cam;
    public GameObject camPoint;
    public AudioClip[] grunts;
    public AudioClip[] jumps;

    private bool isGrounded;
    private float verticalLookRotation;
    private AudioSource audio;
    private Vector3 checkPointLocation;
    private string checkPointName;

    private Vector3 smoothMoveVelocity;
    private Vector3 moveAmount;

    private Rigidbody rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    //movement 
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }


    //jump n shit
    private void Update()
    {
        if (GameController.Instance.countdownFinished)
        {
            Look();

            Move();

            Jump();
        }
        
    }

    void Look()
    {
        if (!GameController.Instance.IsGamePaused())
        {
            transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

            verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -10f, 10f);

            camPoint.transform.localEulerAngles = Vector3.left * verticalLookRotation;
        }
    }

    void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !GameController.Instance.IsGamePaused())
        {
            rb.AddForce(transform.up * jumpForce);
            AudioClip jump = jumps[Random.Range(0, jumps.Length)];
            audio.volume = 0.4f;
            audio.PlayOneShot(jump);
        }
    }

    public void SetGrounded(bool _isGrounded)
    {
        isGrounded = _isGrounded;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obsticle"))
        {
            //play random grunt sound
            AudioClip grunt = grunts[Random.Range(0,grunts.Length)];
            audio.volume = 0.8f;
            audio.PlayOneShot(grunt);
        }

        if (collision.gameObject.CompareTag("Bounds"))
        {
            if(checkPointName == "RollerCP")
            {
                Roller.Instance.ResetPosition();
            }
            gameObject.transform.position = checkPointLocation;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "StartCP")
        {
            checkPointLocation = other.gameObject.transform.position;
            checkPointName = "StartCP";
            Debug.Log("Checkpoint is now" + other.gameObject.name);
        }
        else if(other.gameObject.name == "YinYangCP")
        {
            checkPointLocation = other.gameObject.transform.position;
            checkPointName = "YinYangCP";
            Debug.Log("Checkpoint is now" + other.gameObject.name);
        }
        else if (other.gameObject.name == "GrinderCP")
        {
            checkPointLocation = other.gameObject.transform.position;
            checkPointName = "GrinderCP";
            Debug.Log("Checkpoint is now" + other.gameObject.name);
        }
        else if (other.gameObject.name == "RollerCP")
        {
            checkPointLocation = other.gameObject.transform.position;
            checkPointName = "RollerCP";
            Debug.Log("Checkpoint is now" + other.gameObject.name);
        }
        else if (other.gameObject.name == "PunchwallCP")
        {
            checkPointLocation = other.gameObject.transform.position;
            checkPointName = "PunchwallCP";
            Debug.Log("Checkpoint is now" + other.gameObject.name);
        }
        else if (other.gameObject.name == "DoorCP")
        {
            checkPointLocation = other.gameObject.transform.position;
            checkPointName = "DoorCP";
            Debug.Log("Checkpoint is now" + other.gameObject.name);
        }
    }

}
