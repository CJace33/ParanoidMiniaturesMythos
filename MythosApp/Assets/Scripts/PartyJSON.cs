using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyJSON : MonoBehaviour
{
    List<PartyInfo> parties = new List<PartyInfo>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}




[System.Serializable]
public class PartyInfo
{
    public FactionEnmum faction;
    public string partyName;




}