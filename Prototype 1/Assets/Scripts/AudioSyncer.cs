using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour
{
    // child classes (separate buttons turning each effect on/off???)
        // change shape/size of bars
        // change color
        // particles floating around -> separate button to add particles, but the particles move on the beat
    
    public float Bias;              // Whenever a SpectrumValue goes above Bias, a beat is registered
    public float TimeStep;          // Two beats cannot happen together in less than TimeStep seconds
    public float TimeToBeat;        // How long it takes to get to the target scale
    public float RestSmoothTime;    // How long it takes to get to the rest scale (not seconds -> speed variable)

    private float M_PreviousAudioValue;
    private float M_AudioValue;
    private float M_Timer;

    protected bool M_IsBeat;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    public virtual void OnBeat()
    {
        Debug.Log("beat");
        M_Timer = 0;
        M_IsBeat = true;
    }

    public virtual void OnUpdate()
    {
        // Assign previous and current audio values from the M_AudioSpectrum array
        M_PreviousAudioValue = M_AudioValue;
        M_AudioValue = AudioSpectrum.SpectrumValue;

        // If M_AudioValue goes below the Bias
        if ( (M_PreviousAudioValue > Bias) && (M_AudioValue <= Bias) )
        {
            // If the TimeStep rule allows for a beat to be triggered
            if (M_Timer > TimeStep)
            {
                OnBeat();
            }
        }

        // If M_AudioValue goes above the Bias
        if ( (M_PreviousAudioValue <= Bias) && (M_AudioValue > Bias) )
        {
            // If the TimeStep rule allows for a beat to be triggered
            if (M_Timer > TimeStep)
            {
                OnBeat();
            }
        }

        M_Timer += Time.deltaTime;
    }
}
