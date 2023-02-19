using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class var_Player : ScriptableObject
{
	public Transform transform;
	public int currentScore;
	public int bestScore;
	public bool isSoundFly = false;
	public bool isDetected = false;
	public bool isChange = false;
}
