using UnityEngine;
using UnityEngine.UI;									// permet le controle du UI à partir du scprit

public class PlayerStats : MonoBehaviour {

	public Image healthBar;									// texture Barre de vie

	public int Grenades = 4;								// nombre de grenades sur le joueur

	public float health  = 100;								// vie actuelle du joueur
	public float healthMax = 100;							// vie maximale du joueur
	public float regenerationTime = 0;						// temps avant regen

	public GameObject BloodUI;								// texture ScreenBlood

    // Use this for initialization
    void Start ()
    {
		health = healthMax;									// de base points de vie actueel = points de vie max
		InvokeRepeating("Regeneration",0,5);				// invoque Regeneration au bout de 0s toutes les 5s
	}
	
	// Update is called once per frame
	void Update ()
    {
		healthBar.fillAmount = health/healthMax;			// Barre de vie se videra en fonction du nombre de points de vie sur les points de vie max
		BloodUI.GetComponent<CanvasGroup>().alpha = 1 - health/healthMax;		// différent pallier de point de vie qui change l'opacité de la texture (0 à 1)
		if(health > 100){									// points de vie max 100
			health = 100;
		}
		if(regenerationTime > 10){							// temps avant regen max 10s
			regenerationTime = 10;
		}
		if(regenerationTime < 0){							// tempds avant regen min 0s
			regenerationTime = 0;
		}
	}

    public void TakeDamage(float amount)
    {
        health -= amount;                                   // health - dégats
        regenerationTime += 2.5f;                           // regen + 2.5
		Debug.Log("The player take damage");				// message console
		if(health <= 0)                                     // si health <= 0
		{
        Debug.Log("Player died");							// message dans la console
        }
    }

	void Regeneration()
    {
		regenerationTime -= 5;							    // réduit le regenreationTimrr de 0.5s
		if (regenerationTime <= 0)                          // si temps de regen <= 0
        { 
			health ++;                                      // health ++
	    }
    }
}