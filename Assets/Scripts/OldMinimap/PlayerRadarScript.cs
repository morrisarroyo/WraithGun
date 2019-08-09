using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Using triggers it adds enemies' transforms to Minimap script to render
 */
public class PlayerRadarScript : MonoBehaviour
{
    public delegate void AddToMinimap(Transform transform);
    public static event AddToMinimap OnEnterRadar;

    public delegate void RemoveFromMinimap(Transform transform);
    public static event RemoveFromMinimap OnExitRadar;

    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("PlayerRadarScript Enter");
        OnEnterRadar(other.transform);
    }

    void OnTriggerExit(Collider other)
    {
        OnExitRadar(other.transform);
    }

}
