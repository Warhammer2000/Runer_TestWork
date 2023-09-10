using System;
namespace Runer
{
    public interface IModel
    {
        event Action<string, object> PropertyChanged;
    }
}