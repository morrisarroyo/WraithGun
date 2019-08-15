using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private PlayerCharacter playerCharacter;
    [SerializeField] private TextMeshProUGUI characterText;
    [SerializeField] private TextMeshProUGUI healthText;



    // Start is called before the first frame update
    void Start()
    {
        characterText.text = playerCharacter.characterName;
        Debug.Log(playerCharacter.health);
        healthText.text = "Health: " + playerCharacter.health;
        Player.onHealthChanged += UpdatePlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdatePlayerHealth()
    {
        Debug.Log("Canvas-PlayerInfo-UpdatePlayerHealth");
        healthText.text = "Health: " + playerCharacter.health;
    }
}
