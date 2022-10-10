using UnityEngine;
using UnityEngine.UI;
using EcsRunner.Data;
using EcsRunner.Systems;
using Leopotam.EcsLite.Unity.Ugui;

namespace EcsRunner.EcsMonoBehaviour
{
    class GameInitialization : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        [SerializeField] private EcsUguiEmitter _emitter;
        [SerializeField] private Text _scoreText;
        [SerializeField] private GameObject _endLevelPanel;

        private GameInit _gameInit;

        private void Start()
        {
            _gameData.ScoreText = _scoreText;
            _gameData.EndLevelPanel = _endLevelPanel;
            _gameData.EndLevelPanel.gameObject.SetActive(false);

            _gameInit = new GameInit(_gameData, _emitter);
        }

        private void Update()
        {
            _gameInit.UpdateSystems();
        }

        private void FixedUpdate()
        {
            _gameInit.FixedUpdateSystems();
        }

        private void OnDestroy()
        {
            _gameInit.Destroy();
        }
    }
}
