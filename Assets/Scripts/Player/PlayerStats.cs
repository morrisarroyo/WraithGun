using UnityEngine;

[CreateAssetMenu(fileName = "new Player Statistics", menuName = "Player Statistics")]
public class PlayerStats : ScriptableObject
{
    public int score = 0;
    public int kills = 0;
    public int shotsTaken = 0;
    public int shotsHit = 0;
    public float accuracy = 0;
}