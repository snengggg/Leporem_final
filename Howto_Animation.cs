using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Howto_Animation : MonoBehaviour {


	public Image EyebrowBG;

	public Image EyeBG;

	public Image SkinBG;

	public Image LibBG;

	public GameObject EyebrowQButton;

	public GameObject EyeQButton;

	public GameObject SkinQButton;

	public GameObject LibQButton;

	public GameObject Backbutton;

	public GameObject Eyebrow_1step;

	public GameObject Eye_1step;

	public GameObject Skin_1step;

	public GameObject Lip_1step;

	public GameObject Eye_2step;


	public GameObject Eye_2step_1;

	public GameObject Eye_2step_2;

	public GameObject Eye_2step_3;

	public GameObject Eye_2step_4;

	public GameObject Eye_2step_5;


	public GameObject Skin_2step;


	public GameObject Skin_2step_1;

	public GameObject Skin_2step_2;

	public GameObject Skin_2step_3;

	public GameObject Skin_2step_4;
	

	private bool isPlaying = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private int currentImage = 0;

	private int currentEye2stepNum = 0;

	private int currentSkin2stepNum = 0;

	public void OnEyebrowQuestionButtonClick(){
		DownAllQmark();
		currentImage = 1;

		StartCoroutine("BgToggleUp");

	}

	public void OnEyeQuestionButtonClick(){
		DownAllQmark();
		currentImage = 2;
		StartCoroutine("BgToggleUp");
		
	}

	public void OnSkinQuestionButtonClick(){
		DownAllQmark();
		currentImage = 3;
		StartCoroutine("BgToggleUp");
	}

	public void OnLibQuestionButtonClick(){
		DownAllQmark();
		currentImage = 4;
		StartCoroutine("BgToggleUp");
	}

	public float animTime = 1f;
	private float FIstart = 0f;
	    private float FIend = 0.5f;
        private float FOstart = 0.5f;
	    private float FOend = 0f;

		private float time = 0f;

		public void ShowBack(){

			Backbutton.SetActive(true);

		}

		public void DownBack(){
			Backbutton.SetActive(false);
		}


		public void ShowAllQmark(){
			EyebrowQButton.SetActive(true);
			EyeQButton.SetActive(true);
			SkinQButton.SetActive(true);
			LibQButton.SetActive(true);
		}
		public void DownAllQmark(){
			EyebrowQButton.SetActive(false);
			EyeQButton.SetActive(false);
			SkinQButton.SetActive(false);
			LibQButton.SetActive(false);
		}

		public void Show_Eyebrow_1step(){
			Eyebrow_1step.SetActive(true);

		}
		public void Show_Eye_1step(){
			Eye_1step.SetActive(true);
		}
		public void Show_Skin_1step(){
			Skin_1step.SetActive(true);
		}
		public void Show_Lip_1step(){
			Lip_1step.SetActive(true);
		}

		public void Show_Eye_2step(){
			Eye_2step.SetActive(true);
		}

		public void Show_Eye_2Step_1(){
			Eye_2step_1.SetActive(true);
		}
		public void Show_Eye_2Step_2(){
			Eye_2step_2.SetActive(true);
		}
		public void Show_Eye_2Step_3(){
			Eye_2step_3.SetActive(true);
		}
		public void Show_Eye_2Step_4(){
			Eye_2step_4.SetActive(true);
		}
		public void Show_Eye_2Step_5(){
			Eye_2step_5.SetActive(true);
		}

		public void Down_Eyebrow_1step(){
			Eyebrow_1step.SetActive(false);

		}
		public void Down_Eye_1step(){
			Eye_1step.SetActive(false);
		}
		public void Down_Skin_1step(){
			Skin_1step.SetActive(false);
		}
		public void Down_Lip_1step(){
			Lip_1step.SetActive(false);
		}
		
		public void Down_Eye_2step(){
			Eye_2step.SetActive(false);
		}
		public void Down_Eye_2Step_1(){
			Eye_2step_1.SetActive(false);
		}
		public void Down_Eye_2Step_2(){
			Eye_2step_2.SetActive(false);
		}
		public void Down_Eye_2Step_3(){
			Eye_2step_3.SetActive(false);
		}
		public void Down_Eye_2Step_4(){
			Eye_2step_4.SetActive(false);
		}
		public void Down_Eye_2Step_5(){
			Eye_2step_5.SetActive(false);
		}



		public void Show_Skin_2step(){
			Skin_2step.SetActive(true);	
		}
		public void Show_Skin_2step_1(){
			Skin_2step_1.SetActive(true);	
		}
		public void Show_Skin_2step_2(){
			Skin_2step_2.SetActive(true);	
		}
		public void Show_Skin_2step_3(){
			Skin_2step_3.SetActive(true);	
		}
		public void Show_Skin_2step_4(){
			Skin_2step_4.SetActive(true);	
		}

		public void Down_Skin_2step(){
			Skin_2step.SetActive(false);	
		}
		public void Down_Skin_2step_1(){
			Skin_2step_1.SetActive(false);	
		}
		public void Down_Skin_2step_2(){
			Skin_2step_2.SetActive(false);	
		}
		public void Down_Skin_2step_3(){
			Skin_2step_3.SetActive(false);	
		}
		public void Down_Skin_2step_4(){
			Skin_2step_4.SetActive(false);	
		}

		public GameObject Base_table;


		public void Show_basetable(){
			Base_table.SetActive(true);
		}

		public void Down_basetable(){
			Base_table.SetActive(false);
		}


		public void show_All_1step_panel(){
			Show_Eyebrow_1step();
			Show_Eye_1step();
			Show_Skin_1step();
			Show_Lip_1step();

		}
		public void down_All_1step_panel(){
			Down_Eyebrow_1step();
			Down_Eye_1step();
			Down_Skin_1step();
			Down_Lip_1step();
			
		}

		public void OnEye2step_1_ButtonClick(){
			currentEye2stepNum = 1;
			Show_Eye_2step_panel();
		}
		public void OnEye2step_2_ButtonClick(){
			currentEye2stepNum = 2;
			Show_Eye_2step_panel();

		}
		public void OnEye2step_3_ButtonClick(){
			currentEye2stepNum = 3;
			Show_Eye_2step_panel();

		}
		public void OnEye2step_4_ButtonClick(){
			currentEye2stepNum = 4;
			Show_Eye_2step_panel();

		}
		public void OnEye2step_5_ButtonClick(){
			currentEye2stepNum = 5;
			Show_Eye_2step_panel();

		}

		public void Show_Eye_2step_panel(){
			if(currentEye2stepNum == 1){
				Show_Eye_2Step_1();
			}else if(currentEye2stepNum == 2){
				Show_Eye_2Step_2();
			}else if(currentEye2stepNum == 3){
				Show_Eye_2Step_3();
			}else if(currentEye2stepNum == 4){
				Show_Eye_2Step_4();
			}else {
				Show_Eye_2Step_5();
			}

		}

		public void Step_2_BackbuttonClick(){
			if(currentEye2stepNum == 1){
				Down_Eye_2Step_1();
			}else if(currentEye2stepNum == 2){
				Down_Eye_2Step_2();
			}else if(currentEye2stepNum == 3){
				Down_Eye_2Step_3();
			}else if(currentEye2stepNum == 4){
				Down_Eye_2Step_4();
			}else {
				Down_Eye_2Step_5();
			}
			currentEye2stepNum = 0;
		}

		public void OnSkin2step_1_ButtonClick(){
			currentSkin2stepNum = 1;
			Show_Skin_2step_panel();
		}
		public void OnSkin2step_2_ButtonClick(){
			currentEye2stepNum = 2;
			Show_Skin_2step_panel();

		}
		public void OnSkin2step_3_ButtonClick(){
			currentEye2stepNum = 3;
			Show_Skin_2step_panel();

		}
		public void OnSkin2step_4_ButtonClick(){
			currentEye2stepNum = 4;
			Show_Skin_2step_panel();

		}
		

		public void Show_Skin_2step_panel(){
			if(currentEye2stepNum == 1){
				Show_Skin_2step_1();
			}else if(currentEye2stepNum == 2){
				Show_Skin_2step_2();
			}else if(currentEye2stepNum == 3){
				Show_Skin_2step_3();
			}else{
				Show_Skin_2step_4();
			}

		}

		public void Skin_Step_2_BackbuttonClick(){
			if(currentSkin2stepNum == 1){
				Down_Skin_2step_1();
			}else if(currentEye2stepNum == 2){
				Down_Skin_2step_2();
			}else if(currentEye2stepNum == 3){
				Down_Skin_2step_3();
			}else {
				Down_Skin_2step_4();
			}
			currentSkin2stepNum = 0;
		}


		




		public void Show_1step_panel(){
			if(currentImage == 1){
				Show_Eyebrow_1step();

			}else if(currentImage == 2){

				Show_Eye_1step();

			}else if(currentImage == 3){

				Show_Skin_1step();
				
			}else{
				Show_Lip_1step();
			}
		}

	 IEnumerator BgToggleUp()
	{
        

        isPlaying = true;
        
        
        Color BGColor;

		
            
            if(currentImage == 1){
                time = 0f;
                BGColor = EyebrowBG.color;

                while(BGColor.a > 0f)
		    {
			time += Time.deltaTime / animTime * 4;

			BGColor.a = Mathf.Lerp(FOstart, FOend, time);
            
            EyebrowBG.color = BGColor;
            
			yield return null;
		    }
		}
		else if(currentImage == 2){
                time = 0f;
                BGColor = EyeBG.color;

                while(BGColor.a > 0f)
		    {
			time += Time.deltaTime / animTime * 4;

			BGColor.a = Mathf.Lerp(FOstart, FOend, time);
            
            EyeBG.color = BGColor;
            
			yield return null;
		    }
		}else if(currentImage == 3){
                time = 0f;
                BGColor = SkinBG.color;

                while(BGColor.a > 0f)
		    {
			time += Time.deltaTime / animTime * 4;

			BGColor.a = Mathf.Lerp(FOstart, FOend, time);
            
            SkinBG.color = BGColor;
            
			yield return null;
		    }
		}else {
                time = 0f;
                BGColor = LibBG.color;

                while(BGColor.a > 0f)
		    {
			time += Time.deltaTime / animTime * 4;

			BGColor.a = Mathf.Lerp(FOstart, FOend, time);
            
            LibBG.color = BGColor;
            
			yield return null;
		    }
		}

			
        isPlaying = false;
		ShowBack();
		Show_1step_panel();
        
	}

	public void OnReturnQuestionMenu(){

		DownBack();
		down_All_1step_panel();
		StartCoroutine("BgToggleDown");
	}

	IEnumerator BgToggleDown(){
		Color BGColor;

		isPlaying = true;
		
			if(currentImage == 1){
                time = 0f;
                BGColor = EyebrowBG.color;

                while(BGColor.a < 0.5f)
		    {
			time += Time.deltaTime / animTime * 4;

			BGColor.a = Mathf.Lerp(FIstart, FIend, time);
            
            EyebrowBG.color = BGColor;
            
			yield return null;
		    }
			}else if(currentImage == 2){
                time = 0f;
                BGColor = EyeBG.color;

                while(BGColor.a < 0.5f)
		    {
			time += Time.deltaTime / animTime * 4;

			BGColor.a = Mathf.Lerp(FIstart, FIend, time);
            
            EyeBG.color = BGColor;
            
			yield return null;
		    }
			}else if(currentImage == 3){
                time = 0f;
                BGColor = SkinBG.color;

                while(BGColor.a < 0.5f)
		    {
			time += Time.deltaTime / animTime * 4;

			BGColor.a = Mathf.Lerp(FIstart, FIend, time);
            
            SkinBG.color = BGColor;
            
			yield return null;
		    }
			}else
			{
                time = 0f;
                BGColor = LibBG.color;

                while(BGColor.a < 0.5f)
		    {
			time += Time.deltaTime / animTime * 4;

			BGColor.a = Mathf.Lerp(FIstart, FIend, time);
            
            LibBG.color = BGColor;
            
			yield return null;
		    }
			}

			isPlaying = false;
			ShowAllQmark();
			

	}

	public void onMyCurvedButtonClick(){
		Application.OpenURL("https://www.youtube.com/watch?v=6CfMUEESMBA");
	}










}
