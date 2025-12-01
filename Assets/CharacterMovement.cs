using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rb;
    
    public float accel = 400.0f;
    public float rotateSpeed = 2.0f;
    public float walkSpeed = 2.0f;
    public float runSpeed = 5.0f;
    private Vector3 moveDirection = Vector3.zero;
    
    public Animator anim;

    void FixedUpdate()
    {
        // --- RUCH ---
        float vertical = Input.GetAxis("Vertical");   // W/S lub strzałki
        float horizontal = Input.GetAxis("Horizontal"); // A/D lub strzałki

        // kierunek ruchu lokalnego
        moveDirection = new Vector3(0, 0, vertical);
        moveDirection = transform.TransformDirection(moveDirection);

        // przyspieszenie
        rb.AddForce(moveDirection * accel * Time.deltaTime);

        // obrót postaci
        transform.Rotate(0, horizontal * rotateSpeed, 0);

        // ograniczenie prędkości
        Vector3 vel = rb.velocity;
        float currentSpeed = vel.magnitude;

        if (currentSpeed > runSpeed)
        {
            rb.velocity = vel.normalized * runSpeed;
            currentSpeed = runSpeed;
        }

        // --- ANIMACJE ---

        // Idle
        if (Mathf.Abs(vertical) < 0.1f)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isBackwardWalking", false);
            anim.SetBool("isBackwardRunning", false);
        }
        else
        {
            anim.SetBool("isIdle", false);

            // Ruch do przodu
            if (vertical > 0)
            {
                if (vertical > 0.5f)
                {
                    anim.SetBool("isRunning", true);
                    anim.SetBool("isWalking", false);
                }
                else
                {
                    anim.SetBool("isWalking", true);
                    anim.SetBool("isRunning", false);
                }

                anim.SetBool("isBackwardWalking", false);
                anim.SetBool("isBackwardRunning", false);
            }
            // Ruch do tyłu
            else if (vertical < 0)
            {
                if (vertical < -0.5f)
                {
                    anim.SetBool("isBackwardRunning", true);
                    anim.SetBool("isBackwardWalking", false);
                }
                else
                {
                    anim.SetBool("isBackwardWalking", true);
                    anim.SetBool("isBackwardRunning", false);
                }

                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", false);
            }
        }

        // Skok
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }
    }
}
