using UnityEngine;

public class WeaponStats : MonoBehaviour {

	public float damage = 10;                                   // dégats
	public float range = 100;                                   // portée
	public Camera fpsCam;                                       // caméra
	public float fireRateAuto; 									// cadence de tir en automatique(temps en secomdes entre chaque tir)
	public float fireRateSemi;									// cadence de tir en SemiAutomatique
	private float nextFire = 0;							        // temps entre 2 tirs

	public int Clip = 30;										// chargeur actuelle
	public int FullClip  = 30;									// chargeur plein
	public int Stock = 180;										// stock munitions

	public bool MunMax;										    // Chargeur plein ou non
	public bool Automatic = true;							    // arme automatique ou non

	public GameObject FireShot;									// permet de stocker la particule de tir
	public GameObject impactEffect;                             // stock particule d'impact

	public GameObject Animations;								// object qui posséde les animations
	public bool IsReloading = false;							// entrain de recharger ou non
	public float DelayReload = 1;								// temps de rechargement
	public Animator anim;                                       // stock les animations
	public Aiming Aiming;                                       // accés au fichier Aiming

    // Update is called once per frame

    void Update ()
    {
		if(Input.GetKeyDown("v"))
        {                                                                                           // si presse V Change le mode de tir (automatique ou semi)
            Automatic = !Automatic;
		}
		if (Input.GetButton ("Fire1") && Time.time > nextFire && IsReloading == false && Aiming.isAiming == false) {    // si clique-gauche et le temps est plus grand que la cadence de tir et qu'il ne recharge pas et ne vise pas
			if (Clip >= 1) {																			                // si chargeur non-vide (au-moins 1 balle dedans)
				if (Automatic == true) {																                // si arme en Auto
					nextFire = Time.time + fireRateAuto;											                    // le prochain tire = temps tir précédent + cadence de tir en Auto
				} else {																				                // sinon
					nextFire = Time.time + fireRateSemi;											                    // le prochain tire = temps tir précédent + cadence de tir en Semi
				}
				Shoot ();                                                                                               // fonction Shoot
				Clip -= 1;																			                    // - 1 balles
				FindObjectOfType<AudioManager> ().Play ("Shot");                                                        // joue le son Shot
				GameObject clone = Instantiate (FireShot, transform.position, transform.rotation);						// fait apparaitre la particule FireShot à la même position et rotation que le joueur
				anim.Play ("Shot", -1, 0);							                                                    // joue l'animation Shot
                Destroy(clone,0.1f);                                                                                    // détruit la particule
			}
		}
		if (Input.GetButton ("Fire1") && Time.time > nextFire && IsReloading == false && Aiming.isAiming == true)       // si clique gauche, temps > cadence, pas entrain de recharger et entrain de viser
        {
            if (Clip >= 1)
            {                                                                                                           // si chargeur non-vide (au-moins 1 balle dedans)
                if (Automatic == true)
                {                                                                                                       // si arme en Auto
                    nextFire = Time.time + fireRateAuto;                                                                // le prochain tire = temps tir précédent + cadence de tir en Auto
                }
                else
                {                                                                                                       // sinon
                    nextFire = Time.time + fireRateSemi;                                                                // le prochain tire = temps tir précédent + cadence de tir en Semi
                }
                Shoot();                                                                                                // fonction SHoot
                Clip -= 1;                                                                                              // - 1 balles
                FindObjectOfType<AudioManager>().Play("Shot");                                                          // joue le son shot
                GameObject clone = Instantiate(FireShot, transform.position, transform.rotation);                       // fait apparaitre la particule FireShot à la même position et rotation que le joueur
                anim.Play("ShotAiming", -1, 0f);                                                                        // joue l'animation Shot
                Destroy(clone, 0.1f);                                                                                   // détruit la particule
            }
	    }
		
		if(Clip == FullClip)
        {																		// si le chargeur actuel = au chargeur plein, alors le chargeur actuel est plein
			MunMax = true;
		}else{
			MunMax = false;
		}
		if(Input.GetKeyDown("r") && IsReloading == false && Stock >= 1 && MunMax == false){			// si presse R et qu'il reste des munitions dans le stock											
			Reload();																				// fonction
		}
		if(Stock >= 1 && Clip == 0 && IsReloading == false){										// si le stock est pas vide et charger vide et qu'on ai pas entrain de recharger alors rechage
			Reload();
		}
	}

	void Reload()
    {
		IsReloading = true;																			// entrain de recharger	
		FindObjectOfType<AudioManager> ().Play ("Reload");								            // et joue le son de rechargement
		anim.Play("Reload",-1 , 0);							                                        // joue l'naimation Reload
        Debug.Log("Has reload");                                                                    // message console
		//yield return new WaitForSeconds(DelayReload);												// attend le temps de rechargement
		if(Stock + Clip < FullClip){																// et que le chargeur actuel + le stock restant est plus petit qu'un chargeur plein
			Clip = Clip + Stock;																	// alors chargeur actuel devient le chargeur actuel + le restan du stock
			Stock = 0;																				// alors vide le stock
		}else{
			RemoveStock();																			// sinon enleve le nombre de balles corespondante au stock--- voire fonction RemoveStock
			Clip += FullClip - Clip;																// et chargeur actuel gagne les balles manquante pour devenir un chargeur plein
		}
		IsReloading = false;																		// fini de recharger
	}
	void Shoot()
	{
		RaycastHit hit;                                                                             // hit est un raycast
		if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))    // si raycast même position et rotation que la Cam de portée range
		{
			Debug.Log(hit.transform.name);                                                          // message console qui affiche se que l'on touche
			TargetHealth Ennemi = hit.transform.GetComponent <TargetHealth> ();                     // Ennemi accéde à targethealth
			if (Ennemi != null)                                                                     // si ennemi touché
			{
				Ennemi.TakeDamage(damage);                                                          // ennemi prends des dégats
			}
			GameObject clone = Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));            // génére la particule de l'impact au points d'impact avec la rotaion perpendiculaire de la surface touché
            Destroy(clone, 0.1f);                                                                                    // détruit la particule
        }
	}
	void RemoveStock()
    {
		Stock -= FullClip - Clip;																	// le stock de munitions se vide du nombre de balle manquant au chargeur actuel pour devenir plein
	}
	void OnGUI()
    {
		GUI.Box(new Rect(10,10,130,25), Clip + " / " + Stock);										// affiche une interface boite de forme rectangulaire en position 10, 10 pixels du coin haut-gauche
	}																							    // de taille 130 par 25 pixel montrant le nombre de balles dans le chargeur actuelle sur les munitions dans le stock
}