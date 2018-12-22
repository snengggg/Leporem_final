using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;


public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager sharedInstance;

    void Awake()
    {
        if (sharedInstance == null)
        {

            sharedInstance = this;

        }
        else if (sharedInstance != this)
        {
            Destroy(gameObject);
            Debug.Log(sharedInstance);
        }

        DontDestroyOnLoad(gameObject);

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://fireb-test-e9338.firebaseio.com/");
        Debug.Log(Router.Players());
    }


    public static void CreateNewPlayer(Player player, string uid)
    {
        string playerJSON = JsonUtility.ToJson(player);
        Router.PlayerWithUID(uid).SetRawJsonValueAsync(playerJSON);

    }

    public static void GetPlayer()
    { 
            Router.Players().GetValueAsync().ContinueWith(task =>
            {
                DataSnapshot players = task.Result;
                Debug.Log(task.Result);
            });
        ;
    }

    public static void CreateNewAdverTiser(Advertiser advertiser, string uid)
    {
        Debug.Log("씨발1");
        string playerJSON = JsonUtility.ToJson(advertiser);
        Router.PlayerWithUID(uid).Child("Advertise").SetRawJsonValueAsync(playerJSON);
    }

    public static void GetAdvertiser()
    {
        Debug.Log("씨발2");
        Router.Players().GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot players = task.Result;
            Debug.Log(task.Result);
        });
    }
}


