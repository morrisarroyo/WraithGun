
public class PlayerHealth
{
    public delegate void UpdatePlayerHealth();
    public static event UpdatePlayerHealth OnHealthChanged;
  
    public static int GetHealth()
    {
        return GameManager.instance.GetPlayerCharacter().health;
    }

    public static void AddHealth(int healthToAdd)
    {
        GameManager.instance.GetPlayerCharacter().health += healthToAdd;
        if (OnHealthChanged != null)
            OnHealthChanged();
    }
}