using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    public Image flashImage;
    public bool flash;
    public float flashTime;
    public Color flashColor;

    private void Update()
    {
        if (flash)
        {
            flashImage.color = Color.Lerp(flashImage.color, flashColor, flashTime * Time.deltaTime);

            if (flashImage.color.a >= 0.5)
            {
                flash = false;
            }
        }
        else
        {
            Color trasparent = flashColor;
            trasparent.a = 0;
            flashImage.color = Color.Lerp(flashImage.color, trasparent, flashTime * Time.deltaTime);
        }
    }
}
