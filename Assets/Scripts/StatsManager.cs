using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsManager : MonoBehaviour
{
    public static StatsManager instance;
    
    [SerializeField]
    private PlayerStats lifetimeStats;
    private PlayerStats _levelStats;
    public PlayerStats LevelStats
    {
        get => _levelStats;
        private set => _levelStats = value;
    }

    public delegate void UpdatePlayerScore();
    public static event UpdatePlayerScore OnUpdatePlayerScore;
    public delegate void UpdatePlayerKills();
    public static event UpdatePlayerKills OnUpdatePlayerKills;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        _levelStats = ScriptableObject.CreateInstance<PlayerStats>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += ResetLevelStats;
    }

    public PlayerStats GetLevelStats()
    {
        return _levelStats;
    }

    void ResetLevelStats(Scene current, Scene next)
    {
        _levelStats = ScriptableObject.CreateInstance<PlayerStats>();
    }
    
    public void AddScore(int score)
    {
        lifetimeStats.score += score;
        _levelStats.score += score;
        OnUpdatePlayerScore?.Invoke();
    }
  
    public void AddKills(int kills)
    {
        lifetimeStats.kills += kills;
        _levelStats.kills += kills;
        OnUpdatePlayerKills?.Invoke();
    }
}
