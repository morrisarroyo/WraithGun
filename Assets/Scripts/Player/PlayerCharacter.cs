using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class PlayerCharacter : ScriptableObject
{
    public string characterName;
    public CharacterSounds sounds;
    public int health;
    public int attackDamage;
    public float movementSpeed;
    public float jumpFactor;
    public float rotationSpeed;
}
