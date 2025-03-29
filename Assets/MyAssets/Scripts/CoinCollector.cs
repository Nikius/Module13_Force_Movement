using System;
using UnityEngine;
using Object = System.Object;

namespace MyAssets.Scripts
{
    public class CoinCollector : MonoBehaviour
    {
        private Wallet _wallet;
        
        private void Awake()
        {
            _wallet = GetComponent<Wallet>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Coin coin = other.GetComponent<Coin>();

            if (coin == null)
                return;
            
            _wallet.Collect();
            coin.gameObject.SetActive(false);
        }
    }
}
