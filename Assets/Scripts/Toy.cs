using UnityEngine;
using System.Collections;

public class Toy : MonoBehaviour {
	
	public GameObject toy;
	public static float size = 1.0f;
	public Vector3 initPosition;
	
	// Use this for initialization
	void Start () {
		transform.localScale *= size;
		initPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -30.0f)
			transform.position = initPosition;
	}
	
	void OnCollisionEnter(Collision collision)
	{
		string CollidingObject = collision.gameObject.name;
		
		if(CollidingObject == "Person")
		{
			Brighten();
			size += 0.1f;
			size = Mathf.Min (size,4.0f);
			transform.localScale *= size;
			Instantiate(toy,new Vector3(Random.Range(-30f,30f),4 * size,Random.Range(-30f,30f)),Quaternion.identity);
		}
	}
	
	void Brighten()
	{
		Material mat = renderer.material;
		Color c = mat.color;
		float r = c.r;
		Color newColor = new Color(Mathf.Min (r + 1.0f/8.0f,1.0f),c.g,c.b,c.a);
		mat.color = newColor;
	}
}
