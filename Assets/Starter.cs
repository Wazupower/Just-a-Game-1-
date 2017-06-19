using UnityEngine;

public class Starter : MonoBehaviour {

    public AudioSource[] AllAudioSource ;									            // liste de toutes les source Audio

    void Awake()
    {
        AllAudioSource = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];		// recherche toutes les Sources Audios                                                        // function qui se lance avant la fonction Start
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));                 // charge les options de qualités
        QualitySettings.vSyncCount = (PlayerPrefs.GetInt("vsync"));                     // charge les options du vsync

        SetVolume();                                                                    // fonction
    }

    // Use this for initialization
    void Start ()
    {
        Debug.Log("Qualité du jeu : " + PlayerPrefs.GetInt("quality") + "/2");          // affichage console
        Debug.Log("Etat de la VSync : " + QualitySettings.vSyncCount);                  //
        Debug.Log("Volume du jeu : " + PlayerPrefs.GetFloat("volume") * 100 + "/100");  //
    }

    // Update is called once per frame
    void SetVolume()
    {
        foreach (AudioSource Audio in AllAudioSource)
        {                                                                               // boucles qui change les volume de tout les audiosources
            Audio.volume = (PlayerPrefs.GetFloat("volume"));
        }
    }
}