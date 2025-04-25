using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainShip : MonoBehaviour
{
    [SerializeField] float MaxHP ;
    float currentHP;
    [SerializeField] float moveSpeed;
    [SerializeField] float fireRate;
    [SerializeField] float mainCannonBallSpeed;
    [SerializeField] float sideCannonBallSpeed;
    [SerializeField] float damageMainCannon;
    [SerializeField] float damageSideCannons;
    [SerializeField] Sprite[] playerDeterioration;

    public GameObject explosionPrefab;


    public float MaxHPvalue()
    {
        return MaxHP;
    }
    public float currentHPvalue()
    {
        return currentHP;
    }

    public void decreaseFromHP(float amountOfDamage)
    {
        currentHP -= amountOfDamage;
    }
    public void increaseFromHP(float amountOfHeal)
    {
        currentHP += amountOfHeal;
    }

    public float MoveSpeedvalue()
    {
        return moveSpeed;
    }

    public float FireRatevalue()
    {
        return fireRate;
    }

    public float MainCannonBallSpeedvalue()
    {
        return mainCannonBallSpeed;
    }
    public float SainCannonBallSpeedvalue()
    {
        return sideCannonBallSpeed;
    }

    public float DamageMainCannonvalue()
    {
        return damageMainCannon;
    }

    public float DamageSideCannonsvalue()
    {
        return damageSideCannons;
    }

    private void Awake()
    {
        currentHP = MaxHP;
    }

    private void Update()
    {
        GameOver();

        if ((currentHPvalue() / MaxHPvalue()) < 0.7 && (currentHPvalue() / MaxHPvalue()) >= 0.3)
            GetComponent<SpriteRenderer>().sprite = playerDeterioration[0];
        else if ((currentHPvalue() / MaxHPvalue()) < 0.3)
            GetComponent<SpriteRenderer>().sprite = playerDeterioration[1];


    }

    void GameOver()
    {
        if (currentHPvalue() <= 0)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            GetComponent<PlayerMovement>().enabled = false;
            FindObjectOfType<TimerAndEndGameHandler>().GameOver();
            Destroy(gameObject);
        }
    }
}
