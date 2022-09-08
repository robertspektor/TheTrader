using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb; 

    private Vector2 moveDirection;


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        MoveToPoint();
    }

    void ProcessInputs()
    {
        

        
    }

    void MoveToPoint()
    {
        Vector2 moveDir = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - rb.position;
        moveDir.Normalize();
        float rotateAmount = Vector3.Cross(moveDir, transform.up).z;
        rb.angularVelocity = -rotateAmount * 200f;
        rb.velocity = transform.up * moveSpeed;
    }

}
