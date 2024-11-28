using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiritBar : MonoBehaviour
{
    public Slider spiritSlider;

    public void UpdateSpirit(int amount)
    {
        spiritSlider.value += amount;
        if (spiritSlider.value <= 0)
        {
            Debug.Log("Game Over!");
        }
    }
}
