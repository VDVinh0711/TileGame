
using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundClickButton : MonoBehaviour
{
   [SerializeField] private Button _button;

   private void Awake()
   {
      _button.onClick.AddListener(ActionClick);
   }

   private void ActionClick()
   {
      SoundManager.Instance.PlayAudioSFX(Sound.clickbutton);
   }
}
