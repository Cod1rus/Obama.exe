using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float MouseSensitivity = 200;
    [SerializeField]
    private float JumpHeight = 4;
    [SerializeField]
    private Rigidbody rb;

    private PlayerMotor Motor;
    

    private float distToGround;
    Collider _collider;

    private void Start()
    {
        Motor = GetComponent<PlayerMotor>();
        //rb.GetComponent<Rigidbody>();
        transform.GetComponent<Transform>();
        _collider = GetComponentInChildren<CapsuleCollider>();
        distToGround = _collider.bounds.extents.y;
    }

    private void Update()
    {
        if (PauseMenu.IsOn)
        {
            return;
        }

        float _xMove = Input.GetAxisRaw("Horizontal");
        float _zMove = Input.GetAxisRaw("Vertical");
        //float _jumpMove = Input.GetAxisRaw("Jump"); ;
        

        Vector3 _movHorizontal = transform.right * _xMove;
        Vector3 _movVertical = transform.forward * _zMove;
        Vector3 _velocity = Vector3.zero;

        //Vector3 _movJump = new Vector3(0f, _jumpMove * JumpHeight, 0f);
        _velocity = (_movHorizontal + _movVertical).normalized * speed;
        //_velocity = (_velocity + _movJump);
        Motor.Move(_velocity);




        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * MouseSensitivity;

        Motor.Rotate(_rotation);


        float _xRot = Input.GetAxisRaw("Mouse Y");


        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * MouseSensitivity;

        Motor.RotateCamera(_cameraRotation);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
           
            Motor.PerformJump(JumpHeight);
            
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(rb.position, -Vector3.up, distToGround +0,1 );
    }

}
