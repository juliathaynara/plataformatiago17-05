using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUIController : MonoBehaviour
{
   [SerializeField] private TMP_Text coinText;

   private void OnEnable()
   {
      // Se inscreva no canal do coins
      PlayerObserverManager.OnCoinsChanged += UpdateCoinText;
   }

   private void OnDisable()
   {
      // Retira a inscrição no canal de coins
      PlayerObserverManager.OnCoinsChanged -= UpdateCoinText;
   }
   // funçao usada para trocar a notificaçao do canal de coins

   private void UpdateCoinText(int newCoinsValue)
   {
      coinText.text = newCoinsValue.ToString();
   }
}
