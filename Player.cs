public class Player
{
    public string Email;
    public string Nickname;
    public string Gender;
   

    public Player(string email, string nickname, string gender)
    {
        this.Email = email;
        this.Nickname = nickname;
        this.Gender = gender;
    }
}

public class Advertiser
{
    public string ComName;
    public string ProductName;
    public string ProductDescription;
    public string CompanyNumber;
    public string PersonalNumber;
    public string DateTime;

    public Advertiser(string Comname, string productname, string productdescrioption, string companynumber, string personalnumber, string datetime)
    {

        this.ComName = Comname;
        this.ProductName = productname;
        this.ProductDescription = productdescrioption;
        this.CompanyNumber = companynumber;
        this.PersonalNumber = personalnumber;
        this.DateTime = datetime;
    }
}