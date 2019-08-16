using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlayerInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI characterText;
    [SerializeField] private TextMeshProUGUI healthText;

    PlayerCharacter playerCharacter;


    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GameManager.instance.GetPlayerCharacter();
        characterText.text = playerCharacter.characterName;
        //Debug.Log(playerCharacter.health);
        healthText.text = "Health: " + playerCharacter.health;
        PlayerHealth.OnHealthChanged += UpdatePlayerHealth;
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
