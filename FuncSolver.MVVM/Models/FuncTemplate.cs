using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FuncSolver.MVVM
{
    /// <summary>
    /// Класс описывает поля и методы математической функции.
    /// </summary>
    public class FuncTemplate : Variables
    {
        private string _funcType;
        private int _a;
        private int _b;
        private List<int> _c;
        private int _currentC;
        private BindingList<Variables> _variablesSetsList;
        private Variables _currentVariablesSet;

        /// <summary>
        /// Конструктор класса, инициализирующий поля.
        /// </summary>
        /// <param name="funcType">Тип функции.</param>
        public FuncTemplate(string funcType)
        {
            _funcType = funcType;
            C = new List<int>();
            _currentVariablesSet = new Variables();
            VariablesSetsList.ListChanged += ItemsOnListChanged;
        }

        /// <summary>
        /// Свойство поля _funcType, содержащего тип функции. 
        /// При установке значения оповещает систему об изменении свойства.
        /// </summary>
        public string FuncType
        {
            get => _funcType;
            set
            {
                _funcType = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Свойство поля _a, содержащего соответствующий коэффициент функции.
        /// При установке значения оповещает систему об изменении свойства.
        /// </summary>
        public int A
        {
            get => _a;
            set
            {
                _a = value;
                OnPropertyChanged(); 
            }
        }

        /// <summary>
        /// Свойство, непозволяющее ввести в поле А ничего кроме цифр.
        /// </summary>
        public string AChecker
        {
            get => A.ToString();
            set
            {
                var index = value.Length - 1;
                if (index == -1)
                {
                    A = 0;
                    return;
                }
                if (value[index] >= 48 && value[index] <= 57 && index >= 0)
                {
                    A = int.Parse(value);
                    return;
                }
            }
        }

        /// <summary>
        /// Свойство поля _b, содержащего соответсвующий коэффициент функции.
        /// При установке значения оповещает систему об изменении свойства.
        /// </summary>
        public int B
        {
            get => _b;
            set
            {
                _b = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Свойство, непозволяющее ввести в поле B ничего кроме цифр.
        /// </summary>
        public string BChecker
        {
            get => B.ToString();
            set
            {
                var index = value.Length - 1;
                if (index == -1)
                {
                    B = 0;
                    return;
                }
                if (value[index] >= 48 && value[index] <= 57 && index >= 0)
                {
                    B = int.Parse(value);
                    return;
                }
            }
        }

        /// <summary>
        /// Свойство поля _с, содержащего набор соответствующих коэффициентов.
        /// Определяет набор коэффициентов в зависимости от типа функции и 
        /// оповещает систему об изменении свойства.
        /// </summary>
        public List<int> C
        {
            get => _c;
            set
            {
                switch (FuncType)
                {
                    case "Линейная":
                        _c = new List<int> { 1, 2, 3, 4, 5 };
                        break;
                    case "Квадратичная":
                        _c = new List<int> { 10, 20, 30, 40, 50 };
                        break;
                    case "Кубическая":
                        _c = new List<int> { 100, 200, 300, 400, 500 };
                        break;
                    case "4-ой степени":
                        _c = new List<int> { 1000, 2000, 3000, 4000, 5000 };
                        break;
                    case "5-ой степени":
                        _c = new List<int> { 10000, 20000, 30000, 40000, 50000 };
                        break;
                    default:
                        break;
                }
                OnPropertyChanged();
            }
        }
        
        /// <summary>
        /// Свойство поля _currentC, содержащего текущий коэффициет из набора С.
        /// При установке значения оповещает систему об изменении свойства. 
        /// </summary>
        public int CurrentC
        {
            get => _currentC;
            set
            {
                _currentC = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Свойство поля _variablesSetsList, являющегося коллекцией наборов 
        /// значений переменных x, y, f. 
        /// </summary>
        public BindingList<Variables> VariablesSetsList { get; set; } = new BindingList<Variables>();

        /// <summary>
        /// Свойство поля _currentVariablesSet, содержащего выбранный набор переменных.
        /// В сеттере проверяет, существует ли набор, и либо создает его, 
        /// либо устанавливает значения в существующий.
        /// </summary>
        public Variables CurrentVariablesSet
        {
            get => _currentVariablesSet;
            set
            {
                if (value == null)
                {
                    _currentVariablesSet = new Variables();
                    return;
                }
                _currentVariablesSet = value;
            }
        }

        /// <summary>
        /// Метод высчитывает и устанавливает значение поля _f при изменении
        /// коллеции наборов переменных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ItemsOnListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                CurrentVariablesSet.F = UpdateF();
            }  
        }

        /// <summary>
        /// Метод вычисляет значение функции.
        /// </summary>
        /// <returns>Расчётное значение функции</returns>
        public double UpdateF()
        {
            var n = 0;
            switch (FuncType)
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
            return (A * Math.Pow(CurrentVariablesSet.X, n))
                + (B * Math.Pow(CurrentVariablesSet.Y, n - 1)) + CurrentC;
        }
    }
}