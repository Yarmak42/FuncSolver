using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FuncSolver.MVVM
{
    /// <summary>
    /// Класс описывает переменные, объединённые в набор.
    /// </summary>
    public class Variables : INotifyPropertyChanged
    {
        private double _x;
        private double _y;
        private double _f;

        /// <summary>
        /// Конструктор класса, устанавливающий начальные значения свойства.
        /// </summary>
        public Variables()
        {
            X = 0;
            Y = 0;
            _f = 0;
        }

        /// <summary>
        /// Свойство поля _x. При установке значения оповещает систему об изменении свойства.
        /// </summary>
        public double X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged("X");
            }
        }

        /// <summary>
        /// Свойство поля _y. При установке значения оповещает систему об изменении свойства.
        /// </summary>
        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                OnPropertyChanged("Y");
            }
        }

        /// <summary>
        /// Свойство - геттер поля _f. Возвращает значение поля.
        /// </summary>
        public double F
        {
            get => _f;
        }

        /// <summary>
        /// Метод высчитывает и устанавливает значение поля _f, а также оповещает 
        /// систему об изменении свойства.
        /// </summary>
        /// <param name="a">Коэффициент а выбранной функции.</param>
        /// <param name="b">Коэффициент b выбранной функции.</param>
        /// <param name="c">Коэффициент c выбранной функции.</param>
        /// <param name="funcType">Тип выбранной функции.</param>
        public void SetF(double a, double b, int c, string funcType)
        {
            int n = 0;
            switch (funcType)
            {
                case "Линейная":
                    n = 1;
                    break;
                case "Квадратичная":
                    n = 2;
                    break;
                case "Кубическая":
                    n = 3;
                    break;
                case "4-ой степени":
                    n = 4;
                    break;
                case "5-ой степени":
                    n = 5;
                    break;
                default:
                    break;
            }
            _f = (a * Math.Pow(X, n)) + (b * Math.Pow(Y, n - 1)) + c;
            OnPropertyChanged("F");
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