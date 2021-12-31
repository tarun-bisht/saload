# Saload

Saload is a tool to save and load data efficiently into games.

<img src="icon.png" width="200" height="200" alt="saload icon logo">

## Why use Saload?

- **Security of game data**: Save Game data securely into binary file which is harder to read and spoof.
- [**Dealing with big Chunks of data**](#big-chunk-usage): Deal with big chunk of data easily by wrapping all data into a class and saving its state, also data can be easily loaded into that class object.
- **Easy to use**: Easily save and load data by its key. Also it is easy to use with custom classes of data.
- **Track**: Easily track which keys have been saved yet.

**(note: To be able to track the saved custom created objects use .saload extension to the binary file name while saving data.)**

## Documentation

### Namespace

- [**Saload**](#saload-usage) namespace contains all neccessary class and functions to save and load data.

### Classes

- [**Save**](#save-usage) class contains modules for saving data locally in binary format.
- [**Load**](#load-usage) class contains modules for loading binary data from local storage in game.

## API Reference

### Namespace

<a name="saload-usage"></a>**Importing the Namespace**
```C#
using Saload;
```

### Classes

#### 1. <a name="save-usage"></a>Save

##### SetKey

```C#
void SetKey<T>(string key, T data)
```

- **T**: type of data to save.

- **Parameters**:

| Parameter Name | Data Type     | Description                                              |
| -------------- | ------------- | -------------------------------------------------------- |
| key            | string        | key by which you can access or refer to saved data later |
| data           | generic (any) | data you want to save                                    |

**For ex. For saving coins data use key= “coins” to access the coins data later with this name.**

- **Returns** : Nothing

**Code Example**

```C#
    public void SaveScore()
    {
        int data =score;
        //Saving a integer data with key named “Score”
        Save.SetKey<int>("Score", data);
    }
    public void SaveName()
    {
        string data = name.text;
        //Saving a string data with key named “Player_Name”
        Save.SetKey<string>("Player_Name", data);
    }

    public void SavePersonalDetails()
    {
        string name = player_name.text;
        string p_nickname = nickname.text;
        string p_email = email.text;
        //Creating PersonalDetails object named person
        PersonalDetails person = new PersonalDetails(name,p_nickname,p_email);
        //Saving data of type PersonalDetails
        Save.SetKey<PersonalDetails>("Details", person);
    }
```

And Personal Details class looks like

```C#
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
```

**Note: To be able to save custom type data make sure class is serializable. using `[System.Serialization]`**

#### 2. <a name="load-usage"></a>Load

##### GetKey

```C#
T GetKey<T>(string key)
```

- **T**: type of data which is loaded.

- **Parameters**:

| Parameter Name | Data Type | Description            |
| -------------- | --------- | ---------------------- |
| key            | String    | key of data to access. |

- **Returns** : Generic type object as defined.

**Code Example**

```C#
    public void LoadScore()
    {
        //load integer from key “Score”
        score.text = Load.GetKey<int>("Score").ToString();
    }
    public void LoadName()
    {
        //Load string from key “Player_Name”
        name.text = Load.GetKey<string>("Player_Name");
    }
    public void LoadPersonalDetails()
    {
        //Loading PersonalDetails object from key “Details”
        PersonalDetails person = Load.GetKey<PersonalDetails>("Details");
        if(person !=null)
        {
            player_name.text = person.name;
            nickname.text = person.nickname;
            email.text = person.email;
        }
    }
```

### <a name="big-chunk-usage"></a> Dealing with big chunks of data

If planning or developing a game with lots of quests, accessories, items etc. Then tackling large amount of data is very hard and tricky. Saload provide a way to easily and efficiently save and load game data.

**To save and load large amount of data**:

- Create class which is System.Serializable
- Put all relevant data in one place as member of class.
- Make object of class and initialize its values which is going to be save.
- Loading data is easy as calling `Load.GetKey<class name>(“key”)` which return object of class or null.
- Saving object is easy as calling `Save.SetKey<class name>("key",dataObject)` which saves object data in binary format.
- Create a constructor to be able to initialize object values when it is created.(optional)

**Code Example**

```C#
    //Creating serializable class whose object is to be saved
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
    // Saving Personal Detail object data
    public void SavePersonalDetails()
    {
        string name = player_name.text;
        string p_nickname = nickname.text;
        string p_email = email.text;
        PersonalDetails person = new PersonalDetails(name,p_nickname,p_email);
        Save.SetKey<PersonalDetails>("Details", person);
    }
    //Loading Personal Detail Data.
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
```

## License

[MIT](https://en.wikipedia.org/wiki/MIT_License)
