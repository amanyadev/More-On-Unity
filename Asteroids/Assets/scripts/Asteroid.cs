using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
	[SerializeField]
	Sprite[] spriteList = new Sprite[3];
	[SerializeField]
	float MinImpulseForce = 3f;
	[SerializeField]
	float MaxImpulseForce = 5f;
	[SerializeField]
	float colliderRadius ;
	public void Initialize(Direction direction, Vector3 location){
	 //Random force to be applied
		//at a given angle
		float angle = 0;
		if(direction == Direction.Up){
		angle = Random.Range(75*Mathf.Deg2Rad,Mathf.Deg2Rad*105);
		}
		if(direction == Direction.Down){
		angle = Random.Range(255*Mathf.Deg2Rad,Mathf.Deg2Rad*285);
		}
		if(direction == Direction.Right){
		angle = Random.Range(-15*Mathf.Deg2Rad,Mathf.Deg2Rad*15);
		}
		if(direction == Direction.Left){
		angle = Random.Range(195*Mathf.Deg2Rad,Mathf.Deg2Rad*165);
		}
		StartMoving(angle);
		GetComponent<Transform>().position = location;
	
	}
	void Start () {
		//Now we add a random sprite
		SpriteRenderer spriterenderer = GetComponent<SpriteRenderer>();
		int spriteNumber = Random.Range(0,3);
		spriterenderer.sprite = spriteList[spriteNumber];
		colliderRadius = GetComponent<CircleCollider2D>().radius;
	}
/// <summary>
/// Sent when an incoming collider makes contact with this object's
/// collider (2D physics only).
/// </summary>
/// <param name="other">The Collision2D data associated with this collision.</param>
void OnCollisionEnter2D(Collision2D other)
{	AudioManager.Play(AudioClipName.AsteroidHit);
	Vector3 localScale = transform.localScale;
	localScale /=2;
	transform.localScale = localScale;
	if(localScale.x<.5){
		Destroy(gameObject);
	}
	else{
		colliderRadius /=2;
		GameObject aster1 = Instantiate(gameObject);
		aster1.GetComponent<Asteroid>().StartMoving(Random.Range(0f,2*Mathf.PI));
		GameObject aster2 = Instantiate(gameObject);
		aster2.GetComponent<Asteroid>().StartMoving(Random.Range(0f,2*Mathf.PI));
		Destroy(gameObject);
		}
}
public void StartMoving(float angle){

	Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
		float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
		//get component and add force to the component
		GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, mode: ForceMode2D.Impulse);
}
	
}
