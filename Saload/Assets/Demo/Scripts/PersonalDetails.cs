[System.Serializable]
public class PersonalDetails
{
    public PersonalDetails(string name, string nickname,string email)
    {
        this.name = name;
        this.nickname = nickname;
        this.email = email;
    }
    public string name;
    public string nickname;
    public string email;
}
