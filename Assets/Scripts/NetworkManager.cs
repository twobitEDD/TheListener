using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	public ThirdPersonCamera camera;
	public GameObject humanPrefab;
	public Vector3 spawnPoint;
	public bool host = true;
	
	const int port = 6112;
	
	void Start () {
		ConnectToServer("127.0.0.1");
	}
	
	public void HostServer () {
		Network.InitializeServer(8, port, false);
		Debug.Log("Hosting");
	}
	
	public void ConnectToServer (string host) {
		Network.Connect(host, port);
	}
	
	void OnFailedToConnect (NetworkConnectionError error) {
		Debug.Log(error);
		HostServer();
	}
	
	void OnPlayerConnected (NetworkPlayer player) {
		Debug.Log(player.ipAddress +" connected");
		Network.Instantiate(humanPrefab, spawnPoint, Quaternion.identity, 0);
	}
	
	void OnPlayerDisconnected (NetworkPlayer player) {
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
		Debug.Log(player.ipAddress +" disconnected");
	}
	
}
