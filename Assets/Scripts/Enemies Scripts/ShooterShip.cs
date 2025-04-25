using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterShip : MonoBehaviour
{
    [SerializeField] float MaxHP;
    float currentHP;

    [SerializeField] float damageCrash;
    [SerializeField] float moveSpeed;
    [SerializeField] float distanceFromPlayerToShoot;

    [SerializeField] float damage;
    [SerializeField] float fireRate;
    [SerializeField] float bulletSpeed;
    ScoreHandler scoreHandlerReference;
    MainShip ms_ref;

    [SerializeField] GameObject healthBarPrefab;

    [SerializeField] Sprite[] shooterDeterioration;
    public float MaxHPValue()
    {
        return MaxHP;
    }
    public float currentHPValue()
    {
        return currentHP;
    }

    public void decreaseFromHP(float amountOfDamage)
    {
        currentHP -= amountOfDamage;
    }
    public float DamageCrashValue()
    {
        return damageCrash;
    }
    public float DamageValue()
    {
        return damage;
    }
    public float MoveSpeedValue()
    {
        return moveSpeed;
    }
    public float DistanceValue()
    {
        return distanceFromPlayerToShoot;
    }
    public float FireRateValue()
    {
        return fireRate;
    }

    public float BulletSpeedValue()
    {
        return bulletSpeed;
    }
    private void Awake()
    {
        scoreHandlerReference = FindObjectOfType<ScoreHandler>();
        currentHP = MaxHP;
        ms_ref = FindObjectOfType<MainShip>();
        CreateHealthBar();
    }

    private void Update()
    {
        if (currentHP <= 0)
        {
            Explode();
        }

        if ((currentHPValue() / MaxHPValue()) < 0.7 && (currentHPValue() / MaxHPValue()) >= 0.3)
            GetComponent<SpriteRenderer>().sprite = shooterDeterioration[0];
        else if ((currentHPValue() / MaxHPValue()) < 0.3)
            GetComponent<SpriteRenderer>().sprite = shooterDeterioration[1];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ms_ref.decreaseFromHP(damageCrash);
            Explode();
        }
    }

    void Explode()
    {
        scoreHandlerReference.score += 1;
        Instantiate(ms_ref.explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void CreateHealthBar()
    {
        GameObject HealthBar = Instantiate(healthBarPrefab);
        HealthBar.GetComponent<ObjectFollower>().objectToBeFollowed = transform;
    }
}
