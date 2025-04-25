using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] Transform mainCannonPosition;
    [SerializeField] Transform[] RightCannonPositions;
    [SerializeField] Transform[] LeftCannonPositions;
    [SerializeField] GameObject mainCannonBallPrefab;
    [SerializeField] GameObject sideCannonBallPrefab;
    [SerializeField] GameObject shootExplosionPrefab;
    float mainCannonBallVelocity;
    float sideCannonBallVelocity;
    float cannonBallFireRate;
    float cannonBallFireRateStorage;

    private void Awake()
    {
        mainCannonBallVelocity = GetComponent<MainShip>().MainCannonBallSpeedvalue();
        sideCannonBallVelocity = GetComponent<MainShip>().MainCannonBallSpeedvalue();
        cannonBallFireRate = GetComponent<MainShip>().FireRatevalue();
        cannonBallFireRateStorage = cannonBallFireRate;
        cannonBallFireRate = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (cannonBallFireRate > 0)
            cannonBallFireRate -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0))
        {         
            if(cannonBallFireRate <=0)
                MainShoot();
        }

        else if (Input.GetKey(KeyCode.Mouse1))
        {
            if(cannonBallFireRate <= 0)
            {
                RightShoot();
                LeftShoot();
            }

        }

    }

    void MainShoot()
    {
        cannonBallFireRate = cannonBallFireRateStorage;
        GameObject shootExplosion = Instantiate(shootExplosionPrefab, mainCannonPosition.position, Quaternion.identity);
        shootExplosion.transform.localScale = new Vector2(0.5f, 0.5f);
        shootExplosion.transform.parent = transform;
        GameObject cannonBall = Instantiate(mainCannonBallPrefab, mainCannonPosition.position,  mainCannonPosition.rotation);
        cannonBall.GetComponent<Bullet>().damage = GetComponent<MainShip>().DamageMainCannonvalue();
        Rigidbody2D cannonBallRB = cannonBall.GetComponent<Rigidbody2D>();
        cannonBallRB.AddForce(-mainCannonPosition.up * mainCannonBallVelocity, ForceMode2D.Impulse);
    }

    void RightShoot()
    {
        cannonBallFireRate = cannonBallFireRateStorage;
        foreach (Transform cannon in RightCannonPositions)
        {
            GameObject shootExplosion = Instantiate(shootExplosionPrefab, cannon.position, Quaternion.identity);
            shootExplosion.transform.localScale = new Vector2(0.3f, 0.3f);
            shootExplosion.transform.parent = transform;
            GameObject cannonBall = Instantiate(sideCannonBallPrefab, cannon.position, cannon.rotation);
            cannonBall.GetComponent<Bullet>().damage = GetComponent<MainShip>().DamageSideCannonsvalue();
            Rigidbody2D cannonBallRB = cannonBall.GetComponent<Rigidbody2D>();
            cannonBallRB.AddForce(cannon.right * sideCannonBallVelocity, ForceMode2D.Impulse);
        }       
    }

    void LeftShoot()
    {
        cannonBallFireRate = cannonBallFireRateStorage;
        foreach (Transform cannon in LeftCannonPositions)
        {
            GameObject shootExplosion = Instantiate(shootExplosionPrefab, cannon.position, Quaternion.identity);
            shootExplosion.transform.localScale = new Vector2(0.3f, 0.3f);
            shootExplosion.transform.parent = transform;
            GameObject cannonBall = Instantiate(sideCannonBallPrefab, cannon.position, cannon.rotation);
            cannonBall.GetComponent<Bullet>().damage = GetComponent<MainShip>().DamageSideCannonsvalue();
            Rigidbody2D cannonBallRB = cannonBall.GetComponent<Rigidbody2D>();
            cannonBallRB.AddForce(-cannon.right * sideCannonBallVelocity, ForceMode2D.Impulse);
        }
    }
}
