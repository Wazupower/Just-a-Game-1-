using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;                                                  // son
	public static AudioManager instance;                                    // cas actuelle

	// Use this for initialization
	void Awake ()
    {
		if (instance == null)                                               // si pas de son
			instance = this;                                                // = this
		else {
			Destroy (gameObject);                                           // sinon détruit le son
			return;
		}

		DontDestroyOnLoad (gameObject);                                     // ne détruit ou coupe pas les son en chargement des scene
		foreach (Sound s in sounds)
        {                                       // pour chaque son
			s.source = gameObject.AddComponent<AudioSource> ();             // stock la source
			s.source.clip = s.clip;                                         // le son
			s.source.volume = s.volume;                                     // le volume
			s.source.pitch = s.pitch;                                       // le ton
			s.source.loop = s.loop;                                         // la répétition
		}
	}
	
	public void Play (string name)                                          // variable string
	{
		Sound s = Array.Find (sounds, Sound => Sound.name == name);         // on stock dans la même variable toutes les données
		if (s == null) {                                                    // si s null
			Debug.LogWarning ("Sound : " + name + "not found");             // message console
		}
		s.source.Play ();                                                   // joue le son
	}
}