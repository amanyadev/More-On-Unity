using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	[SerializeField]
	float magnitude;
	Timer t;
private void Start() {
	t = gameObject.AddComponent<Timer>();
	t.Duration = 2;
	t.Run();
}
private void Update() {
	if(t.Finished){
		Destroy(gameObject);
	}
}
	public void ApplyForce(Vector2 forceDirection){
		GetComponent<Rigidbody2D>().AddForce(magnitude*forceDirection,ForceMode2D.Impulse);
	}
	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag =="Asteroid"){
			Destroy(gameObject);
		}
	}
	
}
