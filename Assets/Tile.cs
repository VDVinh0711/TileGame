
using UnityEngine;

public class Tile : MonoBehaviour
{
   public Rigidbody rb { private set; get; }
   public Collider coli { private set; get; }
   public string id;
   public SpriteRenderer Sprite;
   private void Awake()
   {
      rb = gameObject.GetComponent<Rigidbody>();
      coli = gameObject.GetComponent<Collider>();
   }

   public void SetGravty()
   {
      rb.useGravity = true;
      rb.isKinematic = false;
      rb.useGravity = true;
   }
   public void UnSetGravity()
   {
      rb.useGravity = false;
      rb.isKinematic = true;
      rb.useGravity = false;
   }
   private void OnEnable()
   {
      SetGravty();
   }
   public void SetUpTile(string id, Sprite sprite)
   {
      this.id = id;
      this.Sprite.sprite = sprite;
   }
}
