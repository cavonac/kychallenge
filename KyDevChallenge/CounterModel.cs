using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KyDevChallenge
{
    public class CounterModel : INotifyPropertyChanged
    {
        private int _timer;
        private int _counter;

        public int Count
        {
            get { return _counter; }
            set
            {
                _counter = value;
                NotifyPropertyChanged();
            }
        }

        public int Timer
        {
            get { return _timer; }
            set
            {
                if (_timer != value)
                {
                    _timer = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #region Implement Interface
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
