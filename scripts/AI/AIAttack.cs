using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bioscene
{    
    public class AIAttack : MonoBehaviour
    {
        Health health;
        [SerializeField] int damageAmount;
        void Start()
        {
            health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter(Collider col)
        {
            if (col.GetComponent<PlayerMovement>())
            {
                col.GetComponent<Health>().Damage(damageAmount);
            }
            if (col.GetComponent<Cell>())
            {
                col.GetComponent<Health>().Damage(damageAmount);
            }
        }
    }
}
