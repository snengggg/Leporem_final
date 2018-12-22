using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using System.IO;

namespace LeporemDetectLandmark
{
public class SkintoneResult : MonoBehaviour
{

	private LeporemDetectLandmark.Checking_Skin_Tone w;

	//private LeporemDetectLandmark.DetectLandmark d;

	//public DetectLandmark abc = new DetectLandmark();
	public Text resultText;

	// Use this for initialization
	void Start () {
		//resultText= GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>();
		
		w = GameObject.FindObjectOfType<LeporemDetectLandmark.Checking_Skin_Tone>();
		//resultText.text = "당신의 피부톤 측정 결과는:" + w.skinTone + "톤 입니다";
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void onSkinToneCheckButtonClick()
		{
			w.btnPressed = true;
            
		}
    public void onRecheckButtonClick(){
            
			w.webCamTexture.Play();
			w.btnPressed = false;
        }

		//결과 Scene으로 이동
		public void OnResultButtonClick()
		{
			Debug.Log("Resultaf:"+w.skinTone);
            //resultText.text = "당신의 피부톤 측정 결과는 " + w.skinTone + "톤 입니다";
			resultText.text = "당신의 피부톤 측정 결과는 웜톤 입니다";

		}

		

	
}
	
}
