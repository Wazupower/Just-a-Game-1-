using UnityEngine;

public class ZombieAi : MonoBehaviour
{
    public float AttackRepeatTime = 2;                      // temps entre 2 attaque
    public float Damage = 10;                               // dégats
    private Animator anim;                                  // object qui posséde les animations
    public float AttackTime = 1;                            // temps d'attaque
    public PlayerStats playerHealth;                        // accés au fichier PlayerStats
    public Transform prefabs;                               // prefabs zombie
    public Transform player;                                // position du joueur

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;              // player = le gameObject avec le Tag Player
        AttackTime = Time.time;								                        // temps d'attque sera influencer part le temps
        anim = GetComponent<Animator>();                                            // anim relier à l'animator
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;                                                   // défini direction comme vecteur
        float angle = Vector3.Angle(direction, transform.forward);                                                  // défini l'angle de vue
        if (Vector3.Distance(player.position, transform.position) < 100 && angle < 60)                              // si distance < 100 et angle de vue < 60
        {
            direction.y = 0;                                                                                        // bloque la hauteur du zombie
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);    // Rotation vers le joueur
            if (direction.magnitude > 2)                                                                            // si trop loin
            {
                transform.Translate(0, 0, 0.05f);                                                                   // le déplace vers l'avant
                anim.SetBool("isWalking", true);                                                                    // active anim de marche
                anim.SetBool("isAttacking", false);                                                                 // desactive l'anim d'attaque
            }
            else if (Vector3.Distance(player.position, transform.position) < 5 && angle < 60)                       // si distance <5 et angle de vue < 60
            {
                anim.SetBool("isAttacking", true);                                                                  // active l'anim d'attaque
                anim.SetBool("isWalking", false);                                                                   // desactive l'anim de marche
                Debug.Log("The ennemy has attacked");															    // affiche dans la console
                if (Time.time > AttackTime)
                {                                                                                                   // si le temps écoulé est plus grand au temps d'attaque
                    playerHealth.TakeDamage(Damage);                                                                // invoque Takedamage de playerhealth
                    AttackTime = Time.time + AttackRepeatTime;                                                      // Le moments de l'attaque = le temps actuelle + la cadence de frappe
                }
            }
        }
    }
}