using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    private bool BarOn, ColorOn, ParticleOn;
    private Color BackgroundColor, BarColor;
    
    // Start is called before the first frame update
    void Start()
    {
        BarOn = true;
        ColorOn = true;
        ParticleOn = true;
        BackgroundColor = GameObject.Find("Background").GetComponent<SpriteRenderer>().color;
    }
    
    public void ClickBarButton()
    {
        // If multiple bars are visible, make only one bar visible
        if (BarOn)
        {
            BarOn = false;
            Transform[] bars = GameObject.Find("Bars").GetComponentsInChildren<Transform>(true);
            foreach(Transform b in bars)
            {
                if (b.name == "Bars" || b.name == "Bar6")
                {
                    continue;
                }
                else
                {
                    b.gameObject.SetActive(false);
                }
            }
        }
        // If only one bar is visible, make multiple bars visible
        else if (!BarOn)
        {
            BarOn = true;
            Transform[] bars = GameObject.Find("Bars").GetComponentsInChildren<Transform>(true);
            foreach(Transform b in bars)
            {
                b.gameObject.SetActive(true);
            }
        }
    }

    public void ClickColorButton()
    {
        // If color is on, turn color off
        if (ColorOn)
        {
            ColorOn = false;
            GameObject.Find("Background").GetComponent<AudioSyncColor>().enabled = false;
            GameObject.Find("Background").GetComponent<SpriteRenderer>().color = BackgroundColor;

            // Transform[] bars = GameObject.Find("Bars").GetComponentsInChildren<Transform>(true);
            // foreach(Transform b in bars)
            // {
            //     if (b.name == "Bars" || b.name == "Bar6")
            //     {
            //         continue;
            //     }
            //     else
            //     {
            //         b.gameObject.SetActive(false);
            //     }
            // }
        }
        // If color is off, turn color on
        else if (!ColorOn)
        {
            ColorOn = true;
            GameObject.Find("Background").GetComponent<AudioSyncColor>().enabled = true;
            // Transform[] bars = GameObject.Find("Bars").GetComponentsInChildren<Transform>(true);
            // foreach(Transform b in bars)
            // {
            //     b.gameObject.SetActive(true);
            // }
        }
    }

    public void ClickParticleButton()
    {

    }
}
