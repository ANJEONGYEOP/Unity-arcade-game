using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float           maxHP = 3;
    private float           currentHP;
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;

    [SerializeField]
    private Image[] heartIcons;
    
    private void Awake()

    {
        currentHP        = maxHP;
        UpdateHearts();
        spriteRenderer   = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(float damge)
    {
        //current HP -damage
        currentHP -= damge;
        if (currentHP < 0) currentHP = 0;
        UpdateHearts();

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        if ( currentHP <= 0 )
        {
            //0 die
            playerController.OnDie();
            Debug.Log("Player HP : 0.. Die");
        }
    }

    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
        private void UpdateHearts()
    {
        for (int i = 0; i < heartIcons.Length; i++)
        {
            if (i < currentHP)
            {
                heartIcons[i].enabled = true;
            }
            else
            {
                heartIcons[i].enabled = false;
            }
        }
    }

}
