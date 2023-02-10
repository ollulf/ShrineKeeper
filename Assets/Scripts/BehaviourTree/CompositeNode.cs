using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphViewBehaviorTree;

public abstract class CompositeNode : Node
{
    public List<Node> children = new List<Node>();
}
