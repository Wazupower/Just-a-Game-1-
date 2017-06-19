using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public int Timer = 3;                                               // temps
    public GameObject Zone;                                             // Zone d'explosion

	// Use this for initialization
	IEnumerator Start ()
    {
		yield return new WaitForSeconds(Timer);								// attend le Timer
        Appear();                                                           // fonction
		FindObjectOfType<AudioManager> ().Play ("Explosion");				// joue le son
		Destroy (gameObject);	                                            // détruit la zone d'explosion
	}

    void Appear()
    {
        Instantiate(Zone, transform.position, transform.rotation);
        Destroy(gameObject);                                        // Génére la zone d'explosion avec même position et rotation que la grenade puis détruit la zone d'explosion
    }
}