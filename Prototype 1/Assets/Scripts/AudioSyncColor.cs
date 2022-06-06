using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSyncColor : AudioSyncer
{
	public Color[] BeatColors;
	public Color RestColor;

	private int M_RandomIndex;
	private SpriteRenderer M_Sprite;
    
    private void Start()
	{
		M_Sprite = GetComponent<SpriteRenderer>();
	}
    
    private IEnumerator MoveToColor(Color Target)
	{
		Color Current = M_Sprite.color;
		Color Initial = Current;
		float Timer = 0;
		
		while (Current != Target)
		{
			Current = Color.Lerp(Initial, Target, Timer / TimeToBeat);
			Timer += Time.deltaTime;

			M_Sprite.color = Current;

			yield return null;
		}

		M_IsBeat = false;
	}

	private Color RandomColor()
	{
		if (BeatColors == null || BeatColors.Length == 0)
        {
            return Color.white;
        }
		M_RandomIndex = Random.Range(0, BeatColors.Length);
		return BeatColors[M_RandomIndex];
	}

	public override void OnUpdate()
	{
		base.OnUpdate();

		if (M_IsBeat) return;

		M_Sprite.color = Color.Lerp(M_Sprite.color, RestColor, RestSmoothTime * Time.deltaTime);
	}

	public override void OnBeat()
	{
		base.OnBeat();

		Color _c = RandomColor();

		StopCoroutine("MoveToColor");
		StartCoroutine("MoveToColor", _c);
	}
}