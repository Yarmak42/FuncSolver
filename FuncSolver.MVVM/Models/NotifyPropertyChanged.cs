using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FuncSolver.MVVM
{
    /// <summary>
    /// Реализация интерфейса INotifyPropertyChanged. Извещает систему
    /// об изменении свойства.
    /// </summary>
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
