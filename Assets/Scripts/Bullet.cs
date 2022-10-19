using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.Netcode;

public class Bullet : NetworkBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        GameObject hit = col.gameObject;
        Health currentHealth = hit.GetComponent<Health>();
        if(currentHealth != null)
        {
            currentHealth.Damage(5);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
