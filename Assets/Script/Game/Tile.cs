
using UnityEngine;

public class Tile : MonoBehaviour
{
   
   [SerializeField]  private Rigidbody _rb;
   [SerializeField] private Collider _coli;
   public string id;
   public MeshRenderer mesrenderer;
   public StatePosTile StatePosTile;
   
   public void SetGravty()
   {
    
      _rb.useGravity = true;
      _rb.isKinematic = false;
   }
   public void UnSetGravity()
   {
      _rb.useGravity = false;
      _rb.isKinematic = true;
   }
   private void OnEnable()
   {
      SetGravty();
   }
   public void SetUpTile(string id, Sprite sprite)
   {
      this.id = id;
      this.mesrenderer.material.mainTexture = sprite.texture;
   }
}
