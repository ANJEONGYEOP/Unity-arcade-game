using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;     //stone damage

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("player") )
        {
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
