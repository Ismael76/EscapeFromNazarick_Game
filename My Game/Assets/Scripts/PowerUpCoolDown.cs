using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpCoolDown : MonoBehaviour
{

    public Image powerUp;
    public static bool isCoolDown = false;

    void Start()
    {
        powerUp.fillAmount = 0f;

    }

    void Update()
    {
        coolDownPowerUp();
        
    }

    void coolDownPowerUp() {

        if(PowerUp.isUsingPowerUp1 == true && isCoolDown == false) {

            isCoolDown = true;
            powerUp.fillAmount = 1f;

            if (powerUp.fillAmount == 1f) {
                return;
            }
        }

        if (isCoolDown) {

            powerUp.fillAmount -= 1 / 15f * Time.deltaTime;

            if(powerUp.fillAmount <= 0) {
                powerUp.fillAmount = 0f;
                isCoolDown = false;
            }
        }

    }

}
