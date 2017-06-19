using UnityEngine;

public class Aiming : MonoBehaviour {

	public Vector3 NormalPos;												// position quand on vise pas
	public Vector3 AimPos;													// position quand on vise
	public GameObject reticle;												// texture reticule
	public WeaponStats WeaponShot;										    // accés au script WeaponsStats
	public Animator animator;                                               // accés à l'animator
	public bool isAiming = false;                                           // booléen faux, pas entrain de viser
	// Use this for initialization
	void Start ()
    {
		transform.localPosition = NormalPos;                                // position de base = normal pos
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown ("Fire2") && WeaponShot.IsReloading == false){	// quand clique gauche et arme pas entrain de recharger
			transform.localPosition = AimPos;								    // change la position de l'arme en position de Aim
			reticle.SetActive (false);										    // désactive le réticule
			animator.Play ("StartAiming",-1,0);                                 // joue l'anim commence à viser
			isAiming = true;                                                    // est entrain de viser
		}else if(Input.GetButtonUp("Fire2")){                                   // si relache le clique droit
			animator.Play("EndAiming",-1,0);                                    // joue n'anim arrete de viser
            reticle.SetActive(true);                                            // active le réticule
			transform.localPosition = NormalPos;                                // change la position en normal position
			isAiming = false;                                                   // plus entrain de viser
		}
	}
}