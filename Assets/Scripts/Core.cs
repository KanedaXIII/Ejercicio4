using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Core : MonoBehaviour
{
    [SerializeField]
    private Animator _coreAnimatorController;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            _coreAnimatorController.SetTrigger("takeDamage");
        }
    }
}
