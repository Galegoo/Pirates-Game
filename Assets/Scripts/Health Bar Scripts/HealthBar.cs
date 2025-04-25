using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    GameObject fatherOfHB;
    [SerializeField] MainShip MS_reference;
    [SerializeField] ChaserShip CS_reference;
    [SerializeField]  ShooterShip SS_reference;

    Color tempColor;


    private void Start()
    {
        fatherOfHB = GetComponentInParent<ObjectFollower>().objectToBeFollowed.gameObject;
        slider = GetComponent<Slider>();
        if (fatherOfHB.gameObject.name == "PlayerShip")
        {
            tempColor = Color.green;
            MS_reference = fatherOfHB.GetComponent<MainShip>();
        }           
        else if (fatherOfHB.gameObject.name == "Chaser Ship" || fatherOfHB.gameObject.name == "Chaser Ship(Clone)")
        {
            tempColor = Color.red;
            CS_reference = fatherOfHB.GetComponent<ChaserShip>();
        }
        else if (fatherOfHB.gameObject.name == "Shooter Ship" || fatherOfHB.gameObject.name == "Shooter Ship(Clone)")
        {
            tempColor = Color.red;
            SS_reference = fatherOfHB.GetComponent<ShooterShip>();
        }

    }
    void Update ()
    {
        if (slider.value <= 0)
        {
            Destroy(gameObject);
        }

        if(fatherOfHB != null)
        {
            if (fatherOfHB.gameObject.name == "PlayerShip")
            {
                slider.maxValue = MS_reference.MaxHPvalue();
                slider.value = MS_reference.currentHPvalue();

                if ((MS_reference.currentHPvalue() / MS_reference.MaxHPvalue()) < 0.7 && (MS_reference.currentHPvalue() / MS_reference.MaxHPvalue()) >= 0.3)
                    tempColor = Color.yellow;

                else if ((MS_reference.currentHPvalue() / MS_reference.MaxHPvalue()) < 0.3)
                    tempColor = Color.red;
            }
            else if (fatherOfHB.gameObject.name == "Chaser Ship" || fatherOfHB.gameObject.name == "Chaser Ship(Clone)")
            {
                slider.maxValue = CS_reference.MaxHPValue();
                slider.value = CS_reference.currentHPValue();
                tempColor = Color.red;
            }
            else if (fatherOfHB.gameObject.name == "Shooter Ship" || fatherOfHB.gameObject.name == "Shooter Ship(Clone)")
            {
                slider.maxValue = SS_reference.MaxHPValue();
                slider.value = SS_reference.currentHPValue();
                tempColor = Color.red;
            }
            tempColor.a = 0.4f;
            GetComponentInChildren<Image>().color = tempColor;
        }




    }
    

}
