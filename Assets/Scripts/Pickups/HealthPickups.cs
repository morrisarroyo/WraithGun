using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health Pickup", menuName = "Health Pickup")]
public class HealthPickups : ScriptableObject
{
    public string pickupName;
    public int healthToAdd;
    public int rank;
    public float respawnTime;
}
