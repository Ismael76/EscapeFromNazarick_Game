using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpCoolDown2 : MonoBehaviour
{
    public Image powerUp2;
    public static bool isCoolDown = false;

    void Start()
    {
        powerUp2.fillAmount = 0f;
    }

    void Update()
    {
        coolDownPowerUp2();
    }

    void coolDownPowerUp2()
    {

        if (PowerUp2.isUsingPowerUp2 == true && isCoolDown == false)
        {

            isCoolDown = true;
            powerUp2.fillAmount = 1f;

            if (powerUp2.fillAmount == 1f)
            {
                return;
            }
        }

        if (isCoolDown)
        {

            powerUp2.fillAmount -= 1 / 15f * Time.deltaTime;

            if (powerUp2.fillAmount <= 0)
            {

                powerUp2.fillAmount = 0f;
                isCoolDown = false;
            }
        }

    }
}
