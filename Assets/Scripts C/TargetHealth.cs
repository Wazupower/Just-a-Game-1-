using UnityEngine;

public class TargetHealth : MonoBehaviour {

	public float health = 100;                                              // point de vie
    private Animator anim;                                                  // animation

    private void Start()
    {
        anim = GetComponent<Animator>();                                    // anim = l'animation
        this.GetComponent<CapsuleCollider>().enabled = true;                // Capsule collider activer
        this.GetComponent <CharacterController>().enabled = true;           // et Character activer
    }

    public void TakeDamage(float amount)
	{
		health -= amount;                                                   // health - dégats
		Debug.Log("The ennemy take damage");								// message console
		if(health <= 0)                                                     // si health <= 0
		{
			Die();                                                          // fonction
		}
	}

	void Die()
	{
        Debug.Log("Zombie Die");                                            // message console
        anim.SetBool("isDead", true);                                       // joue l'anim de mort
        GetComponent <ZombieAi> ().enabled = false;                         // desactive l'ai du zombie
        this.GetComponent<CapsuleCollider>().enabled = false;               // desactive capsule collider
        this.GetComponent<CharacterController>().enabled = false;           // desactive le charcacter controller
        Destroy(gameObject, 5);                                             // détruit le zombie aprés 5 sec
    }
}