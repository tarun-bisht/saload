using UnityEngine.UI;
using UnityEngine;
using Saload;
public class SavingLoading : MonoBehaviour
{
    [SerializeField]
    private InputField player_name;
    [SerializeField]
    private InputField nickname;
    [SerializeField]
    private InputField email;
    [SerializeField]
    private InputField score;
    [SerializeField]
    private InputField coins;

    public void SavePersonalDetails()
    {
        string name = player_name.text;
        string p_nickname = nickname.text;
        string p_email = email.text;
        PersonalDetails person = new PersonalDetails(name,p_nickname,p_email);
        Save.SetKey<PersonalDetails>("Details", person);
    }
    public void SaveScore()
    {
        int data =int.Parse(score.text);
        Save.SetKey<int>("Score", data);
    }
    public void SaveCoins()
    {
        int data = int.Parse(coins.text);
        Save.SetKey<int>("Coins", data);
    }
    public void LoadPersonalDetails()
    {
        PersonalDetails person = Load.GetKey<PersonalDetails>("Details");
        if(person !=null)
        {
            player_name.text = person.name;
            nickname.text = person.nickname;
            email.text = person.email;
        }
    }
    public void LoadScore()
    {
        score.text = Load.GetKey<int>("Score").ToString();
    }
    public void LoadCoins()
    {
        coins.text = Load.GetKey<int>("Coins").ToString();
    }
    public void Clear()
    {
        player_name.text="";
        nickname.text="";
        email.text="";
        score.text="";
        coins.text="";
    }
}
