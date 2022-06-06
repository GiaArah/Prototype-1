using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    public static float SpectrumValue {get; private set;}
    private float[] M_AudioSpectrum;

    // Start is called before the first frame update
    void Start()
    {
        M_AudioSpectrum = new float[128];
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(M_AudioSpectrum, 0, FFTWindow.Hamming);

        if (M_AudioSpectrum != null && M_AudioSpectrum.Length > 0)
        {
            SpectrumValue = M_AudioSpectrum[0] * 100;
        }
    }
}
