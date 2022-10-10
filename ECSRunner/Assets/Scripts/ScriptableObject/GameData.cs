using UnityEngine;
using UnityEngine.UI;
using EcsRunner.Helpers;

namespace EcsRunner.Data
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Data/Game/GameData")]
    class GameData : ScriptableObject
    {
        [SerializeField] private MoveData _moveData;
        [SerializeField] private CoinData _coinData;
        [SerializeField] private CameraData _cameraData;

        [SerializeField] private LevelTypes _levelType;
        [SerializeField] private PlayerTypes _playerType;

        [HideInInspector] public Text ScoreText;
        [HideInInspector] public GameObject EndLevelPanel;
        [HideInInspector] public Transform PlayerRespawnTransform;

        public MoveData MoveData => _moveData;
        public CoinData CoinData => _coinData;
        public CameraData CameraData => _cameraData;

        public LevelTypes LevelType => _levelType;
        public PlayerTypes PlayerType => _playerType;
    }
}
