using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed;

    public Rigidbody2D rb;
    public Camera camera;

    Vector2 movement;
    Vector2 mousePos;

    bool mouseIsOnTopOfTheShip = false;

    private void Awake()
    {
        moveSpeed = GetComponent<MainShip>().MoveSpeedvalue();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            movement = -(transform.rotation * Vector2.up);

        else
            movement = new Vector2(0f,0f);


        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        if (!mouseIsOnTopOfTheShip)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(-lookDir.y, -lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }

    private void OnMouseOver()
    {
        mouseIsOnTopOfTheShip = true;
    }

    private void OnMouseExit()
    {
        mouseIsOnTopOfTheShip = false;
    }
}
