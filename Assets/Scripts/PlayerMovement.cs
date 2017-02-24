using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _rigidBody;
    private Animator _animator;

    // Use this for initialization
    void Start ()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    Vector2 inputVector = PlayerInput.GetMovementInput();
        if (inputVector != Vector2.zero)
        {
            _animator.SetFloat("inputX", inputVector.x);
            _animator.SetFloat("inputY", inputVector.y);
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }

        _rigidBody.MovePosition(_rigidBody.position + inputVector.normalized * Time.deltaTime);
    }
}
