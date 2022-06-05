using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncScale : AudioSyncer
{
    public Vector3 BeatScale;
    public Vector3 RestScale;

    private IEnumerator MoveToScale(Vector3 Target)
    {
        Vector3 Current = transform.localScale;
        Vector3 Initial = Current;
        float Timer = 0f;
        
        // While the current scale is not equal to the target scale, lerp towards the target scale
        while (Current != Target)
        {
            Current = Vector3.Lerp(Initial, Target, Timer / TimeToBeat);
            Timer += Time.deltaTime;

            transform.localScale = Current;
            
            yield return null;
        }

        // Lerp towards the rest scale
        M_IsBeat = false;
    }
    
    public override void OnUpdate()
    {
        base.OnUpdate();

        // If in a beat state, the scale is currently being manipulatd by the beat
        // If not in a beat state, lerp (linear interpolation) the scale toward the rest scale
        if (!M_IsBeat)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, RestScale, RestSmoothTime * Time.deltaTime);
        }
    }

    public override void OnBeat()
    {
        base.OnBeat();

        // Spawn a coroutine to go to the BeatScale
        StopCoroutine("MoveToScale");
        StartCoroutine("MoveToScale", BeatScale);
    }
}
