using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyControler controler = other.GetComponent<RubyControler>();
        
        if (controler != null)
        {
            controler.ChangeHealth(-1);
        }
    }
    
       
}
