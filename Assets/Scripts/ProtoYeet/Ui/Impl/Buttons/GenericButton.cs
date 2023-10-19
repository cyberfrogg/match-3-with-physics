using ProtoYeet.Ui.Abstracts;
using UnityEngine.EventSystems;

namespace ProtoYeet.Ui.Impl.Buttons
{
    public class GenericButton : AButton, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            InternalClick();
        }
    }
}