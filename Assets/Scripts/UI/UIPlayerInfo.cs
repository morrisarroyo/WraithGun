using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlayerInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI characterText;
    [SerializeField] private TextMeshProUGUI healthText;

    PlayerCharacter _playerCharacter;


    // Start is called before the first frame update
    void Start()
    {
        _playerCharacter = GameManager.instance.GetPlayerCharacter();
        characterText.text = _playerCharacter.characterName;
        //Debug.Log(playerCharacter.health);
        healthText.text = "Health: " + _playerCharacter.health;
        PlayerHealth.OnHealthChanged += UpdatePlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdatePlayerHealth()
    {
        //Debug.Log("UIPlayerInfo.UpdatePlayerHealth");
        healthText.text = "Health: " + _playerCharacter.health;
    }
}
