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
    private bool isDamageable = true;

    void Awake()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        charController = GetComponent<CharController>();
        HUD = GameObject.Find("HUD").GetComponent<Image>();
    }

    public void TakeDamage(float damage)
    {
        if (isDamageable)
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
        isDamageable = false;
        // loop j times
        for (int j = 0; j <= 3; j++)
        {
            // fade out for <> seconds; changing opacity every .05 seconds.
            for (float i = .4f; i >= 0; i -= 0.05f)
            {
                yield return new WaitForSeconds(.01f);
                playerSpriteRenderer.color = new Color(1f, 1f, 1f, i);
            }
            for (float i = .4f; i <= 1; i += 0.05f)
            {
                yield return new WaitForSeconds(.01f);
                playerSpriteRenderer.color = new Color(1f, 1f, 1f, i);
            }        
        }
        isDamageable = true;
    }
}