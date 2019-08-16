using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlayerStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI killsText;

    private PlayerStats _levelStats;
    
    // Start is called before the first frame update
    void Start()
    {
        _levelStats = StatsManager.instance.GetLevelStats();
        StatsManager.OnUpdatePlayerScore += UpdateScoreText;
        StatsManager.OnUpdatePlayerKills += UpdateKillsText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void UpdateScoreText()
    {
        //Debug.Log("UIPlayerStats.UpdateScoreText");
        scoreText.text = "Score: " + _levelStats.score;
    }


    void UpdateKillsText()
    {
        //Debug.Log("UIPlayerStats.UpdateKillsText");
        killsText.text = "Kills: " + _levelStats.kills;
    }
}
