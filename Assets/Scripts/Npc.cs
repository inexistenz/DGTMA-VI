using UnityEngine;
using System.Collections;

public class Npc : MonoBehaviour {
	
	private Color initHeadColor;
	private bool smiling;
	private float cooldownTime = 5.0f;
	
	// Use this for initialization
	void Start () {
		initHeadColor = this.gameObject.transform.Find("Sphere").renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		if(smiling)
		{
			cooldownTime -= Time.deltaTime;
			cooldownTime = Mathf.Max(cooldownTime, 0.0f);
			GameObject player = GameObject.Find ("Person");
			CharacterControl playerCtrl = player.GetComponent<CharacterControl>();
			if(playerCtrl.smiling && cooldownTime <= 0.0f)
			{
				Instantiate (this,
					new Vector3(transform.position.x + 4.0f, transform.position.y, transform.position.z),
					Quaternion.identity);
				cooldownTime = 5.0f;
			}
		}
	
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if(collider.name == "Person")
		{
			Smile();
		}
	}
	
	
	
	void OnTriggerExit(Collider collider)
	{
		if(collider.name == "Person")
		{
			UnSmile();
		}
	}
	
	void Smile()
	{
		Material head = this.gameObject.transform.Find("Sphere").renderer.material;
		
		head.color = Color.magenta;
		smiling = true;
		// Debug.Log("Smiling");
	}
	
	void UnSmile()
	{
		Material head = this.gameObject.transform.Find("Sphere").renderer.material;
		
		head.color = initHeadColor;
		smiling = false;
		// Debug.Log("Not Smiling");
	}
}
