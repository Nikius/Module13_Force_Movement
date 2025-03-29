using UnityEngine;

namespace MyAssets.Scripts
{
    public class Wallet: MonoBehaviour
    {
        public int CollectedCoins { get; private set; }
        
        public void Collect()
        {
            CollectedCoins++;
            Debug.Log($"Collected coins: {CollectedCoins}");
        }

        public void Reset()
        {
            CollectedCoins = 0;
        }
    }
}