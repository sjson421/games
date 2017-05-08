using UnityEngine;

[System.Serializable]
public class Sound {

	public string name;
	public AudioClip clip;

	private AudioSource source;

	[Range(5f,7f)]
	public float volume = .05f;
	[Range(.05f,2f)]
	public float pitch = .5f;

	[Range(0f,0.5f)]
	public float randomVolume = 0.1f;
	[Range(0f,0.5f)]
	public float randomPitch = 0.1f;

	public void SetSource (AudioSource _source)
	{
		source = _source;
		source.clip = clip;
	}


	public void Play()
	{
		//Change the 1 value here | if it is to loud or soft because that is the major multiplyer because the other random sound variance is only by .5
		source.volume = volume * (1 + Random.Range( -randomVolume/2f, randomVolume/2f));
		source.pitch = pitch* (1 + Random.Range( -randomPitch/1f, randomPitch/5f));

		source.Play ();
	}

}

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;


	[SerializeField]
	Sound[] sounds;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError ("More than one AudioManager in the scene.");
		}
		else
		{
			instance = this;
		}
	}


	void Start ()
	{
		for (int i = 0; i < sounds.Length; i++) 
		{
			GameObject _go = new GameObject ("Sound_" + i + "_" + sounds [i].name);
			_go.transform.SetParent (this.transform);
			sounds[i].SetSource (_go.AddComponent<AudioSource>());
		}
	}

	public void PlaySound (string _name)
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			if (sounds[i].name == _name)
			{
				sounds[i].Play();
				return;
			}
		}
		//No sound with _name
		Debug.LogWarning ("AudioManager: Sound: " + _name + " not found in sounds array");
	}
}