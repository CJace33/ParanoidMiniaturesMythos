using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour {

    public FactionEnmum faction;
    public string cardName;
    public Canvas cardCanvas, woundCanvas;
    //Image referance to the card
    public Image cardImage;
    //Sprites for the images of the actual card, loaded from Resources folder
    public Sprite unflippedImage, flippedImage, woundsBox;
    //Shown text references
    public Text MOV, COM, RAN, ARC, MYT, WND, SAN;

    //card stat values stored here, they need to be stored here so they can be changed in the game without permenently changing their JSON values
    public int[] unflippedValues = new int[11];
    public int[] flippedValues = new int[11];

    //loaded_U_MOV1, loaded_U_MOV2, loaded_U_COM1, loaded_U_COM2, loaded_U_RAN1, loaded_U_RAN2, loaded_U_ARC1, loaded_U_ARC2, loaded_U_MYT, loaded_U_SAN, loaded_F_MOV1, loaded_F_MOV2, loaded_F_COM1, loaded_F_COM2, loaded_F_RAN1, loaded_F_RAN2, loaded_F_ARC1, loaded_F_ARC2, loaded_F_MYT, loaded_F_SAN;
    public bool flipped;
    public bool activated;

    // Use this as your constructor
    //Pass in the card object loaded from the JSON file
    public void Initialise(PartyMember member)
    {
        //Assign all the passed-in information
        cardCanvas = this.GetComponent<Canvas>();
        faction = member.faction;
        cardName = member.cardName;
        unflippedImage = (Sprite)Resources.Load(member.unflippedSprite);
        flippedImage = (Sprite)Resources.Load(member.flippedSprite);
        woundsBox = (Sprite)Resources.Load(member.woundsCardSprite);

        ResetCardStats(member);
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Restores the stored card stats from the ones stored in JSON
    void ResetCardStats(PartyMember member)
    {
        unflippedValues = member.unflippedValues;
        flippedValues = member.flippedValues;
        UpdateCardStats();
    }

    //Updates the card stats that are being shown
    void UpdateCardStats()
    {
        if (flipped)
        {
            MOV.text = flippedValues[0].ToString() + "/" + flippedValues[1].ToString();
            COM.text = flippedValues[2].ToString() + "/" + flippedValues[3].ToString();
            RAN.text = flippedValues[4].ToString() + "/" + flippedValues[5].ToString();
            ARC.text = flippedValues[6].ToString() + "/" + flippedValues[7].ToString();
            MYT.text = flippedValues[8].ToString();
            WND.text = flippedValues[9].ToString();
            SAN.text = flippedValues[10].ToString();
        }
        else
        {
            MOV.text = unflippedValues[0].ToString() + "/" + unflippedValues[1].ToString();
            COM.text = unflippedValues[2].ToString() + "/" + unflippedValues[3].ToString();
            RAN.text = unflippedValues[4].ToString() + "/" + unflippedValues[5].ToString();
            ARC.text = unflippedValues[6].ToString() + "/" + unflippedValues[7].ToString();
            MYT.text = unflippedValues[8].ToString();
            WND.text = unflippedValues[9].ToString();
            SAN.text = unflippedValues[10].ToString();
        }
    }

    //Flip the activations of both of these cards
    public void buttonFlipCard()
    {
        if (cardImage.sprite == unflippedImage)
        {
            cardImage.sprite = flippedImage;
            flipped = true;
        }
        else
        {
            cardImage.sprite = unflippedImage;
            flipped = false;
        }
    }

    public void buttonWoundCard()
    {
        woundCanvas.gameObject.SetActive(!woundCanvas.gameObject.activeSelf);
    }
}