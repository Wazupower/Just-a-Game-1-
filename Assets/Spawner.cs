using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform[] Spawners;								// liste des spawners
    public GameObject[] CurrentZombies;                         // liste les zombies(Gameobject) actuellement present 
    public Transform Zombie;							        // prefabs du zombie
    public int AliveZombies;									// nombre de zombie en vie
    public int LeftAmount;									    // nbre de zombies qui reste à faire apparaitre
    public int LastRoundAmount;								    // nbre de zombie de la manche précédente
    public int StartAmount;									    // nbre de zombie au début de la manche
    public int CurrentRound;									// manche actuelle
    public int Multiplicateur;								    // nbre qui multiplie le nombre de zombie de la manche précédente
    public float Delay;                                         // tempds de spawn
   

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawning", 0, Delay);                  // invoque sans cesse Spawning au bout de 0s tout les delays
    }

    // Update is called once per frame
    void Update()
    {
        CurrentZombies = GameObject.FindGameObjectsWithTag("zombie");       // recherche tous les zombie
        AliveZombies = CurrentZombies.Length -1;                            // Calcul le nombre de zombie dans la liste
        if (CurrentRound == 0)
        {                                                                   // si manche 0
            LastRoundAmount = StartAmount;                                  // nbre de zombie manche precedente = nbre zombie actuel
            LeftAmount = StartAmount;                                       // nbre de zombie qui reste a faire spawn = nbre de zombie au début de manche
            CurrentRound++;                                                 // manche + 1
        }
    }

    void Spawning()
    {
        if (LeftAmount > 0)
        {                                                                                               // tant qu'il reste des zombie a faire spawn
            int RandomNumber  = Random.Range(0, Spawners.Length);                                       // génére un nbre aléatoire entre 0 et le nombre de spawn
            Transform RandomTransform = Spawners[RandomNumber];                                         // fait spawn un zombie sur ce spawners choisi aléatoirement
            Instantiate(Zombie, RandomTransform.transform.position, Quaternion.identity);               // Créer le zombie sur ce spawner avec la même postiotn et rotation
            LeftAmount--;                                                                               // nbre de zombie a faire spawn -1
        }
        if (CurrentZombies.Length == 1)
        {                                                                                               // si il ne reste plus de zombie (sauf le modéles)
            if (CurrentRound != 0 && LeftAmount == 0)
            {                                                                                           // si manche différent de 0 et qu'il ne reste plus de zombie a faire spawn
                LeftAmount = LastRoundAmount * Multiplicateur;                                          // nbre de zombie a faire spawn = le nbre de zombie la manche précédente * un multiplicateur
                LastRoundAmount = LeftAmount;                                                           // nbre de zombie de la manche precedente = nbre de zombie a faire spawn
                CurrentRound++;                                                                         // manche + 1
            }
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 45, 130, 25), AliveZombies + " Zombies");                                  // affiche le nombre de zombie en vie dans une boite rectangulaire en position 10 vers la gauche,
        GUI.Box(new Rect(10, 80, 130, 25), CurrentRound + " Manches");                                  // 55 pixels vers le basdu coin haut-gauche
    }
}                                          