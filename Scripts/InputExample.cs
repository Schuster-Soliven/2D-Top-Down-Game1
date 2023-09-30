using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputExample : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D jumpingBody, movingBody;
    [SerializeField]
    bool useForce = true;
    [SerializeField]
    float jumpPower = 6f, moveSpeed = 10f;

    Vector2 moveDir = Vector2.zero;
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movingBody) 
        if(useForce) 
            movingBody.AddForce(moveDir, ForceMode2D.Force);
        else
            movingBody.MovePosition(movingBody.position+(moveDir*moveSpeed*Time.deltaTime));
    }

    void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>() * moveSpeed;
        Debug.Log(moveDir);
    }

    void OnJump()
    {
        if(jumpingBody) jumpingBody.AddForce(Vector2.up*jumpPower,ForceMode2D.Impulse);
        Debug.Log("jump");
    }
}
