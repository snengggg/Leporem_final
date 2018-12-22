using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 #if UNITY_5_3 || UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif

public class UI_Manager : MonoBehaviour {

    //패널
    public GameObject Panel_Loading;
    public GameObject Panel_Login;

    public GameObject Panel_newMember;
    
    public GameObject Panel_Main;

    public GameObject panel_Howto;
    public GameObject Panel_TutorialStart;
    public GameObject Panel_TutorialProcess;
    public GameObject Panel_TutorialFinish;
    public GameObject Panel_SkinToneCheck;
    public GameObject Panel_SkinToneResult;
    public GameObject Panel_Recommend;

    public GameObject cosmetic_Popup;

    public GameObject Panel_wannaContact;

    public GameObject Panel_wannaContactResult;

    public GameObject Panel_Myaccount;

    public GameObject Panel_Myad;

    public GameObject Panel_cosmetic;
    public GameObject goDetecting;

    public GameObject goSkinToneCheck;

    public InputField loginEmail;
    public InputField loginPwd;
    public InputField signupEmail;
    public InputField signupPwd;
    public InputField signupPwd2;

    public InputField nickName;

    public InputField comName_InputField;
    public InputField productName_InputField;
    public InputField productDes_InputField;
    public InputField comNumber_InputField;
    public InputField celNumber_InputField;


    

    private static bool loadingFlag = false;

    static public int panel_Num = 0;


    //Fade In and Out 변수
    public float animTime = 1f;

	private Image fadeImage;

	private float FIstart = 1f;
	private float FIend = 0f;
    private float FOstart = 0f;
	private float FOend = 1f;
	private float time = 0f;

	static public bool isPlaying = false;
    


    /*//나중에 씬 나누게 되면 필요
    #region //싱글톤 인스턴스
    private static UI_Manager _instance;

    public static UI_Manager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<UI_Manager>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    //-------------------------------------------------------------------

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        // else
        // {
        //     if(this != _instance)   
        //         Destroy(this.gameObject);
        // }
    }
    #endregion
    */
    void Start()
    {
        isPlaying = false;
        //Debug.Log(loadingFlag);
        Debug.Log("isplaying" + isPlaying);
        Debug.Log(panel_Num);

        if(panel_Num == 1)
        {
            ShowPanel_Howto();
            StartFadeInAnim();
            
        }
        else if(panel_Num == 2)
        {
            ShowPanel_TutorialStart();
            StartFadeInAnim();
            on_Detecting();

        }
        else if(panel_Num == 3)
        {
            on_SkinToneCheck();
            ShowPanel_SkinToneCheck();
            StartFadeInAnim();
        }
        else if(panel_Num == 4)
        {
            
            ShowPanel_Recommend();
            StartFadeInAnim();
        }
        else if(panel_Num == 5)
        {
            
            ShowPanel_wannaContact();
            StartFadeInAnim();
            

        }
        else{
            if(loadingFlag == false){}
                StartFadeInandOutAnim();
            }
        
        //new WaitForSeconds(2);
        //StartFadeOutAnim();
        //ShowPanel_Loading();
        //yield return new WaitForSeconds(2);
        //DownPanel_Loading();
        //ShowPanel_Login();
    }
    
    


        //Fade In and Out Controller
    void Awake()
	{
		fadeImage = GetComponent<Image>();
	}

    public void StartFadeInandOutAnim()
	{
        loadingFlag = true;
		if(isPlaying == true)
			return;

			StartCoroutine("PlayFadeInandOut");
            ShowPanel_Loading();
	}

    /* public void StartFadeOutAnim()
	{
		if(isPlaying == true)
			return;

			StartCoroutine("PlayFadeOut");
    }*/
    IEnumerator WaitAmoment(){
        yield return new WaitForSeconds(1);
    }

    IEnumerator PlayFadeInandOut()
	{
		isPlaying = true;

		Color color = fadeImage.color;
		time = 0f;
		color.a = Mathf.Lerp(FIstart, FIend, time);

		while(color.a > 0f)
		{
			time += Time.deltaTime / animTime * 2;

			color.a = Mathf.Lerp(FIstart, FIend, time);

			fadeImage.color = color;

			yield return null;
		}

        yield return new WaitForSeconds(1);
        

        isPlaying = true;

		color = fadeImage.color;
		time = 0f;
		
		color.a = Mathf.Lerp(FOstart, FOend, time);

        while(color.a < 1f)
		{
			time += Time.deltaTime / animTime * 2;

			color.a = Mathf.Lerp(FOstart, FOend, time);

			fadeImage.color = color;

			yield return null;
		}
        DownPanel_Loading();
        ShowPanel_Login();
        isPlaying = false;
        StartFadeInAnim();

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
			time += Time.deltaTime / animTime * 4;

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
			time += Time.deltaTime / animTime * 8;

			color.a = Mathf.Lerp(FOstart, FOend, time);

			fadeImage.color = color;

			yield return null;
		}

		isPlaying = false;

	}

    
    public void ShowPanel_Loading() { Panel_Loading.SetActive(true); }
    public void ShowPanel_Login() { Panel_Login.SetActive(true); }
    
    public void ShowPanel_newMember() { Panel_newMember.SetActive(true); }
    
    public void ShowPanel_Main() { Panel_Main.SetActive(true); }
    public void ShowPanel_TutorialStart() { Panel_TutorialStart.SetActive(true); }
    public void ShowPanel_TutorialProcess() { Panel_TutorialProcess.SetActive(true); }
    public void ShowPanel_TutorialFinish() { Panel_TutorialFinish.SetActive(true); }
    public void ShowPanel_SkinToneCheck() { Panel_SkinToneCheck.SetActive(true); }
    public void ShowPanel_SkinToneResult() { Panel_SkinToneResult.SetActive(true); }
    public void ShowPanel_Recommend() { Panel_Recommend.SetActive(true); }

    public void ShowPanel_wannaContact() { Panel_wannaContact.SetActive(true); }
    public void ShowPanel_wannaContactResult() { Panel_wannaContactResult.SetActive(true); }

    public void ShowPanel_Howto() { panel_Howto.SetActive(true); }

    public void ShowPanel_Cosmetic() { Panel_cosmetic.SetActive(true); }


    public void ShowPanel_Myaccount() { Panel_Myaccount.SetActive(true); }

    public void ShowPanel_Myad() { Panel_Myad.SetActive(true); }    

    public void DownPanel_Loading() { Panel_Loading.SetActive(false); }
    public void DownPanel_Login() { Panel_Login.SetActive(false); }
    
    public void DownPanel_newMember() { Panel_newMember.SetActive(false); }
    
    public void DownPanel_Main() { Panel_Main.SetActive(false); }
    public void DownPanel_TutorialStart() { Panel_TutorialStart.SetActive(false); }
    public void DownPanel_TutorialProcess() { Panel_TutorialProcess.SetActive(false); }
    public void DownPanel_TutorialFinish() { Panel_TutorialFinish.SetActive(false); }
    public void DownPanel_SkinToneCheck() { Panel_SkinToneCheck.SetActive(false); }
    public void DownPanel_SkinToneResult() { Panel_SkinToneResult.SetActive(false); }
    public void DownPanel_Recommend() { Panel_Recommend.SetActive(false); }

    public void DownPanel_wannaContact() { Panel_wannaContact.SetActive(false); }
    public void DownPanel_wannaContactResult() { Panel_wannaContactResult.SetActive(false); }

    public void DownPanel_Howto() { panel_Howto.SetActive(false); }

    public void DownPanel_Myaccount() { Panel_Myaccount.SetActive(false); }

    public void DownPanel_Cosmetic() { Panel_cosmetic.SetActive(false); }

    public void DownPanel_Myad() { Panel_Myad.SetActive(false); }    

    public void DownPanel_Popup() { cosmetic_Popup.SetActive(false); }    

    //Detectin setActive

    public void on_Detecting() { goDetecting.SetActive(true); }
    public void off_Detecting() { goDetecting.SetActive(false); }
    

    
    public void on_SkinToneCheck() { goSkinToneCheck.SetActive(true); }
    public void off_SkinToneCheck() { goSkinToneCheck.SetActive(false); }

    public void wait(){
        StartCoroutine(WaitAmoment());
    }
    
    public void gotoMainMenu ()
        {
            off_SkinToneCheck();
            off_Detecting();
            /* DownPanel_Loading();
            ShowPanel_Main();*/

            #if UNITY_5_3 || UNITY_5_3_OR_NEWER
            SceneManager.LoadScene ("MainMenu");
            
            #else
            Application.LoadLevel ("MainMenu");
            
            #endif
        }


    public int MenOrWomen;

    private static bool isnotMWbuttontouchFirst = false;
    public Image MenbuttonImage;
    public Image WomenbuttonImage;

    public Text Mentext;
    public Text Womentext;
    //private Color MenbuttonColor;
    //private Color WoMenbuttonColor;
    public void onMenButtonClick(){

        MenOrWomen = 1;
        //Debug.Log(isnotMWbuttontouchFirst);
        StartButtonToggle();
        
    }

    public void onwoMenButtonClick(){
        
        MenOrWomen = 2;
        Debug.Log(isnotMWbuttontouchFirst);
        StartButtonToggle();
    }

    public void StartButtonToggle()
	{
		if(isPlaying == true)
			return;

			StartCoroutine("ButtonToggle");

	}

     IEnumerator ButtonToggle()
	{
        FIstart = 1f;
	    FIend = 0.5f;
        FOstart = 0.5f;
	    FOend = 1f;

        Debug.Log(isnotMWbuttontouchFirst);
        isPlaying = true;
        
        //MenbuttonColor = MenbuttonImage.color;
        //WoMenbuttonColor = WomenbuttonImage.color;
        Color toggleColor;
        //Image toggleImage;
        
        if(isnotMWbuttontouchFirst){
            
            if(MenOrWomen == 1){
                time = 0f;
                toggleColor = WomenbuttonImage.color;

                while(toggleColor.a > 0.5f)
		    {
			time += Time.deltaTime / animTime * 16;

			toggleColor.a = Mathf.Lerp(FIstart, FIend, time);
            
            WomenbuttonImage.color = toggleColor;
            Womentext.color = toggleColor;
            
			yield return null;
		    }
            time = 0f;
            toggleColor = MenbuttonImage.color;

                while(toggleColor.a < 1f)
		    {
			time += Time.deltaTime / animTime * 16;

			toggleColor.a = Mathf.Lerp(FOstart, FOend, time);

			MenbuttonImage.color = toggleColor;
            Mentext.color = toggleColor;

			yield return null;
		    }
            }else{
                time = 0f;
                toggleColor = MenbuttonImage.color;

                while(toggleColor.a > 0.5f)
		    {
			time += Time.deltaTime / animTime * 16;

			toggleColor.a = Mathf.Lerp(FIstart, FIend, time);
            
            MenbuttonImage.color = toggleColor;
            Mentext.color = toggleColor;
            
			yield return null;
		    }
            time = 0f;
            toggleColor = WomenbuttonImage.color;

                while(toggleColor.a < 1f)
		    {
			time += Time.deltaTime / animTime * 16;

			toggleColor.a = Mathf.Lerp(FOstart, FOend, time);

			WomenbuttonImage.color = toggleColor;
            Womentext.color = toggleColor;

			yield return null;
		    }

            }




        }else{

            if(MenOrWomen == 1){

                time = 0f;
                toggleColor = MenbuttonImage.color;

                while(toggleColor.a < 1f)
		    {
			time += Time.deltaTime / animTime * 16;

			toggleColor.a = Mathf.Lerp(FOstart, FOend, time);

			MenbuttonImage.color = toggleColor;
            Mentext.color = toggleColor;

			yield return null;
		    }

            }else{
                time = 0f;
                toggleColor = WomenbuttonImage.color;
                while(toggleColor.a < 1f)
		    {
			time += Time.deltaTime / animTime * 16;

			toggleColor.a = Mathf.Lerp(FOstart, FOend, time);

			WomenbuttonImage.color = toggleColor;
            Womentext.color = toggleColor;

			yield return null;
		    }
            }
            isnotMWbuttontouchFirst = true;
        }
        isPlaying = false;
        
        FIstart = 1f;
	    FIend = 0f;
        FOstart = 0f;
	    FOend = 1f;
        }

        public Image desbackground;

        public Image questionMark;
        public Image rightBtn1;
        public Image rightBtn2;
        public Image rightBtn3;
        public Image leftBtn1;
        public Image leftBtn2;
        public Image leftBtn3;

        public Image closedesButton;        

        public Text infoText1;
        public Text infoText2;
        public Text infoText3;
        public Text infoText4;

       

        public bool isdesOn = true;

        public void onCloseDesButtonClick(){

            Debug.Log("isplaying" + " " + isPlaying);
            Debug.Log("isdeson" + " " + isdesOn);
            isdesOn = true;
            StartdesFade();

        }

        public void onquestionMarkButtonClick(){

            isdesOn = false;
            StartdesFade();
            
        }
        public void StartdesFade()
	{
		if(isPlaying == true)
			return;

        Debug.Log(isPlaying);
        Debug.Log(isdesOn);
			StartCoroutine("desFadeinandout");

	}

        IEnumerator desFadeinandout()
	{
        FIstart = 1f;
	    FIend = 0f;
        FOstart = 0f;
	    FOend = 1f;

        Debug.Log(isnotMWbuttontouchFirst);
        isPlaying = true;
        
        //MenbuttonColor = MenbuttonImage.color;
        //WoMenbuttonColor = WomenbuttonImage.color;
        Color whiteColor;
        Color blackColor;
        Color questionMarkColor;
        //Image toggleImage;

        if(isdesOn){
            
            questionMarkColor = questionMark.color;
            questionMarkColor.a = 1f;
            questionMark.color = questionMarkColor;

            time = 0f;
            whiteColor = desbackground.color;
            blackColor = closedesButton.color;


            while(blackColor.a > 0f)
            {
                time += Time.deltaTime / animTime * 16;

			    blackColor.a = Mathf.Lerp(FIstart, FIend, time);
            
                rightBtn1.color = blackColor;
                rightBtn2.color = blackColor;
                rightBtn3.color = blackColor;
                leftBtn1.color = blackColor;
                leftBtn2.color = blackColor;
                leftBtn3.color = blackColor;
                closedesButton.color = blackColor;
                infoText1.color = blackColor;
                infoText2.color = blackColor;
                infoText3.color = blackColor;
                infoText4.color = blackColor;
            
			    yield return null;
            }
            
            while(whiteColor.a > 0f)
            {
                time += Time.deltaTime / animTime * 16;

			    whiteColor.a = Mathf.Lerp(FIstart, FIend, time);
            
                desbackground.color = whiteColor;
            
			yield return null;
            }

            
            isdesOn = false;
        }else{
            
            
            time = 0f;
            whiteColor = desbackground.color;
            blackColor = closedesButton.color;

            while(whiteColor.a < 1f)
            {
                time += Time.deltaTime / animTime * 16;

			    whiteColor.a = Mathf.Lerp(FOstart, FOend, time);
            
                desbackground.color = whiteColor;
            
			yield return null;
            }

            while(blackColor.a < 1f)
            {
                time += Time.deltaTime / animTime * 16;

			    blackColor.a = Mathf.Lerp(FOstart, FOend, time);
            
                rightBtn1.color = blackColor;
                rightBtn2.color = blackColor;
                rightBtn3.color = blackColor;
                leftBtn1.color = blackColor;
                leftBtn2.color = blackColor;
                leftBtn3.color = blackColor;
                closedesButton.color = blackColor;
                infoText1.color = blackColor;
                infoText2.color = blackColor;
                infoText3.color = blackColor;
                infoText4.color = blackColor;
            
			    yield return null;
            }
            questionMarkColor = questionMark.color;
            questionMarkColor.a = 0f;
            questionMark.color = questionMarkColor;
            isdesOn = true;
        }
        
        isPlaying = false;

        }
        
		

    public int beforeUPDOWNSTEP = 3;
    public int UPDOWNSTEP = 3;

    private static bool isnotQuadChoicebuttontouchFirst = false;
    public Image UpbuttonImage;
    public Image DownbuttonImage;

    public Image StepbuttonImage;

    public Text Uptext;
    public Text Downtext;

    public Text Steptext;
    //private Color MenbuttonColor;
    //private Color WoMenbuttonColor;
    public void onUpButtonClick(){

        beforeUPDOWNSTEP = UPDOWNSTEP;
        UPDOWNSTEP = 1;
        
        //Debug.Log(isnotMWbuttontouchFirst);
        StartUPDOWNSTEPToggle();
        
    }

    public void onDownButtonClick(){

        beforeUPDOWNSTEP = UPDOWNSTEP;
        UPDOWNSTEP = 2;
        
        //Debug.Log(isnotMWbuttontouchFirst);
        StartUPDOWNSTEPToggle();
        
    }

    public void onStepButtonClick(){

        beforeUPDOWNSTEP = UPDOWNSTEP;
        UPDOWNSTEP = 3;
        
        //Debug.Log(isnotMWbuttontouchFirst);
        StartUPDOWNSTEPToggle();
        
    }
    
    


    public void StartUPDOWNSTEPToggle()
	{
		if(isPlaying == true)
			return;

			StartCoroutine("ButtonUPDOWNSTEPToggle");

	}

     IEnumerator ButtonUPDOWNSTEPToggle()
	{
        FIstart = 1f;
	    FIend = 0.5f;
        FOstart = 0.5f;
	    FOend = 1f;

        Debug.Log(isnotMWbuttontouchFirst);
        isPlaying = true;
        
        //MenbuttonColor = MenbuttonImage.color;
        //WoMenbuttonColor = WomenbuttonImage.color;
        Color toggleColor;
        //Image toggleImage;
            
            if(UPDOWNSTEP == 1){
                
            time = 0f;
            toggleColor = UpbuttonImage.color;

                while(toggleColor.a < 1f)
		    {
			    time += Time.deltaTime / animTime * 16;

			    toggleColor.a = Mathf.Lerp(FOstart, FOend, time);

			    UpbuttonImage.color = toggleColor;
                Uptext.color = toggleColor;

                yield return null;
		    }

            if(beforeUPDOWNSTEP == 2){

                time = 0f;
                toggleColor = DownbuttonImage.color;

                while(toggleColor.a > 0.5f)
		        {
			    time += Time.deltaTime / animTime * 16;

			    toggleColor.a = Mathf.Lerp(FIstart, FIend, time);
            
                DownbuttonImage.color = toggleColor;
                Downtext.color = toggleColor;
            
			    yield return null;
		    }
            }else if (beforeUPDOWNSTEP == 3){

                
                time = 0f;
                toggleColor = StepbuttonImage.color;

                while(toggleColor.a > 0.5f)
		        {
			    time += Time.deltaTime / animTime * 16;

			    toggleColor.a = Mathf.Lerp(FIstart, FIend, time);
            
                StepbuttonImage.color = toggleColor;
                Steptext.color = toggleColor;
            
			    yield return null;
		    }

            }else{}


            }else if(UPDOWNSTEP == 2){
                
            time = 0f;
            toggleColor = DownbuttonImage.color;

                while(toggleColor.a < 1f)
		    {
			    time += Time.deltaTime / animTime * 16;

			    toggleColor.a = Mathf.Lerp(FOstart, FOend, time);

			    DownbuttonImage.color = toggleColor;
                Downtext.color = toggleColor;

                yield return null;
		    }

            if(beforeUPDOWNSTEP == 1){

                time = 0f;
                toggleColor = UpbuttonImage.color;

                while(toggleColor.a > 0.5f)
		        {
			    time += Time.deltaTime / animTime * 16;

			    toggleColor.a = Mathf.Lerp(FIstart, FIend, time);
            
                UpbuttonImage.color = toggleColor;
                Uptext.color = toggleColor;
            
			    yield return null;
		    }
            }else if (beforeUPDOWNSTEP == 3){

                
                time = 0f;
                toggleColor = StepbuttonImage.color;

                while(toggleColor.a > 0.5f)
		        {
			    time += Time.deltaTime / animTime * 16;

			    toggleColor.a = Mathf.Lerp(FIstart, FIend, time);
            
                StepbuttonImage.color = toggleColor;
                Steptext.color = toggleColor;
            
			    yield return null;
		    }

            }else{}


            }else{
                
            time = 0f;
            toggleColor = StepbuttonImage.color;

                while(toggleColor.a < 1f)
		    {
			    time += Time.deltaTime / animTime * 16;

			    toggleColor.a = Mathf.Lerp(FOstart, FOend, time);

			    StepbuttonImage.color = toggleColor;
                Steptext.color = toggleColor;

                yield return null;
		    }

            if(beforeUPDOWNSTEP == 1){

                time = 0f;
                toggleColor = UpbuttonImage.color;

                while(toggleColor.a > 0.5f)
		        {
			    time += Time.deltaTime / animTime * 16;

			    toggleColor.a = Mathf.Lerp(FIstart, FIend, time);
            
                UpbuttonImage.color = toggleColor;
                Uptext.color = toggleColor;
            
			    yield return null;
		    }
            }else if (beforeUPDOWNSTEP == 2){

                
                time = 0f;
                toggleColor = DownbuttonImage.color;

                while(toggleColor.a > 0.5f)
		        {
			    time += Time.deltaTime / animTime * 16;

			    toggleColor.a = Mathf.Lerp(FIstart, FIend, time);
            
                DownbuttonImage.color = toggleColor;
                Downtext.color = toggleColor;
            
			    yield return null;
		    }

            }else{}


            }




        
        
        

            /* if(MenOrWomen == 1){

                time = 0f;
                toggleColor = MenbuttonImage.color;

                while(toggleColor.a < 1f)
		    {
			time += Time.deltaTime / animTime * 16;

			toggleColor.a = Mathf.Lerp(FOstart, FOend, time);

			MenbuttonImage.color = toggleColor;
            Mentext.color = toggleColor;

			yield return null;
		    }

            }else{
                time = 0f;
                toggleColor = WomenbuttonImage.color;
                while(toggleColor.a < 1f)
		    {
			time += Time.deltaTime / animTime * 16;

			toggleColor.a = Mathf.Lerp(FOstart, FOend, time);

			WomenbuttonImage.color = toggleColor;
            Womentext.color = toggleColor;

			yield return null;
		    }
            }
            isnotMWbuttontouchFirst = true;*/
        
        isPlaying = false;
        
        FIstart = 1f;
	    FIend = 0f;
        FOstart = 0f;
	    FOend = 1f;
        }






	




}