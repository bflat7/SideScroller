using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody2D _ItemRigidBody;

    private float _StartHeight;
    private float t = 0f;
    [HideInInspector]
    public Sprite Sprite;
    public float minimum = -1.0F;
    public float maximum = 1.0F;
    public Inventory PlayerInventory;
    public GameObject InventoryItemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Sprite = this.GetComponent<SpriteRenderer>().sprite;
        _ItemRigidBody = this.GetComponent<Rigidbody2D>();
        _StartHeight = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        // .. and increase the t interpolater
        t += 0.5f * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }

        _ItemRigidBody.MovePosition(new Vector2(this.transform.position.x, _StartHeight + .7f * Mathf.Lerp(minimum, maximum, t)));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.GetComponent<PlayerController>().AddItem(this);
            PlayerInventory.AddInventoryItem(this);
            Destroy(this.gameObject);
        }
    }
}
