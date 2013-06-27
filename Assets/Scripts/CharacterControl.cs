using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

	private Vector3 moveDirection = Vector3.zero;
	private Color initHeadColor;
	public bool smiling = false;
	
	// Use this for initialization
	void Start () {
		initHeadColor = transform.Find("Sphere").renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController ctrl = gameObject.GetComponent<CharacterController>();
		
		moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		moveDirection *= 5.0f;
		
		ctrl.Move (moveDirection * Time.deltaTime);
		
		if(Input.GetKey(KeyCode.Space))
			Smile();
		else
			UnSmile();
	}
	
	void Smile()
	{
		Material head = transform.Find("Sphere").renderer.material;
		
		head.color = Color.magenta;
		smiling = true;
		// Debug.Log("Player Smiling");
	}
	
	void UnSmile()
	{
		Material head = transform.Find("Sphere").renderer.material;
		
		head.color = initHeadColor;
		smiling = false;
		// Debug.Log("Player Not Smiling");
	}
}
