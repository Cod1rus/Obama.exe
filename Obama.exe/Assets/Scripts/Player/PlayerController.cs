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

    private PlayerMotor Motor;

    private void Start()
    {
        Motor = GetComponent<PlayerMotor>();

    }

    private void Update()
    {
        float _xMove = Input.GetAxisRaw("Horizontal");
        float _zMove = Input.GetAxisRaw("Vertical");
        float _jumpMove = Input.GetAxisRaw("Jump"); ;

        //if (Input.GetButtonDown("Jump"))
        //{
        //    _jumpMove = 1;
        //}
        

        Vector3 _movHorizontal = transform.right * _xMove;
        Vector3 _movVertical = transform.forward * _zMove;
        Vector3 _velocity = Vector3.zero;
        //if (_velocity.y == 0f)
        //{
        Vector3 _movJump = new Vector3(0f, _jumpMove * JumpHeight, 0f);
        _velocity = (_movHorizontal + _movVertical).normalized * speed;
        _velocity = (_velocity + _movJump);
        Motor.Move(_velocity);
        //}
        //else
        //{
        //    _velocity = (_movHorizontal + _movVertical).normalized * speed;
        //    Motor.Move(_velocity);
        //}



        //Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;
        //_velocity = (_velocity + _movJump);



        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * MouseSensitivity;

        Motor.Rotate(_rotation);


        float _xRot = Input.GetAxisRaw("Mouse Y");


        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * MouseSensitivity;

        Motor.RotateCamera(_cameraRotation);



    }


}
