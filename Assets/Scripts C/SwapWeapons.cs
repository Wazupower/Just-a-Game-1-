using UnityEngine;

public class SwapWeapons : MonoBehaviour {

    public GameObject Primary ;						    // arme principale
    public GameObject Secondary ;						// arme secondaire

	// Use this for initialization
	void Start ()
    {
        Primary.SetActive(true);                        // de base arme principale active
        Secondary.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {                                               // si presse 1 du clavier alphabétique
            Primary.SetActive(true);                    // arme principale active
            Secondary.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {                                               // si presse 2 du "" ""
            Primary.SetActive(false);                   // arme secondaire active
            Secondary.SetActive(true);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {                                               // si scroll vers le haut
            Primary.SetActive(true);                    // arme principale active
            Secondary.SetActive(false);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {                                               // si scrolle vers le bas
            Primary.SetActive(false);
            Secondary.SetActive(true);                  // arme secondaire active
        }
    }
}