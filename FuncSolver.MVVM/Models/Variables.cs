namespace FuncSolver.MVVM
{
    /// <summary>
    /// Класс описывает переменные, объединённые в набор.
    /// </summary>
    public class Variables : NotifyPropertyChanged
    {
        private int _x;
        private int _y;
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
        /// Свойство поля _x. При установке значения оповещает систему
        /// об изменении свойства.
        /// </summary>
        public int X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(F));
            }
        }

        /// <summary>
        /// Свойство, непозволяющее ввести в поле X ничего кроме цифр.
        /// </summary>
        public string XChecker
        {
            get => X.ToString();
            set
            {
                var index = value.Length - 1;
                if (index == -1)
                {
                    X = 0;
                    return;
                }
                if (value[index] >= 48 && value[index] <= 57 && index >= 0)
                {
                    X = int.Parse(value);
                    return;
                }
            }
        }

        /// <summary>
        /// Свойство поля _y. При установке значения оповещает систему
        /// об изменении свойства.
        /// </summary>
        public int Y
        {
            get => _y;
            set
            {
                _y = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(F));
            }
        }

        /// <summary>
        /// Свойство, непозволяющее ввести в поле Y ничего кроме цифр.
        /// </summary>
        public string YChecker
        {
            get => Y.ToString();
            set
            {
                var index = value.Length - 1;
                if (index == -1)
                {
                    Y = 0;
                    return;
                }
                if (value[index] >= 48 && value[index] <= 57 && index >= 0)
                {
                    Y = int.Parse(value);
                    return;
                }
            }
        }
        /// <summary>
        /// Свойство поля _f. Возвращает и устанавливает значение поля.
        /// </summary>
        public double F
        {
            get
            {
                return _f;
            }
            set
            {
                _f = value;               
            }
        }
    }
}