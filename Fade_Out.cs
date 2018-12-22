using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fade_Out : MonoBehaviour {

	public float animTime = 2f;

	private Image fadeImage;

	private float FOstart = 0f;
	private float FOend = 1f;
	private float time = 0f;

	private bool isPlaying = false;

	void Awake()
	{
		fadeImage = GetComponent<Image>();
	}

	public void StartFadeOutAnim()
	{
		if(isPlaying == true)
			return;

			StartCoroutine("PlayFadeOut");
	}

	IEnumerator PlayFadeOut()
	{
		isPlaying = true;

		Color color = fadeImage.color;
		time = 0f;
		color.a = Mathf.Lerp(FOstart, FOend, time);

		while(color.a < 1f)
		{
			time += Time.deltaTime / animTime * 4;

			color.a = Mathf.Lerp(FOstart, FOend, time);

			fadeImage.color = color;

			yield return null;
		}

		isPlaying = false;

	}

}
