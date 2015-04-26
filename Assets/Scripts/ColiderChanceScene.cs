using UnityEngine;
using System.Collections;

public class ColiderChanceScene : MonoBehaviour {

		public string levelName;
		public void OnTriggerStay2D(Collider2D other)
		{
			MoveToCharacter2D moveToCharacter = other.GetComponent<MoveToCharacter2D>();
			if (moveToCharacter)
			{
				if (!moveToCharacter.IsMoving)
				{
					Application.LoadLevel(levelName);
				}
			}
		}
	}