using Assets.Scripts.Core.CoreConfigs;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class GameInstance
    {
        public static GameInstance Current;

        private GameInstanceConfig mConfig;

        public CoroutineService CoroutineService;
        public TimeHandler TimeSystem;


        public GameObject InteractionCanvasPrefab;

        public GameInstance(GameInstanceConfig config)
        {
            if (Current != null)
            {
                return;
            }
            
            mConfig = config;

            Current = this;
        }

        public void Initialize(CoroutineService coroutineService)
        {
            CoroutineService = coroutineService;
            TimeSystem = TimeHandler.Instance;
            InteractionCanvasPrefab = mConfig.InteractionMenu;
        }
    }
}
