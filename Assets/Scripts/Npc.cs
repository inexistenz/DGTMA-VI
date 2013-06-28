using UnityEngine;
using System.Collections;

public class Npc : MonoBehaviour {
	
	public Color initHeadColor;
	public bool smiling;
	public float cooldownTime = 5.0f;
	
	public GameObject npc;
	public GameObject head;
	
	
	// Use this for initialization
	void Start () {
		initHeadColor = new Color(0.745098f,0.745098f,0.745098f,1);
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
				Instantiate (npc,
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
		Material mat = head.renderer.material;
		
		mat.color = Color.magenta;
		smiling = true;
		// Debug.Log("Smiling");
	}
	
	void UnSmile()
	{
		Material mat = head.renderer.material;
		
		mat.color = initHeadColor;
		smiling = false;
		// Debug.Log("Not Smiling");
	}
}
