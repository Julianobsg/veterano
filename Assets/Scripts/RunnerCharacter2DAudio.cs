using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(RunnerCharacter2D))]
public class RunnerCharacter2DAudio : MonoBehaviour
{
    private RunnerCharacter2D rc2D;
    [SerializeField]
    private List<AudioClip> runningStep;
    [SerializeField]
    private List<AudioClip> landing;
    private AudioSource source;
    private bool ground;

	void Start () 
    {
        rc2D = GetComponent<RunnerCharacter2D>();
        source = GetComponent<AudioSource>();
        ground = false;
	}
	
	void Update () 
    {

        if (rc2D.IsRunning && rc2D.IsGrounded && !source.isPlaying)
        {
            if (runningStep.Count > 0)
            {
                int range = Random.Range(0, runningStep.Count - 1);
                source.clip = runningStep[range];
                source.Play();
            }
        }
        if (!ground && rc2D.IsGrounded && !source.isPlaying)
        {
            if (landing.Count > 0)
            {
                int range = Random.Range(0, landing.Count - 1);
                source.clip = landing[range];
                source.Play();
            }
        }

        ground = rc2D.IsGrounded;
	}
}
