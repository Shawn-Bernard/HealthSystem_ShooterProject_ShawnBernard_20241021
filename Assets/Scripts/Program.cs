using System;
public class HealthSystem
{
    // Variables
    public int health;
    public string healthStatus;
    public string healthText;
    public int shield;
    public int lives = 3;

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

        if (shield == 100)
        {
            healthStatus = "Full Shield";
        }
        else if (shield >= 80)
        {
            healthStatus = "Strong Shield";
        }
        else if (shield >= 60)
        {
            healthStatus = "Damaged Shield";
        }
        else if (shield >= 40)
        {
            healthStatus = "Weak Shield";
        }
        else if (shield >= 20)
        {
            healthStatus = "Critical Shield";
        }

        if (health == 100 && shield == 0)
        {
            healthStatus = "Perfect Health";
        }
        else if (health >= 80 && shield == 0)
        {
            healthStatus = "Healthy";
        }
        else if (health >= 60 && shield == 0)
        {
            healthStatus = "Hurt";
        }
        else if (health >= 40 && shield == 0)
        {
            healthStatus = "Badly Hurt";
        }
        else if (health >= 20 && shield == 0)
        {
            healthStatus = "Imminent Danger";
        }


        return $"[Health: {health}]  [Shields: {shield}]  [Lives: {lives}]  [{healthStatus}]";
    }



    public void TakeDamage(int damage)
    {
        if (shield > 0)
        {
            shield -= damage;
        }
        else if (shield < 0)
        {
            shield = 0;
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
        if (health > 100)
        {
            health = 100;
        }
        
        
        // Implement healing logic
    }

    public void RegenerateShield(int hp)
    {
        shield += hp;
        if (shield > 100)
        {
            shield = 100;
        }
        
        
        // Implement shield regeneration logic
    }

    public void Revive()
    {
        if (health == 0 && lives != 0)
        {
            ResetGame();
            
                lives--;
        }
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