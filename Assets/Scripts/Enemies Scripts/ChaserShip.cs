using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserShip : MonoBehaviour
{
    [SerializeField] float MaxHP;
    float currentHP;
    [SerializeField] float moveSpeed;
    [SerializeField] float damage;
    [SerializeField] Sprite[] chaserDeterioration;
    MainShip ms_ref;

    [SerializeField] GameObject healthBarPrefab;
    ScoreHandler scoreHandlerReference;

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
    public float MoveSpeedValue()
    {
        return moveSpeed;
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
        if(currentHP <= 0)
        {
            Explode();
        }

        if ((currentHPValue() / MaxHPValue()) < 0.7 && (currentHPValue() / MaxHPValue()) >= 0.3)
            GetComponent<SpriteRenderer>().sprite = chaserDeterioration[0];
        else if ((currentHPValue() / MaxHPValue()) < 0.3)
            GetComponent<SpriteRenderer>().sprite = chaserDeterioration[1];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ms_ref.decreaseFromHP(damage);
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
