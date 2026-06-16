using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class RubyControler : MonoBehaviour
{
    // Variaveis relacionados com invincibilidade
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;

    public int health { get { return currentHealth; } }

    public int maxHealth = 5;
    public int currentHealth;

    Rigidbody2D rigidbody2D;

    public float velocidade = 10;

    public InputAction MoveAction;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 10;

        MoveAction.Enable();

        rigidbody2D = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        Vector2 position = transform.position;

        position += direction * velocidade * Time.deltaTime;

        transform.position = position;

        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;

            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        Debug.Log($" ANTES: {currentHealth}/{maxHealth} Personagem perdeu:{amount} ponto de vida");
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        Debug.Log($"Depois: {currentHealth}/{maxHealth}");

        UI_Handler.instance.SetHealthValue(currentHealth / (float)maxHealth);

       

        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }

            isInvincible = true;
            damageCooldown = timeInvincible;
        }
    }
}