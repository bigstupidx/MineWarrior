using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private Image HUD;
    [SerializeField]
    private float playerHealth = 100f;

    private SpriteRenderer playerSpriteRenderer;
    private CharController charController;

    void Awake()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
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
        else
        {
            StartCoroutine(FadePlayer());
        }
    }

    void Update()
    {
        HandleHUD();
    }

    void HandleHUD()
    {
        HUD.fillAmount = fillAmount;
    }

    IEnumerator FadePlayer()
    {
        for (int j = 0; j <= 1; j++)
        {
            for (float i = 1f; i >= 0; i -= 0.05f)
            {
                yield return new WaitForSeconds(.01f);
                playerSpriteRenderer.color = new Color(1f, 1f, 1f, i);
            }
            for (float i = 0f; i <= 1; i += 0.05f)
            {
                yield return new WaitForSeconds(.01f);
                playerSpriteRenderer.color = new Color(1f, 1f, 1f, i);
            }        
        }
    }
}