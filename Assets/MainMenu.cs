using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public string scene_name;											    // nom de la scene
    public int qualityLevel;												// variable pour stocker la valeur de la qualité vidéo de base du jeu
    public Dropdown thedropdown;											// relier au dropdown du menu, récupére sa valeur (0,1,2,...)
    public Slider VolumeSlider;											    // récupére la valuer du slider (entre 0 et 1)
    public float Volume;		                                            // volume

	// Use this for initialization
	void Start ()
    {
        QualitySettings.vSyncCount = 0;                                 // VSync de base désactivée
        EnableVSync();                                                  // check fonction donc vsync activée
        ValueChangeCheck();                                             // appele de la fonction pour récupérer la qualité de basse du jeu
        ChangeVolume();                                                 // permet de récupére la valeur de base du jeu
        qualityLevel = PlayerPrefs.GetInt("quality");                   // chargement des données des options
        QualitySettings.vSyncCount = PlayerPrefs.GetInt("vsync");       //
        Volume = PlayerPrefs.GetFloat("volume");                        //
    }

    public void Bouton_DEVKIT()
    {
        PlayerPrefs.SetInt("quality", qualityLevel);                    // on sauvegarde les options pour les différents scénes
        PlayerPrefs.SetInt("vsync", QualitySettings.vSyncCount);        //
        PlayerPrefs.SetFloat("volume", Volume);                         //
        SceneManager.LoadScene(scene_name);                             // charge la scene
    }

    public void Bouton_Quitter()
    {
        Application.Quit();                                             // quitte
    }

    public void ValueChangeCheck()
    {
        if (thedropdown.value == 0)
        {                                                               // si la premiére valeur du dropdown
            Debug.Log("Option Basse selectionnée");                     // affichage console
            QualitySettings.SetQualityLevel(0);                         // la qualité du niveau actuelle sera la premiére (ici basse)
            qualityLevel = QualitySettings.GetQualityLevel();           // change la qualité de basse du jeu au cas où changement de scéne
        }
        else if (thedropdown.value == 1)
        {                                                               // idem pour deuxiéme valeur
            Debug.Log("Option Moyenne selectionnée");
            QualitySettings.SetQualityLevel(1);
            qualityLevel = QualitySettings.GetQualityLevel();
        }
        else if (thedropdown.value == 2)
        {                                                               // idem pour troisiéme
            Debug.Log("Option Haute selectionnée");
            QualitySettings.SetQualityLevel(2);
            qualityLevel = QualitySettings.GetQualityLevel();
        }
    }

    public void EnableVSync()
    {
        if (QualitySettings.vSyncCount == 0)
        {                                                               // si Vsync non changé alors activé
            QualitySettings.vSyncCount = 1;
            Debug.Log("VSync activé");
        }
        else
        {
            QualitySettings.vSyncCount = 0;                             // sinon désactivée
            Debug.Log("VSync désactivé");
        }
    }

    public void ChangeVolume()
    {
        Volume = VolumeSlider.value;            // le volume est identique à la valuer récupérer sur le slider
    }
}