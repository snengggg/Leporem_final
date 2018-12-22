using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

public class MyaccoutBoard : MonoBehaviour
{

    public Text emailString;
    public Text nicknameString;
    public Text GenderString;

    public GameObject accoutBoard;
    Firebase.Auth.FirebaseAuth auth;

    void Awake()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        DatabaseManager.GetPlayer();

    }
    public void Config()
    {
        Router.PlayerWithUIDnickname(auth.CurrentUser.UserId).GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot playersSnapshot1 = task.Result;
            Debug.Log(playersSnapshot1.GetRawJsonValue());
            nicknameString.text = playersSnapshot1.Value.ToString();
            Debug.Log(nicknameString.text);
        });

        Router.PlayerWithUIDgender(auth.CurrentUser.UserId).GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot playersSnapshot2 = task.Result;
            Debug.Log(playersSnapshot2.GetRawJsonValue());
            GenderString.text = playersSnapshot2.Value.ToString();
            Debug.Log(GenderString.text);
        });

        Router.PlayerWithUIDemail(auth.CurrentUser.UserId).GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot playersSnapshot3 = task.Result;
            Debug.Log(playersSnapshot3.GetRawJsonValue());
            emailString.text = playersSnapshot3.Value.ToString();
            Debug.Log(emailString.text);
        });
    }
}
