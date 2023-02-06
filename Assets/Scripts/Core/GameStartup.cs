using Assets.Scripts.Core.CoreConfigs;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class GameStartup : MonoBehaviour
    {
        public GameInstanceConfig Config;
        public CoroutineService CoroutineService;
        private GameInstance mGameInstance;

        void Start()
        {
            mGameInstance = new GameInstance(Config);
            mGameInstance.Initialize(CoroutineService);
        }
    }
}
