using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_5_3 || UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif

public class Main_Handler : MonoBehaviour {

	// Use this for initialization

    //UI_Manager PanelCtrl = new UI_Manager();
    //FadeIn FI = new FadeIn();
    //FadeOut FO = new FadeOut();
    //int k = UI_Manager.panel_Num;
    //public UI_Manager panelCtrl;

    public GameObject bg_Panel;
	public GameObject howtoBtn;
    public GameObject tutorialBtn;
    public GameObject skintoneBtn;
    public GameObject recommendBtn;
    public GameObject contactusBtn;

    //public int panelNum = 0;
	void Start () {


     //   ShowPanel_bg_Panel();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    
     /* public float animTime = 1f;

    

	private Image fadeImage;

	private float FIstart = 1f;
	private float FIend = 0f;
    private float FOstart = 0f;
	private float FOend = 1f;
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

    public void StartFadeOutAnim()
	{
		if(isPlaying == true)
			return;

			StartCoroutine("PlayFadeOut");
	}

    IEnumerator PlayFadeIn()
	{
		isPlaying = true;

		Color color = fadeImage.color;
		time = 0f;
		color.a = Mathf.Lerp(FIstart, FIend, time);

		while(color.a > 0f)
		{
			time += Time.deltaTime / animTime * 8;

			color.a = Mathf.Lerp(FIstart, FIend, time);

			fadeImage.color = color;

			yield return null;
		}

		isPlaying = false;

	}

    IEnumerator PlayFadeOut()
	{
		isPlaying = true;

		Color color = fadeImage.color;
		time = 0f;
		color.a = Mathf.Lerp(FOstart, FOend, time);

		while(color.a < 1f)
		{
			time += Time.deltaTime / animTime * 2;

			color.a = Mathf.Lerp(FOstart, FOend, time);

			fadeImage.color = color;

			yield return null;
		}

		isPlaying = false;

	}

    public void ShowPanel_bg_Panel() { bg_Panel.SetActive(true); }

    public void DownPanel_bg_Panel() { bg_Panel.SetActive(false); }*/

    /* public void OnHowtoButtonClick ()
    {
        
		UI_Manager.panel_Num = 1;	
        #if UNITY_5_3 || UNITY_5_3_OR_NEWER
        SceneManager.LoadScene ("SampleScene");
        #else
        Application.LoadLevel ("SampleScene"); 
        #endif
    }
	public void OnTutorialButtonClick ()
    {
        UI_Manager.panel_Num = 2;
        StartFadeOutAnim();
		//new WaitForSeconds(1);	
        #if UNITY_5_3 || UNITY_5_3_OR_NEWER 
        SceneManager.LoadScene ("SampleScene");
        #else
        Application.LoadLevel ("SampleScene");
        #endif
    }
    
    
    public void OnSkinToneButtonClick ()
    {
		UI_Manager.panel_Num = 3;
       #if UNITY_5_3 || UNITY_5_3_OR_NEWER
        SceneManager.LoadScene ("SampleScene");            
        #else
        Application.LoadLevel ("SampleScene");
        #endif
    }
    public void OnTrendButtonClick ()
    {
		UI_Manager.panel_Num = 4;
       #if UNITY_5_3 || UNITY_5_3_OR_NEWER
        SceneManager.LoadScene ("SampleScene");     
        #else
        Application.LoadLevel ("SampleScene");
        #endif
    }

    public void OnContactButtonClick ()
    {
        UI_Manager.panel_Num = 5;
       #if UNITY_5_3 || UNITY_5_3_OR_NEWER
        SceneManager.LoadScene ("SampleScene");
        #else
        Application.LoadLevel ("SampleScene");
        #endif
    }*/

    public void OnHowtoButtonClick ()
    {
        
		UI_Manager.panel_Num = 1;	
        
    }
	public void OnTutorialButtonClick ()
    {
        UI_Manager.panel_Num = 2;
        
    }
    
    
    public void OnSkinToneButtonClick ()
    {
		UI_Manager.panel_Num = 3;
       #if UNITY_5_3 || UNITY_5_3_OR_NEWER
        SceneManager.LoadScene ("SampleScene");            
        #else
        Application.LoadLevel ("SampleScene");
        #endif
       
    }
    public void OnTrendButtonClick ()
    {
		UI_Manager.panel_Num = 4;
       
    }

    public void OnContactButtonClick ()
    {
        UI_Manager.panel_Num = 5;
       
    }

        
}
