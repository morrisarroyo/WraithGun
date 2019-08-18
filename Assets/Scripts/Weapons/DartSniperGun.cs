using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartSniperGun : MonoBehaviour
{
    [SerializeField] private float bulletFireSpeed;
    // Start is called before the first frame update
    private string _gunFireSoundName;
    void Start()
    {
        InputManager.OnInputLeftClick += Fire;
        //Debug.Log("DartSniperGun.Start");
        _gunFireSoundName = GameManager.instance.GetPlayerCharacter().sounds.attack.name;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnDisable()
    {
        InputManager.OnInputLeftClick -= Fire;
    }

    void Fire()
    {
        //Debug.Log("DartSniperGun.Fire");
        Transform tr = transform;
        DartSniperBullet bullet = DartSniperBulletPool.Instance.GetFromPool();
        bullet.gameObject.SetActive(true);
        bullet.gameObject.transform.position = tr.position + (tr.localScale.z * tr.forward);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletFireSpeed;
        //Debug.Log(_gunFireSoundName);
        AudioManager.instance.Play(_gunFireSoundName);
    }
}
