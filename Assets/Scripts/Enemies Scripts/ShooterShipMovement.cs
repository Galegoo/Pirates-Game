using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterShipMovement : MonoBehaviour
{
    GameObject mainShip;

    Rigidbody2D rb;

    float moveSpeed;
    float distance;

    bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        mainShip = FindObjectOfType<MainShip>().gameObject;
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = GetComponent<ShooterShip>().MoveSpeedValue() / 1000;
        distance = GetComponent<ShooterShip>().DistanceValue();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerAndEndGameHandler.gameover == false)
        {
            Quaternion rotation = Quaternion.LookRotation(mainShip.transform.position - transform.position, transform.TransformDirection(Vector3.forward));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

            if (Vector3.Distance(mainShip.transform.position, transform.position) >= distance)
            {
                transform.position = Vector3.MoveTowards(transform.position, mainShip.transform.position, moveSpeed);
                inRange = false;
            }
            else
                inRange = true;
        }
    }

    public bool IsShipInRangeToShoot()
    {
        return inRange;
    }

}
