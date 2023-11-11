using System.Collections.Generic;
using ProtoYeet.Abstracts;
using UnityEngine;

namespace Game.Views.Column
{
    public interface IColumnView : IView
    {
        List<Vector3> Cells { get; }
    }
}