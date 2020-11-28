using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpCoolDown3 : MonoBehaviour
{
    public Image powerUp3;
    public static bool isCoolDown = false;

    void Start()
    {
        powerUp3.fillAmount = 0f;
    }


    void Update()
    {
        coolDownPowerUp3();
    }

    void coolDownPowerUp3()
    {

        if (PowerUp3.isUsingPowerUp3 == true && isCoolDown == false)
        {

            isCoolDown = true;
            powerUp3.fillAmount = 1f;

            if (powerUp3.fillAmount == 1f)
            {
                return;
            }
        }

        if (isCoolDown)
        {

            powerUp3.fillAmount -= 1 / 15f * Time.deltaTime;

            if (powerUp3.fillAmount <= 0)
            {

                powerUp3.fillAmount = 0f;
                isCoolDown = false;
            }
        }

    }
}
