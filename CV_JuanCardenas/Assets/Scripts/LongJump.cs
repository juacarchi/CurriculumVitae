using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongJump : MonoBehaviour
{
    public CharacterController2D char2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            char2D.ExtraJump();
        }
    }
}
