using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotNControllerScript : MonoBehaviour
{
    public GameObject CharacterContainer;
    public GameObject CameraContainer;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float jumpHeight = 2.0f;
    private float gravityValue = -9.81f;

    private Animator anim;
    private CharacterController controller;

    private float runSpeed = 4f;
    private float walkSpeed = 2f;
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = CharacterContainer.GetComponent<Animator>();
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        Rotate();
        Move();
        Animate();
    }

    private void Animate()
    {
        // Walking
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            SetMoveState("isWalk", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                SetMoveState("isRun", true);
            }
            else
            {
                SetMoveState("isRun", false);
            }
        } 
        else
        {
            SetMoveState("isWalk", false);
            SetMoveState("isRun", false);
        }

    }

    private void RotateCamera()
    {
        float rotation = Input.GetAxis("Mouse X");
        CameraContainer.transform.Rotate(0f, rotation * 2, 0f);
    }

    private void Rotate()
    {
        float forward = Input.GetAxis("Vertical");
        float side = Input.GetAxis("Horizontal");
        if (forward == 0 && side == 0)
        {
            return;
        }
        Vector3 move = new Vector3(side, 0, forward);
        move = CameraContainer.transform.TransformDirection(move);
        Quaternion target = Quaternion.LookRotation(move);
        CharacterContainer.transform.rotation = Quaternion.Slerp(CharacterContainer.transform.rotation, target, 20f * Time.deltaTime);
    }

    private void Move()
    {
        float forward = Input.GetAxis("Vertical");
        float side = Input.GetAxis("Horizontal");

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(side, 0, forward);
        move = CameraContainer.transform.TransformDirection(move);
        
        controller.Move(move * Time.deltaTime * speed);

        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

        // Changes the height position of the player..
        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            anim.SetTrigger("JumpTrigger");
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3f * gravityValue);
        }

        playerVelocity.y += gravityValue * 2f * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void SetMoveState(string type, bool value)
    {
        switch (type)
        {
            case "isWalk":
                SetWalk(value);
                break;
            case "isRun":
                SetRun(value);
                break;
            default:
                break;
        }
    }

    private void SetWalk(bool value)
    {
        if (value)
        {
            speed = walkSpeed;
        }
        anim.SetBool("isWalk", value);
    }

    private void SetRun(bool value)
    {
        if (value)
        {
            speed = runSpeed;
        }
        anim.SetBool("isRun", value);
    }
}
