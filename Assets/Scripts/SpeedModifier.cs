using UnityEngine;
using System.Collections;

public class SpeedModifier : MonoBehaviour 
{
    private RunnerCharacter2D character;
    [SerializeField]
    private float ammount;
    public void OnTriggerEnter2D(Collider2D other)
    {
        character = other.GetComponent<RunnerCharacter2D>();
        if (character)
        {
            character.MaxSpeed -= ammount;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (character)
        {
            character.MaxSpeed += ammount;
        }
    }
}
