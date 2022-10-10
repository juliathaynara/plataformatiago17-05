using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Isso seria o nosso youtube.com
// Modificar static diz que pode ser acessado
// De qualquer lugar no código
public static class PlayerObserverManager
{
    // Canal da variavel coins do PlayerController
    // 1- parte da inscrição
    public static Action<int> OnCoinsChanged;
    // 2- Parte do sininho (notificação)
    public static void CoinsChanged(int value)
    {
        // Existe alguem inscrito em OnCoinsChanged?
        // caso tenha, mande o volue para todos
        OnCoinsChanged?.Invoke(value);
    }
}
