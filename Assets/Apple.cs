using UnityEngine;
using UnityEngine.Networking;

public class Apple : NetworkBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (isServer)
			RpcRespawn ();
	}

	[ClientRpc]
	void RpcRespawn()
	{
		if (isServer)
		{
			Camera cam = Camera.main;
			transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
		}
	}
}
