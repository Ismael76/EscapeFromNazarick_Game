using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensSlider : MonoBehaviour
{

    public Slider sensSlider;

    public void AdjustMouseSens()
    {

        GetComponent<CameraMovement>().ChangeMouseSensitivity(sensSlider.value);

    }
}
