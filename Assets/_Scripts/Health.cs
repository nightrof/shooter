using System.Collections;
using UnityEngine;

public class Health : Destructable
{
    public override void Die()
    {
        base.Die();
        print("we died");
    }

    public override void TakeDamage(float amount) 
    {
        base.TakeDamage(amount);
        print ("Remaining life: " + HitPointsRemaining);
    }
}
