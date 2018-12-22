using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

public class AdvertiseBoard : MonoBehaviour
{

    public Text comnamestring;
    public Text productnamestring;
    public Text productdescriptionstring;
    public Text companynumberstring;
    public Text personalnumberstring;
    public Text datetimestring;

    public GameObject MyAdvertisement;
    Firebase.Auth.FirebaseAuth auth;

    void Awake()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        DatabaseManager.GetAdvertiser();

    }
    public void Advert()
    {
        Router.PlayerWithUIDMutual(auth.CurrentUser.UserId).GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot playersSnapshot1 = task.Result;
            Debug.Log(playersSnapshot1.GetRawJsonValue());
            comnamestring.text = playersSnapshot1.Value.ToString();
            Debug.Log(comnamestring.text);
        });

        Router.PlayerWithUIDProduct(auth.CurrentUser.UserId).GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot playersSnapshot2 = task.Result;
            Debug.Log(playersSnapshot2.GetRawJsonValue());
            productnamestring.text = playersSnapshot2.Value.ToString();
            Debug.Log(productnamestring.text);
        });

        Router.PlayerWithUIDProductDes(auth.CurrentUser.UserId).GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot playersSnapshot3 = task.Result;
            Debug.Log(playersSnapshot3.GetRawJsonValue());
            productdescriptionstring.text = playersSnapshot3.Value.ToString();
            Debug.Log(productdescriptionstring.text);
        });

        Router.PlayerWithUIDCompanyNum(auth.CurrentUser.UserId).GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot playersSnapshot4 = task.Result;
            Debug.Log(playersSnapshot4.GetRawJsonValue());
            companynumberstring.text = playersSnapshot4.Value.ToString();
            Debug.Log(companynumberstring.text);
        });

        Router.PlayerWithUIDPersonalNum(auth.CurrentUser.UserId).GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot playersSnapshot5 = task.Result;
            Debug.Log(playersSnapshot5.GetRawJsonValue());
            personalnumberstring.text = playersSnapshot5.Value.ToString();
            Debug.Log(personalnumberstring.text);
        });

        Router.PlayerWithUIDDate(auth.CurrentUser.UserId).GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot playersSnapshot6 = task.Result;
            Debug.Log(playersSnapshot6.GetRawJsonValue());
            datetimestring.text = playersSnapshot6.Value.ToString();
            Debug.Log(datetimestring.text);
        });
    }
}
