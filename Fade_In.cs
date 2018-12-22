using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fade_In : MonoBehaviour {

	public float animTime = 2f;

	private Image fadeImage;

	private float FIstart = 1f;
	private float FIend = 0f;
	private float time = 0f;

	private bool isPlaying = false;
	
	

	void Awake()
	{
		fadeImage = GetComponent<Image>();
	}

	public void StartFadeInAnim()
	{
		if(isPlaying == true)
			return;

			StartCoroutine("PlayFadeIn");
	}

	IEnumerator PlayFadeIn()
	{
		isPlaying = true;

		Color color = fadeImage.color;
		time = 0f;
		color.a = Mathf.Lerp(FIstart, FIend, time);

		while(color.a > 0f)
		{
			time += Time.deltaTime / animTime * 4;

			color.a = Mathf.Lerp(FIstart, FIend, time);

			fadeImage.color = color;

			yield return null;
		}

		isPlaying = false;

	}

	

}

