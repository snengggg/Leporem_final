using UnityEngine;


public class Auth_Manager : MonoBehaviour {

	// Use this for initialization

	UI_Manager authUI;

	
	Firebase.Auth.FirebaseAuth auth;
	Firebase.Auth.FirebaseUser user;
    
    void Start () {

		authUI = GetComponent<UI_Manager> ();
		
		InitializeFirebase();
	}

	void onDestroy(){
		auth.StateChanged -= AuthStateChanged;
	}

	void InitializeFirebase () {
		auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
		auth.StateChanged += AuthStateChanged;
		AuthStateChanged (this, null);
	}

	void AuthStateChanged (object sender, System.EventArgs eventArgs) {
	    if (auth.CurrentUser != user) {
			bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
			if (!signedIn && user != null) {
				Debug.Log ("Signed out " + user.UserId);
			}


			user = auth.CurrentUser;
			if (signedIn) {
				Debug.Log ("Signed in " + user.UserId);
				//displayName = user.DisplayName ?? "";
				//emailAddress = user.Email ?? "";
				//photoUrl = user.PhotoUrl ?? "";
			}
		}
	}

	public void onLoginButtonClick () {
		TryLoginWithFirebaseAuth (authUI.loginEmail.text, authUI.loginPwd.text);
	}

	public void onCreateAccountButtonClick () {
		TrySignupWithFirebaseAuth (authUI.signupEmail.text, authUI.signupPwd.text, authUI.signupPwd2.text, authUI.nickName.text, authUI.MenOrWomen);
	}
	public void onSignOutButtonClick () {
		

	}

	private void TryLoginWithFirebaseAuth (string email, string password) {

		auth.SignInWithEmailAndPasswordAsync (email, password).ContinueWith (task => {
			if (task.IsCanceled) {
				Debug.LogError ("SignInWithEmailAndPasswordAsync was canceled.");
				// 로그인 오류 팝업
				
				return;
			}
			if (task.IsFaulted) {
				Debug.LogError ("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
				
				// 로그인 오류 팝업
				
				return;
			}

			Firebase.Auth.FirebaseUser newUser = task.Result;
			Debug.LogFormat ("User signed in successfully: {0} ({1})",
				newUser.DisplayName, newUser.UserId);

			GameObject.Find("P_Main_Finout").GetComponent<Fade_Out>().StartFadeOutAnim();
			GameObject.Find("Manager").GetComponent<UI_Manager>().DownPanel_Login();
			GameObject.Find("Manager").GetComponent<UI_Manager>().DownPanel_Loading();
			GameObject.Find("Manager").GetComponent<UI_Manager>().ShowPanel_Main();
			GameObject.Find("P_Main_Finout_2").GetComponent<Fade_In>().StartFadeInAnim();
		});

	}
	private void TrySignupWithFirebaseAuth (string email, string password, string password2, string nickname, int MorW) {

		if (password != password2) { 
			Debug.Log ("password and conform password is not matched"); 
			//패스워드 불일치 팝업
			return;
			}

		auth.CreateUserWithEmailAndPasswordAsync (email, password).ContinueWith (task => {
			if (task.IsCanceled) {
				Debug.LogError ("CreateUserWithEmailAndPasswordAsync was canceled.");
				return;
			}
			if (task.IsFaulted) {
				Debug.LogError ("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
				return;
			}

            Debug.Log("Welcom For Leporem" + user.UserId);
            Debug.Log(authUI.signupEmail.text);
            Debug.Log(authUI.nickName.text);
            if (authUI.MenOrWomen == 1)
            {
                Player player = new Player(authUI.signupEmail.text, authUI.nickName.text, "남자");
                DatabaseManager.CreateNewPlayer(player, user.UserId);
            }

            else
            {
                Player player = new Player(authUI.signupEmail.text, authUI.nickName.text, "여자");
                DatabaseManager.CreateNewPlayer(player, user.UserId);
            }
			// Firebase user has been created.
			Firebase.Auth.FirebaseUser newUser = task.Result;
			Debug.LogFormat ("Firebase user created successfully: {0} ({1})",
				newUser.DisplayName, newUser.UserId);

			GameObject.Find("P_Main_Finout").GetComponent<Fade_Out>().StartFadeOutAnim();
			GameObject.Find("Manager").GetComponent<UI_Manager>().DownPanel_newMember();
			GameObject.Find("Manager").GetComponent<UI_Manager>().ShowPanel_Login();
			GameObject.Find("P_Main_Finout").GetComponent<Fade_In>().StartFadeInAnim();
			
			
		});
	}

   public void AdvertiseButton()
    {
        if (authUI.MenOrWomen == 1)
        {
            Advertiser advertiser = new Advertiser(authUI.comName_InputField.text, authUI.productName_InputField.text, authUI.productDes_InputField.text, authUI.comNumber_InputField.text, authUI.celNumber_InputField.text,System.DateTime.Now.ToString() );
            DatabaseManager.CreateNewAdverTiser(advertiser, user.UserId);
        }

        else
        {
            Advertiser advertiser = new Advertiser(authUI.comName_InputField.text, authUI.productName_InputField.text, authUI.productDes_InputField.text, authUI.comNumber_InputField.text, authUI.celNumber_InputField.text, System.DateTime.Now.ToString());
            DatabaseManager.CreateNewAdverTiser(advertiser, user.UserId);
        }
    }

}