using System.Collections.Generic;
using Game.Views.Column;
using ProtoYeet.Abstracts;
using UnityEngine;

namespace Game.Presenters.Column
{
    public interface IColumnPresenter : IPresenter<IColumnView>, IInjectable
    {
        List<Vector3> Cells { get; }
    }
}