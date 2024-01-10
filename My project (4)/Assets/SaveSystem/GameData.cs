using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
	//YOU CAN STORE ANYTHING: floats, integers, lists of bools lists of integers, even custom classes and stuff
	
	//Controls
	public float MouseSensitivity = 1.5f;

	//Audio
	public float MasterVol = -15f;
	public float SfxVol = 0f;
	public float MusicVol = 0f;
	public float SpeechVol = 0f;

	//Video
	public int fov = 120;
	
	//IsWeaponUnlocked by index
	public List<bool> weaponStatus = new List<bool>
	{
		false,
		false,
		false,
		false,
		false,
		false,
		false,
		false,
		false,
		false,
		false,
		false,
		false,
		false,
		false,
		false,
		false,
		false
	};
	
	public List<int> equippedVariants = new List<int>
	{
		0,
		0,
		0,
		0
	};
}