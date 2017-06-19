using UnityEngine;

public class Throw : MonoBehaviour {

    public PlayerStats playerstats;														// variable accédant aux varaible du fichier Playerstats
    public Rigidbody GrenadeCasing;														// prefabs des grenades
    int ejectSpeed = 15;																// vitesse des grenades lancés
	
	// Update is called once per frame
	void Update ()
    {
        if (playerstats.Grenades >= 1)
        {                                                                                            // si le joueur à au moins une grenades
            if (Input.GetKeyDown("g"))
            {                                                                                       // et si presse G
                Rigidbody Grenade ;                                                                 // grenade physiquement là
                Grenade = Instantiate(GrenadeCasing, transform.position, transform.rotation);       // Génére la grenades avec la même position et rotation du grenadecasing (zone un peux devant le joueur)
                Grenade.velocity = transform.TransformDirection(Vector3.forward * ejectSpeed);      // vitesse de la grenade = même direction * vitesse des grenades (sens vers l'avant)
                playerstats.Grenades -= 1;                                                          // le joueur perd une grenades
            }
        }
    }
}