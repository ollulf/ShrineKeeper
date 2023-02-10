using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeRunner : MonoBehaviour
{
    [SerializeField] private BehaviourTree m_tree;
    // Start is called before the first frame update
    void Start()
    {
        m_tree = ScriptableObject.CreateInstance<BehaviourTree>();

        DebugLogNode log = ScriptableObject.CreateInstance<DebugLogNode>();
        log.message = "Testing Behaviour Tree Nodes";

        m_tree.rootNode = log;
    }

    // Update is called once per frame
    void Update()
    {
        m_tree.Update();
    }
}
