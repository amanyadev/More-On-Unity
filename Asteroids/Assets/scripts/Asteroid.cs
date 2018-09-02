using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
	[SerializeField]
	Sprite[] spriteList = new Sprite[3];
	
	void Start () {
		//Random force to be applied
		const float MinImpulseForce = 3f;
		const float MaxImpulseForce = 5f;
		//at a given angle
		float angle = Random.Range(0, 2 * Mathf.PI);
		Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
		float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
		//get component and add force to the component
		GetComponent<Rigidbody2D>().AddForce(direction * magnitude, mode: ForceMode2D.Impulse);
		//Now we add a random sprite
		SpriteRenderer spriterenderer = GetComponent<SpriteRenderer>();
		int spriteNumber = Random.Range(0,3);
		spriterenderer.sprite = spriteList[spriteNumber];
	}

	
}
