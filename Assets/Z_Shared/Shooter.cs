using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] float rateOfFire = 1;
    [SerializeField] Projectile projectile;
    float nextFireAllowed;
    public bool canFire;
    [HideInInspector] public Transform muzzle;

    // Start is called before the first frame update
    void Awake ()
    {
        muzzle = transform.Find("Muzzle");
    }

    public virtual void Fire() 
    {
        canFire = false;
        if (Time.time < nextFireAllowed)
        {
            return;
        }
        nextFireAllowed = Time.time + rateOfFire;

        Instantiate(projectile, muzzle.position, muzzle.rotation);
        canFire = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
