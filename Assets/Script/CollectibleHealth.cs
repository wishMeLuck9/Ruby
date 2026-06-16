using UnityEngine;

public class CollectibleHealth : MonoBehaviour
{
    public int healthAmount = 1;
    bool collected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"TRIGGER fruta={name}, other={other.name}, collected={collected}, amount={healthAmount}");

        if (collected)
            return;

        RubyControler controller = other.GetComponent<RubyControler>();

        if (controller != null && controller.currentHealth < controller.maxHealth)
        {
            collected = true;

            Debug.Log($"A personagem ganhou {healthAmount} ponto(s) de vida ao tocar na fruta");

            controller.ChangeHealth(healthAmount);

            gameObject.SetActive(false);

            Destroy(gameObject, 0.1f);
        }
    }
}
