using UnityEngine;

public class Zombie : MonoBehaviour
{
    public ZombieAttack zombieAttack1;
    
    public int zombieDamage;

    public void Start()
    {
        zombieAttack1.damage = zombieDamage;
    }
}
