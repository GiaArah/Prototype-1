using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    public bool BarOn, ColorOn, ParticleOn;
    
    // Start is called before the first frame update
    void Start()
    {
        BarOn = true;
        ColorOn = true;
        ParticleOn = true;
    }
    
    public void ClickBarButton()
    {
        Debug.Log ("Button Clicked");
        // If multiple bars are visible, make only one bar visible
        if (BarOn)
        {
            Debug.Log ("Bars Off");
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
            Debug.Log ("Bars On");
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

    }

    public void ClickParticleButton()
    {

    }
}
