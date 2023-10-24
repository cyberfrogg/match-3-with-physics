namespace ProtoYeet.Abstracts
{
    public interface IPresenter<out T> where T : IView
    {
        T View { get; }
    }
}