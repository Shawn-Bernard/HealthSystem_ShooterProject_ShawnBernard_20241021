using System;
public class HealthSystem
{
    // Variables
    public int health;
    public string healthStatus;
    public string healthText;
    public int shield;
    public int lives;

    // Optional XP system variables
    public int xp;
    public int level;

    public HealthSystem()
    {
        ResetGame();
    }


    public string ShowHUD()
    {
        // Implement HUD display
        //healthStatus = $"Health: {health} Shield: {shield} lives: {lives}";
        healthStatus = $"Health: {health} - {healthText} Shields: {shield} Lives: {lives}";

        if (health >= 100)
        {
            healthText = "Perfect Health";
        }


        return healthStatus;
    }
    

    public void TakeDamage(int damage)
    {
        if (shield > 0)
        {
            shield -= damage;
        }
        else { health -= damage; }
        // Implement damage logic
    }

    public void Heal(int hp)
    {
        if (health < 100)
        {
            health += hp;
        }
        
        
        // Implement healing logic
    }

    public void RegenerateShield(int hp)
    {
        
            shield += hp;
        
        // Implement shield regeneration logic
    }

    public void Revive()
    {
        // Implement revive logic
    }

    public void ResetGame()
    {
        // Reset all variables to default values
        health = 100;
        shield = 100;
    }

    // Optional XP system methods
    public void IncreaseXP(int exp)
    {
        // Implement XP increase and level-up logic
    }
}