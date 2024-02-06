
using UnityEngine;

namespace Bioscene
{
    public class Health
    {
        int value = 100;

        public void Damage(int amount)
        {
            value -= amount;
        }

        public bool Dead()
        {
            return value < 1;
        }
    }
}