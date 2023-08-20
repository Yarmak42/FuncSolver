using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FuncSolver.MVVM
{
    /// <summary>
    /// Класс описывает поля и методы математической функции.
    /// </summary>
    public class FuncTemplate : INotifyPropertyChanged
    {
        private string _funcType;
        private double _a;
        private double _b;
        private List<int> _c;
        private int _currentC;
        private ObservableCollection<Variables> _variablesSetsList;
        private Variables _currentVariablesSet;

        /// <summary>
        /// Конструктор класса, инициализирующий поля.
        /// </summary>
        /// <param name="funcType">Тип функции.</param>
        public FuncTemplate(string funcType)
        {
            _funcType = funcType;
            C = new List<int>();
            _variablesSetsList = new ObservableCollection<Variables>();
            _currentVariablesSet = new Variables();
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
                OnPropertyChanged("FuncType");
            }
        }

        /// <summary>
        /// Свойство поля _a, содержащего соответствующий коэффициент функции.
        /// При установке значения оповещает систему об изменении свойства.
        /// </summary>
        public double A
        {
            get => _a;
            set
            {
                _a = value;
                OnPropertyChanged("A");
            }
        }
                                                                 
        /// <summary>
        /// Свойство поля _b, содержащего соответсвующий коэффициент функции.
        /// При установке значения оповещает систему об изменении свойства.
        /// </summary>
        public double B
        {
            get => _b;
            set
            {
                _b = value;
                OnPropertyChanged("B");
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
                OnPropertyChanged("C");
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
                OnPropertyChanged("CurrentC");
            }
        }

        /// <summary>
        /// Свойство поля _variablesSetsList, являющегося коллекцией наборов 
        /// значений переменных x, y, f. При установке значения оповещает 
        /// систему об изменении свойства. 
        /// </summary>
        public ObservableCollection<Variables> VariablesSetsList
        {
            get => _variablesSetsList;
            set
            {
                _variablesSetsList = value;
                OnPropertyChanged("VariablesSetsList");
            }
        }

        /// <summary>
        /// Свойство поля _currentVariablesSet, содержащего выбранный набор переменных.
        /// В сеттере проверяет, существует ли набор, и либо создает его, 
        /// либо устанавливает значения в существующий, после чего оповещает
        /// систему об изменении свойства. 
        /// </summary>
        public Variables CurrentVariablesSet
        {
            get => _currentVariablesSet;
            set
            {
                if (value == null)
                    _currentVariablesSet = new Variables();
                else
                {
                    _currentVariablesSet = value;
                    _currentVariablesSet.SetF(A, B, CurrentC, FuncType);
                }
                OnPropertyChanged("VariablesSetsList");
            }
        }

        /// <summary>
        /// Реализация интерфейса INotifyPropertyChanged. 
        /// Извещает систему об изменении свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}