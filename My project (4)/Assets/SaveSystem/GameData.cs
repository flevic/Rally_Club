using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
	//YOU CAN STORE ANYTHING: floats, integers, lists of bools lists of integers, even custom classes and stuff

	//Controls
	public float MouseSensitivity = 1.5f;
	public int currentSaveSlot;
	//Audio
	public float MasterVol = -15f;
	public float SfxVol = 0f;
	public float MusicVol = 0f;
	public float SpeechVol = 0f;

	public Dictionary<string, bool> levelsDone = new Dictionary<string, bool>()
	{
        {"LevelPicker", true},
        {"Level1", false},
		{"Level2", false},
        {"Level3", false},
        {"Level4", false}
    };
}