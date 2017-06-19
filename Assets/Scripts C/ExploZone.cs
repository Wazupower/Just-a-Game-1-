using System.Collections;
using UnityEngine;

public class ExploZone : MonoBehaviour {

    public int Timer = 3;                                                       // temps
    public int damageGrenade = 150;                                             // dégats

	// Use this for initialization
	IEnumerator Start ()
    {                   
        yield return new WaitForSeconds(Timer);                                 // attend le Timer
        Destroy(gameObject);                                                    // détruit l'object  
    }

    void OnTriggerEnter(Collider hit)                                           // si rentre en collision
    {
        if (hit.gameObject.tag == "zombie")                                     // avec un zombie
        {
            TargetHealth Ennemi = hit.transform.GetComponent<TargetHealth>();   // stock les PV du zombies
            if (Ennemi != null)                                                 // si collison avec zombie
            {
                Ennemi.TakeDamage(damageGrenade);                               // zombie prends les dégats de la grenade
            }
        }
    }
}