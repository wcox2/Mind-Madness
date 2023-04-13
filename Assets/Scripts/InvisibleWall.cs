using UnityEngine;

public class InvisibleWall : MonoBehaviour {
    public GameObject player;
    public GameObject sprite;
    private float dist;
    private MeshRenderer MR;
    private Color color;
    private Material material;
    private Collider col;
    private Vector3 closestPoint;
    public GameObject child;
    public int startDist = 4;

    void Start() {
        player = GameObject.FindWithTag("Player");
        sprite = player.transform.GetChild(0).gameObject;
        child = this.transform.GetChild(0).gameObject;
        MR = this.GetComponent<MeshRenderer>();
        material = this.GetComponent<MeshRenderer>().material;
        col = this.GetComponent<Collider>();
        child.transform.position = this.transform.position;
    }

    void Update() {
        if ((sprite.transform.position.x > col.bounds.min.x) && (sprite.transform.position.x < col.bounds.max.x)) {
            child.transform.position = new Vector3(sprite.transform.position.x, child.transform.position.y, child.transform.position.z);
        }
        if ((sprite.transform.position.y > col.bounds.min.y) && (sprite.transform.position.y < col.bounds.max.y)) {
            child.transform.position = new Vector3(child.transform.position.x, sprite.transform.position.y, child.transform.position.z);
        }
        if ((sprite.transform.position.z > col.bounds.min.z) && (sprite.transform.position.z < col.bounds.max.z)) {
            child.transform.position = new Vector3(child.transform.position.x, child.transform.position.y, sprite.transform.position.z);
        }
        dist = Vector3.Distance(sprite.transform.position, child.transform.position);
        if (dist > startDist) {
            MR.enabled = false;
        }
        else {
            MR.enabled = true;
        }
        material.SetColor("_Color", new Color(1, 1, 1, (startDist - dist) / (startDist + 2)));
    }
}