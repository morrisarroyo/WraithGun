using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartSniperGun : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
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
        Debug.Log("DartSniperGun.Fire");
        Transform tr = transform;
        GameObject bullet = Instantiate(ammo, tr.position + (tr.localScale.z * 2 * tr.forward), Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * 50;
        Debug.Log(_gunFireSoundName);
        AudioManager.instance.Play(_gunFireSoundName);
    }
}
