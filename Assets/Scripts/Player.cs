using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : Actor {
    public static Player instance;
    int lastCheckedShield;
    int lastCheckedHealth;
    int lastCheckedXp;
    int lastCheckedLevel;
    
    

    public void Awake() {
        instance = this;
    }

    public override void Die()
    {
        base.Die();
        
        if (healthSystem.lives <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Player.instance.healthSystem.Revive();
            gameObject.SetActive(true);
        }
    }

    public override void Update() {
        base.Update();
        if (lastCheckedHealth != healthSystem.health || lastCheckedShield != healthSystem.shield || lastCheckedLevel != healthSystem.level || lastCheckedXp != healthSystem.xp )
        {
            HealthUI.instance.textmeshpro.text = healthSystem.ShowHUD();
            lastCheckedShield = healthSystem.shield;
            lastCheckedHealth = healthSystem.health;
            lastCheckedLevel = healthSystem.level;
            lastCheckedXp = healthSystem.xp;
            //lastCheckedHealthText = healthSystem.healthText;
        }
    }

    public override Vector3 GetMovementDirection()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
    }
    public override Vector3 GetLookDirection()
    {
        return ShootDirection();
    }

    public override bool WantsToShoot()
    {
        if (healthSystem.health <= 0)
            return false;
        return Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
    }

    public override Vector3 ShootDirection()
    {
        var desiredDirectionShot = (mouseReticle.instance.transform.position - transform.position);
        desiredDirectionShot.y = 0.0f;
        return desiredDirectionShot.normalized;
    }
}
