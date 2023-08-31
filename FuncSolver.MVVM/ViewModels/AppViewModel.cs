using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace FuncSolver.MVVM
{
    /// <summary>
    /// Класс, описывающий модель представления текущей программы.
    /// </summary>
    public class AppViewModel : NotifyPropertyChanged
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
                OnPropertyChanged();
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
    }
}