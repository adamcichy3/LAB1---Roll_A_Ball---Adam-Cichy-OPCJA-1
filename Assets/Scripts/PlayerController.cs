using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {

	public float speed;
	private int count;
	private Rigidbody rb;
	public Text countText;
	public Text winText;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count += 1;
			SetCountText ();
		}
		if (other.gameObject.CompareTag ("Pick Up1")) 
		{
			other.gameObject.SetActive (false);
			count += 3;
			SetCountText ();
		}

	}

	void SetCountText()
	{
		countText.text = "WYNIK: " + count.ToString();
		if (count >= 9) 
		{
			winText.text = "WYGRAŁEŚ! KONIEC GRY" ;
		}
	}
}