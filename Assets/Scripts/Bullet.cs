using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: MonoBehaviour
{
    // Use this for initialization
    [SerializeField]
    GameObject explosion;

    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "EnemyCannon")
        {
            if (collision.gameObject.tag == "Border")
                Destroy(gameObject);

            else if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<MainShip>().decreaseFromHP(damage);
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "Obstacle")
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.gameObject.tag == "Border")
                Destroy(gameObject);

            else if (collision.gameObject.name == "Chaser Ship" || collision.gameObject.name == "Chaser Ship(Clone)")
            {
                collision.gameObject.GetComponent<ChaserShip>().decreaseFromHP(damage);
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (collision.gameObject.name == "Shooter Ship" || collision.gameObject.name == "Shooter Ship(Clone)")
            {
                collision.gameObject.GetComponent<ShooterShip>().decreaseFromHP(damage);
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            else if (collision.gameObject.tag == "Obstacle")
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

    }
}
