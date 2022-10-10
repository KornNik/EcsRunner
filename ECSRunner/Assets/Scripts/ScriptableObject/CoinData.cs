using UnityEngine;

namespace EcsRunner.Data
{
    [CreateAssetMenu(fileName = "CoinData", menuName = "Data/Coin/CoinData")]
    class CoinData : ScriptableObject
    {
        [SerializeField] private int _coinPoints;

        public int CoinPoints => _coinPoints;
    }
}
