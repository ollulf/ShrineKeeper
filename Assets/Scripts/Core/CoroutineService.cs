using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class CoroutineService : MonoBehaviour
    {
        public void RunCoroutine(IEnumerator coroutineToRun)
        {
            StartCoroutine(coroutineToRun);
        }
    }
}
