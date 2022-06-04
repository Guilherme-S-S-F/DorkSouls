using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField]PlayerController playerController;
    
    bool attack = false;
    private void Update()
    {
        if(playerController.lightAttackFlag || playerController.heavyAttackFlag)
            attack = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (attack)
        {
            
            if (other.tag == "Damageable")
            {
                attack = false;
                IDamageable damageable = other.GetComponent<IDamageable>();
                damageable.TakeDamage(playerController.playerMovement.damageToDo);
            }
        }
    }
}
