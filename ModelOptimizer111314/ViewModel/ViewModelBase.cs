﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModelOptimizer111314.ViewModel
{
    class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        protected ViewModelBase()
        { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if(handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public void Dispose()
        {
            this.OnDispose();
        }

        protected virtual void OnDispose() { }
    }
}
