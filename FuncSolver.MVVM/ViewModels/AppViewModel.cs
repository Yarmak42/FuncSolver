using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FuncSolver.MVVM
{
    /// <summary>
    /// Класс, описывающий модель представления текущей программы.
    /// </summary>
    public class AppViewModel : INotifyPropertyChanged
    {
        private FuncTemplate _currentFunction;

        /// <summary>
        /// Автосвойство, устанавливающее или возвращающее набор функций.
        /// </summary>
        public List<FuncTemplate> Functions { get; set; }

        /// <summary>
        /// Свойство поля _currentFunction, содержащего выбранную функцию.
        /// При установке значения оповещает систему об изменении свойства.
        /// </summary>
        public FuncTemplate CurrentFunction
        {
            get => _currentFunction;
            set
            {
                _currentFunction = value;
                OnPropertyChanged("CurrentFunction");
            }
        }

        /// <summary>
        /// Конструктор класса, иницилизирует набор функций.
        /// </summary>
        public AppViewModel()
        {
            Functions = new List<FuncTemplate>()
            {
                new FuncTemplate("Линейная"),
                new FuncTemplate("Квадратичная"),
                new FuncTemplate("Кубическая"),
                new FuncTemplate("4-ой степени"),
                new FuncTemplate("5-ой степени")
            };
        }

        /// <summary>
        /// Реализация интерфейса INotifyPropertyChanged. Извещает систему об изменении свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}