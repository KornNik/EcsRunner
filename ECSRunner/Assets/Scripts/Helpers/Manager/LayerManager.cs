using UnityEngine;

namespace EcsRunner.Helpers
{
    static class LayerManager
    {
        private const string DEFAULT = "Default";
        private const string COIN = "Coin";
        private const string FINISH = "Finish";

        public static int DefaultLayer { get; }
        public static int CoinLayer { get; }
        public static int FinishLayer { get; }

        static LayerManager()
        {
            DefaultLayer = LayerMask.GetMask(DEFAULT);
            CoinLayer = LayerMask.GetMask(COIN);
            FinishLayer = LayerMask.GetMask(FINISH);
        }
    }
}
