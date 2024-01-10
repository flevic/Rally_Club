using UnityEngine;
using UnityEngine.Audio;

public class SaveManager : MonoBehaviour
{
	public GameData data;
	
	public static SaveManager instance;

	private void Awake()
	{
		instance = this;
	}
}