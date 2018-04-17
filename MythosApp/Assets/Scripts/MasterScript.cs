using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour
{
    List<PartyMember> partyMembers = new List<PartyMember>();
    public GameObject cards, cardPrefab;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void PopulateCards()
    {
        foreach (PartyMember member in partyMembers)
        {
            //For each card, instantiate a new card
            GameObject newCard = Object.Instantiate(cardPrefab);
            //And put it in the correct card-section
            newCard.transform.parent = cards.transform;
            //Then run its intialisation function with the correct values:
            newCard.GetComponent<CardInfo>().Initialise(member);

        }
    }


    void SerialiseFirstJson()
    {
        PartyMembersContainer container = new PartyMembersContainer();
        PartyMember member = new PartyMember();

        member.cardName = "cardnamehere";
        member.faction = FactionEnmum.Custos_Crypta;
        member.unflippedSprite = "unflippedSprite.png";
        member.flippedSprite = "flippedSprite.png";
        member.woundsCardSprite = "woundsCardSprite.png";

        member.unflippedValues = {0,0,0,0,0,0,0,,0,0,0};
        member.flippedValues;

    container.members.Add(member);

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
