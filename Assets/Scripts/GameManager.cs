using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField]
    private PlayerCharacter playerCharacter;

    [SerializeField] private int killsRequired;
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

        playerCharacter = PlayerCharacter.Clone(playerCharacter);
        //LoadAssetFromAssetBundlePractice();
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.activeSceneChanged += ChangeCursorMode;
    }

    //practice loading from asset bundle
    private static void LoadAssetFromAssetBundlePractice()
    {
        Debug.Log(Path.Combine(Application.dataPath + "/AssetBundles", "paintball"));
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath + "/AssetBundles", "paintball"));
        //var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "paintball"));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        myLoadedAssetBundle.LoadAllAssets();
        Debug.Log("Loaded Asset");
        var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("Ammo");
        GameObject obj = Instantiate(prefab);
        obj.transform.position = new Vector3(2, 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsVictory())
        {
            SceneManager.LoadScene("GameEndScene");
        }
    }

    public PlayerCharacter GetPlayerCharacter()
    {
        return playerCharacter;
    }

    private bool IsVictory()
    {
        return StatsManager.instance.LevelStats.kills >= killsRequired;
    }

    private void ChangeCursorMode(Scene current, Scene next)
    {
        if (next.name == "MainScene")
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
