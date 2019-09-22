using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 JoystickAim;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetAxisRaw("AimX") != 0f || Input.GetAxisRaw("AimY") != 0f)
        {
            JoystickAim = new Vector2(transform.position.x + Input.GetAxisRaw("AimX"), transform.position.y - Input.GetAxisRaw("AimY"));
            rb.freezeRotation = false;
        }
        else
        {
            JoystickAim = Vector2.zero;
            rb.freezeRotation = true;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (JoystickAim != Vector2.zero)
        {
            Vector2 lookDir = JoystickAim - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, angle, 25f * Time.fixedDeltaTime));
        }
    }
}
