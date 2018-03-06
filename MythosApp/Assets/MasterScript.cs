using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour {

    public Everything everything = new Everything();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}









}

public enum KeywordsEnmum
{
    Human,
    Female,
    Male,
    Myth,
    Leader,
    Insect,

}

public enum AttackTypeEnmum
{
    COM,
    RAN,
    ARC
}

public enum MythosConditionEnmum
{
    Bleed,
    Blind,
    Burn,
    Drain,
    Fatigue,
    Haemorrage,
    Paralysed,
    Vigour
}

public enum FactionEnmum
{
    Custos_Crypta,
    Hidden_Ones,
    Order_of_the_Enlightened_Path,
    Priory,
    Wildborn
}

public enum BaseSizeEnum
{
    ThirtyMM,
    FortyMM,
    FiftyMM,
    SixtyMM,
    SeventyFiveMM
}

//Holds lists of all other JSON serialisable classes
[System.Serializable]
public class Everything
{
    public List<Faction> factions = new List<Faction>();
    public List<Party> parties = new List<Party>();
    //public List<Attacks> attacks = new List<Attacks>();
    //public List<MythosAbilities> mythosAbilities = new List<MythosAbilities>();
    //public List<CharacterTraits> characterTraits = new List<CharacterTraits>();
}

//Holds the Unit information for each faction
[System.Serializable]
public class Faction
{
    public List<Unit> units = new List<Unit>();
}

//holds the unit variables
[System.Serializable]
public class Unit
{
    //Each array should have 1/2 things in it, the first value should be its unflipped value, and the second should be its flipped value (if applicable, if not then it should only have 1)

    public string[] name;
    public FactionEnmum faction;
    public KeywordsEnmum[] keywords;
    public int[] movement;
    public int[] charge;
    public int[] combatAttack;
    public int[] combatDefence;
    public int[] rangeAttack;
    public int[] rangeDefence;
    public int[] arcaneAttack;
    public int[] arcaneDefence;
    public int[] mythos;
    public int[] wounds;
    public int[] sanity;
    public int[] sanityThrshhold;
    public bool flipWhenReached; //stores if the card automatically flips when the threshhold is reached
    public Attacks[] attacks;
    public Attacks[] flippedAttacks;
    public MythosAbilities[] mythosAbilities;
    public MythosAbilities[] flippedMythosAbilities;
    public CharacterTraits[] characterTraits;
    public CharacterTraits[] flippedCharacterTraits;
    public BaseSizeEnum baseSize;
    public int actionPointsBase;
    public int actionPointsRemaining;
    public bool activated;//stores if it has been activated yet, resets each round
    public bool flipped;//Stores if the character has been flipped
    public int cost;//unused for now, used for if/when army builders are introduced

}

//holds collections of units from individual faction
[System.Serializable]
public class Party
{
    public List<Unit> partyList = new List<Unit>();
}

//holds attacks and their properties
[System.Serializable]
public class Attacks
{
    public string attackName;
    public AttackTypeEnmum attackType;
    public string range;
    public MythosConditionEnmum mythosCondition;
}

//holds mythos abilities and their properties
[System.Serializable]
public class MythosAbilities
{
    public string mythosName;
    public int mythosCost;
    public string mythosDescription;
    public bool oncePerGame;//should be true if the ability is usable only once per game
    public bool used;//ticked once a once per game use is used
}

//holds character traits and their properties
[System.Serializable]
public class CharacterTraits
{
    public string traitName;
    public string traitDescription;
}

//holds Final Form traits and their properties
[System.Serializable]
public class FinalForm
{
    public string name;
}