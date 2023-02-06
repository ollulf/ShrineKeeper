using UnityEngine;

namespace Assets.Scripts.Core.CoreConfigs
{
    [CreateAssetMenu(fileName = "GameInstanceConfig",menuName = "Configs/Game Instance Config", order = 1)]
    public class GameInstanceConfig : ScriptableObject
    {
        public TimeSystemConfig TimeSystemConfig;

        [Header("UI Prefabs")]
        public GameObject InteractionMenu;
    }
}
