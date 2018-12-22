using UnityEngine;
using Firebase.Database;

public class Router : MonoBehaviour
{

    private static DatabaseReference baseRef = FirebaseDatabase.DefaultInstance.RootReference;

    public static DatabaseReference Players()
    {
        return baseRef.Child("Players");
    }

    public static DatabaseReference PlayerWithUID(string uid)
    {
        return baseRef.Child("players").Child(uid);
    }

    public static DatabaseReference PlayerWithUIDnickname(string uid)
    {
        return baseRef.Child("players").Child(uid).Child("Nickname");
    }
    public static DatabaseReference PlayerWithUIDgender(string uid)
    {
        return baseRef.Child("players").Child(uid).Child("Gender");
    }

    public static DatabaseReference PlayerWithUIDadvertise(string uid)
    {
        return baseRef.Child("players").Child(uid).Child("Advertise");
    }
    public static DatabaseReference PlayerWithUIDemail(string uid)
    {
        return baseRef.Child("players").Child(uid).Child("Email");
    }




    public static DatabaseReference PlayerWithUIDMutual(string uid)
    {
        return baseRef.Child("players").Child(uid).Child("Advertise").Child("ComName");
    }
    public static DatabaseReference PlayerWithUIDProduct(string uid)
    {
        return baseRef.Child("players").Child(uid).Child("Advertise").Child("ProductName");
    }
    public static DatabaseReference PlayerWithUIDProductDes(string uid)
    {
        return baseRef.Child("players").Child(uid).Child("Advertise").Child("ProductDescription");
    }
    public static DatabaseReference PlayerWithUIDCompanyNum(string uid)
    {
        return baseRef.Child("players").Child(uid).Child("Advertise").Child("CompanyNumber");
    }
    public static DatabaseReference PlayerWithUIDPersonalNum(string uid)
    {
        return baseRef.Child("players").Child(uid).Child("Advertise").Child("PersonalNumber");
    }
    public static DatabaseReference PlayerWithUIDDate(string uid)
    {
        return baseRef.Child("players").Child(uid).Child("Advertise").Child("DateTime");
    }
}
