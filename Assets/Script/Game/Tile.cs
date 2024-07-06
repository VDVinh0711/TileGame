
using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Tile : MonoBehaviour
{
   
   [SerializeField]  private Rigidbody _rb;
   public string id;
   public MeshRenderer meshrenderer;
   public StatePosTile StatePosTile;


   private void Update()
   {
      if (transform.position.y < -70)
      {
         transform.position = Vector3.zero;
      }
   }

   public void SetGravty()
   {
      _rb.isKinematic = false;
   }
   public void UnSetGravity()
   {
      _rb.isKinematic = true;
   }
   public void SetUpTile(string id, Sprite sprite)
   {
      this.id = id;
      this.meshrenderer.material.mainTexture = sprite.texture;
   }
   private void OnEnable()
   {
      SetGravty();
   }

  
}
