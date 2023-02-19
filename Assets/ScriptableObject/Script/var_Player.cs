using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class var_Player : ScriptableObject
{
	public Transform transform;
	public float force = 100;
	public float gravity = 2;
	public int currentScore = 0;
	public int bestScore;
	public bool isSoundFly = false;
	public bool isDetected = false;
	public bool isChange = false;
}
