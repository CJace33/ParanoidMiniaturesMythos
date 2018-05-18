using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MasterScript : MonoBehaviour
{
    //
    PartyMembersContainer partyMembers = new PartyMembersContainer();
    Parties parties = new Parties();
    public GameObject card;
    public string basePath;
    public string partyMembersJSONString;
    public string partiesJSONString;



    // Use this for initialization
    void Start ()
    {
        //Find the path to the StreamingAssets folder based on platform
        if (Application.isEditor)
        {
            basePath = Path.Combine(Application.dataPath, "//StreamingAssets");
            partiesJSONString = Path.Combine(basePath, "//Parties.txt");
            partyMembersJSONString = Path.Combine(basePath, "//PartyMembers.txt");
        }
        //Android exception
        else if (Application.platform == RuntimePlatform.Android)
        {
            basePath = "jar:file://" + Application.dataPath + "//Raw";
            partiesJSONString = basePath + "//Parties.txt";
            partyMembersJSONString = basePath + "//PartyMembers.txt";
        }
        //IOs exception
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            partiesJSONString = Path.Combine(Application.dataPath, "//Raw//Parties.txt");
            partyMembersJSONString = Path.Combine(Application.dataPath, "//Raw//PartyMembers.txt");
        }

            //If the file already exists then load it, if not then create a new one at that location
        if (File.Exists(partiesJSONString))
            parties = LoadData(partiesJSONString, parties);
        else
            JSONEncode(partiesJSONString, parties);
        //Load the data in from files
        parties = LoadData(partiesJSONString, parties);
        partyMembers = LoadData(partyMembersJSONString, partyMembers);
    }
    
    //Save the data to a given path, overload for Parties or Party Members
    public void JSONEncode(string JSONFilePath, Parties file)
    {
        //Check if the Save file exists, and if it does then delete it
        if (File.Exists(JSONFilePath))
        {
            File.Delete(JSONFilePath);
        }

        //Save the level to a JSON string
        string json = JsonUtility.ToJson(file, true);
        //And then write it to an actual textfile
        File.WriteAllText(JSONFilePath, json);
    }
    public void JSONEncode(string JSONFilePath, PartyMembersContainer file)
    {
        //Check if the Save file exists, and if it does then delete it
        if (File.Exists(JSONFilePath))
        {
            File.Delete(JSONFilePath);
        }

        //Save the level to a JSON string
        string json = JsonUtility.ToJson(file, true);
        //And then write it to an actual textfile
        File.WriteAllText(JSONFilePath, json);
    }

    //Load the card data from the JSON file, the second parameter doesn't do anything except identify the load type
    public PartyMembersContainer LoadData(string pathString, PartyMembersContainer partyMembersContainer)
    {
        PartyMembersContainer data = null;
        JsonUtility.FromJsonOverwrite(pathString, data);
        return data;
    }
    public Parties LoadData(string pathString, Parties parties)
    {
        Parties data = null;
        JsonUtility.FromJsonOverwrite(pathString, data);
        return data;
    }

    void ShowCard(PartyMember member)
    {
        card.GetComponent<CardInfo>().Initialise(member);
    }

}

public enum FactionEnmum
{
    Custos_Crypta,
    Hidden_Ones,
    Order_of_the_Enlightened_Path,
    Priory,
    Wildborn
}

[System.Serializable]
public class PartyMembersContainer
{
    public List<PartyMember> members = new List<PartyMember>();
}


[System.Serializable]
public class PartyMember
{
    public FactionEnmum faction;
    public string cardName;
    public string unflippedSprite, flippedSprite, woundsCardSprite;

    public int[] unflippedValues;
    public int[] flippedValues;


    //public int U_MOV1, U_MOV2, U_COM1, U_COM2, U_RAN1, U_RAN2, U_ARC1, U_ARC2, U_MYT, U_SAN;
    //public int F_MOV1, F_MOV2, F_COM1, F_COM2, F_RAN1, F_RAN2, F_ARC1, F_ARC2, F_MYT, F_SAN;
}

//Class to store a list of parties
[System.Serializable]
public class Parties
{
    public List<Party> parties;
}

//Class to store the information from each party
[System.Serializable]
public class Party
{
    public FactionEnmum faction;
    public string partyName;
    public List<string> partyMembers;

}