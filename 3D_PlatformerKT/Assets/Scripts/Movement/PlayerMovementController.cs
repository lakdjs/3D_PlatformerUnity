using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _jumpPower;
    //[SerializeField] private PlayerAnimationsPlayer _playerAnimationsPlayer;
    private bool _onGround = true;
    void Start()
    {

    }
    private void FixedUpdate()
    {


        //OldInput();
        // PlayerMove();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _onGround)
        {
            _rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
           // _playerAnimationsPlayer.PlayJump();
        }
        PlayerMove();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _onGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _onGround = false;
        }
    }
    private void PlayerMove()
    {
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector3(x * _speed, _rigidbody.velocity.y, -z * _speed);
       // if (z != 0 || x != 0)
       // {
        //    _playerAnimationsPlayer.PlayMove();
        //}
       // else
       // {
       //     _playerAnimationsPlayer.PlayIDLE();
       // }
    }

    private void OldInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.velocity = Vector3.forward * _speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.velocity = Vector3.back * _speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.velocity = Vector3.right * _speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.velocity = Vector3.left * _speed;
        }
    }


}
