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
    public int level = 1;

    public HealthSystem()
    {
        ResetGame();
    }


    public string ShowHUD()
    {
        // Implement HUD display

        ShieldStatus(); // I added these so I didn't have to look at that mess down there
        HealthStatus();


        return $"[Health: {health}]  [Shields: {shield}]  [Lives: {lives}]  [Level: {level}] [{healthStatus}]";
    }



    public void TakeDamage(int damage)
    {
        if (shield > 0)
        {
            shield -= damage; // if shield is greater than 0 cause damage, else damage health instead  
        }
        else {health -= damage;}

        // Implement damage logic
    }

    public void Heal(int hp)
    {
        health += hp;
        if (health > 100)
        {
            health -= hp; //if health is greater than 100, take away the heal
        }
        
        
        // Implement healing logic
    }

    public void RegenerateShield(int hp)
    {
        shield += hp;
        if (shield > 100)
        {
            shield -= hp; //  if shield is greater than 100, take away the heal
        }
        
        
        // Implement shield regeneration logic
    }

    public void Revive()
    {
        ResetGame();
        lives--; // takes away lives each time this is called, I called it in Player
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
        xp += exp; // Adding 20 to xp
        if (xp == 100)
        {
            xp %= 100; // exp loops around after reaching 100 xp
            level++; // adding one level each time the if statement is played
            lives++; // adding lives each level up
        }
        if (level > 99)
        {
            level--; // take away level by one if we go over 100
        }
        if (lives > 100)
        {
            lives--;// take away lives by one if we go over 100
        }
        
        // Implement XP increase and level-up logic
    }
    public void ShieldStatus()
    {
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
    }
    public void HealthStatus()
    {
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
    }
}