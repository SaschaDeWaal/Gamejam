using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour 
{
	public PlayerControll player;
	private Animator anim;
	
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	void Update () 
	{
		anim.SetBool("moving", player.Moving);
		anim.SetBool("GUNSOUT", player.Guns);
	}
}
