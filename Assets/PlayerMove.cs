using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour {
	[SerializeField]
	private float speed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<SpriteRenderer>().color = Color.red;
	}

	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
			return;

		Camera.main.transform.position = new Vector3 (transform.position.x, transform.position.y, -10.0f);

		if (Input.GetMouseButton (0)) {
			var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var dir = new Vector3 (mousePos.x - transform.position.x, mousePos.y - transform.position.y);
			GetComponent<Rigidbody2D> ().velocity = dir.normalized * speed;
		} else {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}
	}

}
