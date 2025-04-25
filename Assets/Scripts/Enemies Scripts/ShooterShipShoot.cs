using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterShipShoot : MonoBehaviour
{

    [SerializeField] Transform mainCannonPosition;
    [SerializeField] GameObject shootExplosionPrefab;
    [SerializeField] GameObject enemyCannonBallPrefab;
    float cannonBallVelocity;
    float cannonBallFireRate;
    float cannonBallFireRateStorage;
    ShooterShipMovement SSM_ref;

    private void Awake()
    {
        cannonBallVelocity = GetComponent<ShooterShip>().BulletSpeedValue();
        cannonBallFireRateStorage = GetComponent<ShooterShip>().FireRateValue();
        cannonBallFireRate = 0f;
        SSM_ref = GetComponent<ShooterShipMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cannonBallFireRate > 0)
            cannonBallFireRate -= Time.deltaTime;

        if (TimerAndEndGameHandler.gameover == false)
        {
            if (SSM_ref.IsShipInRangeToShoot() == true)
            {
                if (cannonBallFireRate <= 0)
                    Shoot();
            }
        }
    }

    void Shoot()
    {
        cannonBallFireRate = cannonBallFireRateStorage;
        GameObject shootExplosion = Instantiate(shootExplosionPrefab, mainCannonPosition.position, Quaternion.identity);
        shootExplosion.transform.localScale = new Vector2(0.5f, 0.5f);
        shootExplosion.transform.parent = transform;
        GameObject enemyCannonBall = Instantiate(enemyCannonBallPrefab, mainCannonPosition.position, mainCannonPosition.rotation);
        enemyCannonBall.GetComponent<Bullet>().damage = GetComponent<ShooterShip>().DamageValue();
        Rigidbody2D enemyCannonBallRB = enemyCannonBall.GetComponent<Rigidbody2D>();
        enemyCannonBallRB.AddForce(-mainCannonPosition.up * cannonBallVelocity, ForceMode2D.Impulse);
    }
}