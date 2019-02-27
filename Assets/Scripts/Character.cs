using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "Character")]
public class NewBehaviourScript : ScriptableObject
{
    public string characterName = "Default"; //name
    public int startingHP = 100; //hp

    public Ability[] characterAbilities; //powers and abilities they have
}
