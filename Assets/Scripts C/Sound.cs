using UnityEngine;

[System.Serializable]                           // permet de lister avec des propriété secondaire
public class Sound {                            // créer la classe Sound
	public string name;                         // nom
	public AudioClip clip;                      // le son
	[Range(0f,1f)]
	public float volume;                        // volume
	[Range(.1f, 3f)]
	public float pitch;                         // ton
	[HideInInspector]
	public AudioSource source;                  // source
	public bool loop;                           // répétition
}