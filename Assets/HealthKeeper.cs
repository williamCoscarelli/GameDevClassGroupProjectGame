using UnityEngine;

public class HealthKeeper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private static int healthAmount = 8;
    private static int maxHealthAmount = 8;

    public static void Decrement(int amount)
    {
        healthAmount = healthAmount - amount;
        if (healthAmount < 0)
            healthAmount = 0;
    }

    public static void Increment(int amount)
    {
        healthAmount = healthAmount + amount;
        if (healthAmount > maxHealthAmount)
            healthAmount = maxHealthAmount;
    }

    public static float GetHealthPercentage()
    {
        return (float) healthAmount / (float) maxHealthAmount;
    }
}

