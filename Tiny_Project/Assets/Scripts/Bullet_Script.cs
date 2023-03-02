using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] LayerMask collidables; //objects, ground, enemies
    private Vector3 previousPosition; //position of the object the frame before
    private bool hasCollided = false;

    public AttackData attackData;
    private void Start()
    {
        previousPosition = transform.position;
    }
    private void Update()
    {
        if (hasCollided) { return; }
        RaycastHit2D collisionCheck = Physics2D.Raycast(previousPosition, transform.position - previousPosition, Vector2.Distance(previousPosition, transform.position), collidables);
        if (collisionCheck)
        {
            HandleCollision(collisionCheck);
            hasCollided = true;

        }
        previousPosition = transform.position;
    }

    void HandleCollision(RaycastHit2D collision)
    {
        transform.position = collision.point;
        if (attackData == null)
        {
            Debug.Log("ERROR: Bullet has no assigned attackData; Check gun scripts.");
            Destroy(this.gameObject);
        }
        AttackData tempData = ScriptableObject.Instantiate<AttackData>(attackData);

        tempData.receiver = collision.collider.gameObject;
        Hit_Manager.Instance.BroadcastHit(tempData);
        Invoke("CustomDestroy", 0.01f);
    }
    void CustomDestroy()
    {
        Destroy(this.gameObject);
    }
}