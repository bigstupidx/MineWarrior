using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private Image HUD;

    private float playerHealth = 100f;
    
    private CharController charController;

    void Awake()
    {
        charController = GetComponent<CharController>();
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        fillAmount = playerHealth / 100;

        if (playerHealth <= 0)
        {
            charController.Die();
        }
    }

    void Update()
    {
        HandleBar();
    }

    void HandleBar()
    {
        HUD.fillAmount = fillAmount;
    }
}