﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

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
    }

    void Start()
    {
        //LoadAssetFromAssetBundlePractice();
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

    }
}