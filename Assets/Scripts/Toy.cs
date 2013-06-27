using UnityEngine;
using System.Collections;

public class Toy : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision collision)
	{
		string CollidingObject = collision.collider.attachedRigidbody.name;
		
		if(CollidingObject == "Person")
		{
			Material mat = renderer.material;
			Color c = mat.color;
			float r = c.r;
			Color newColor = new Color(Mathf.Min (r + 1.0f/8.0f,1.0f),c.g,c.b,c.a);
			mat.color = newColor;
			
			Instantiate(this,new Vector3(Random.Range(-30f,30f),4,Random.Range(-30f,30f)),Quaternion.identity);
		}
	}
}
