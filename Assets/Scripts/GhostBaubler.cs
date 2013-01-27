using UnityEngine;

public class GhostBaubler : MonoBehaviour {
	public GameObject bauble;
	public float radius;
	public int count;
	public float scaleMax;
	public float scaleMin;
	
	void Start () {
		for (var n = 0; n < count; n++) {
			var b = Instantiate(bauble) as GameObject;
			var q = Random.rotation;
			var d = Random.Range(0f, radius);
			b.transform.position = q * Vector3.forward * d;
			b.transform.localScale *= Random.Range(scaleMin, scaleMax);
			var c = b.renderer.material.color;
			b.renderer.material.color = new Color(Random.value, 0f, Random.value, c.a);
		}
	}
	
}
