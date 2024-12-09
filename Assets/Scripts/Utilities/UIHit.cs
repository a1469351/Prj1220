using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///
/// </summary>

namespace ns
{
	public class UIHit : Image
	{
        protected override void OnPopulateMesh(VertexHelper toFill)
        {
            base.OnPopulateMesh(toFill);
            toFill.Clear();
        }
    }
}