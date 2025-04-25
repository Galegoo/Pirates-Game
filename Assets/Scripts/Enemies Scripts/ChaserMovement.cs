using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserMovement : MonoBehaviour
{
    GameObject mainShip;

    Rigidbody2D rb;

    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        mainShip = FindObjectOfType<MainShip>().gameObject;
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = GetComponent<ChaserShip>().MoveSpeedValue() / 200;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerAndEndGameHandler.gameover == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, mainShip.transform.position, moveSpeed);
            Quaternion rotation = Quaternion.LookRotation(mainShip.transform.position - transform.position, transform.TransformDirection(Vector3.forward));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        }
    }


}
