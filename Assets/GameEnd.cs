using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private Button againButton;
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private TextMeshProUGUI killsValue;
    private PlayerStats _playerStats;

    private void Awake()
    {
        againButton.onClick.AddListener(loadFirstScene);
        _playerStats = StatsManager.instance.GetLevelStats();
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreValue.text = _playerStats.score.ToString();
        killsValue.text = _playerStats.kills.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadFirstScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void OnDisable()
    {
        againButton.onClick.RemoveAllListeners();
    }
}
