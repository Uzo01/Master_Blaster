using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHP = 100;
    public GameObject projectile;
    public Transform projectilePont;

    public Animator animator;

    public void Shoot()
    {
        Rigidbody rig = Instantiate(projectile, projectilePont.position, Quaternion.identity).GetComponent<Rigidbody>();
        rig.AddForce(transform.forward * 7f, ForceMode.Impulse); //speed of enemy
        rig.AddForce(transform.up * 6, ForceMode.Impulse);
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        if (enemyHP <= 0)
        {
            //Play Death Animation
            animator.SetTrigger("Death");
            GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            //Play Take Damage Animation
            animator.SetTrigger("Damage");
        }
    }
}
