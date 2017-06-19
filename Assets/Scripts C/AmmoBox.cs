using UnityEngine;

public class AmmoBox : MonoBehaviour {

	public int ammo = 120;																							// 120 balles à l'intérieur de la boite à munitions

	public WeaponStats Stats;																	                    // stats devient une addresse à WeaponsStats
	public bool showGUI = false;																			        // showGUI est un bouléen

	// Update is called once per frame
	void Update ()
    {
		if(showGUI == true){                                                                                        // si show gui vrai
			if(Input.GetKeyDown("e")){																				// et si presse E
				Stats.Stock += ammo;																		        // Stock du fichier weaponsstats augmente de ammo valeur
				Destroy(gameObject);																				// détruit la boite de munitions
			}
		}
	}
	void OnGUI()
    {
		if(showGUI == true){																						// Si showGUI vrai
			GUI.Box(new Rect(Screen.width/2-100,Screen.height/2-10,200,20), "Press E to pickup ammo");				// GUI sera un rectangle à mi-Hauteur et mi-longueur de l'écran avec la taille sur 2 (pour centrer)
		}																											// de taille 200 par 25 et le texte afficher
	}

	void OnTriggerEnter(Collider hit)
    {																		                                        // Si le "Player" entre dans la boite de collsiion
		if(hit.gameObject.tag == "Player")
        {																			                                // showGUI Fvrai
			showGUI = true;
		}
	}

	void OnTriggerExit(Collider hit)
    {
		if(hit.gameObject.tag == "Player"){																			// Si le joueur sort de la zone
			showGUI = false;																						// showGUI faux
		}
	}
}