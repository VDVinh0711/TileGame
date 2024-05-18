
using UnityEngine;

public class Tile : MonoBehaviour
{
   
   [SerializeField]  private Rigidbody rb;
   [SerializeField] private Collider coli;
   public string id;
   public SpriteRenderer Sprite;
   public StatePosTile StatePosTile;

   public void SetGravty()
   {
      rb.useGravity = true;
      rb.isKinematic = false;
   }
   public void UnSetGravity()
   {
      rb.useGravity = false;
      rb.isKinematic = true;
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
