using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    private ItemType m_type;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                bool pickedUp = inventory.PickUp(m_type);
                if (pickedUp)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
