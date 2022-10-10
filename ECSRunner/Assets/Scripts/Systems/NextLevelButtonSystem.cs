using UnityEngine.Scripting;
using UnityEngine.SceneManagement;
using EcsRunner.Helpers;
using Leopotam.EcsLite.Unity.Ugui;

namespace EcsRunner.Systems
{
    class NextLevelButtonSystem : EcsUguiCallbackSystem
    {
        [Preserve]
        [EcsUguiClickEvent(UIButtonManager.NEXT_LVL)]
        void OnRestartClick(in EcsUguiClickEvent e)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
