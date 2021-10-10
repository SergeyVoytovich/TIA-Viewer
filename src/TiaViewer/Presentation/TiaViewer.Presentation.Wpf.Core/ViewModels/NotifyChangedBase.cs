using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TiaViewer.Presentation.Wpf.ViewModels
{
    public abstract class NotifyChangedBase : INotifyPropertyChanged
    {
        #region Fields

        private readonly ConcurrentDictionary<string, object> _properties;

        #endregion


        #region Constructors

        public NotifyChangedBase() : this(new ConcurrentDictionary<string, object>())
        {
        }

        public NotifyChangedBase(ConcurrentDictionary<string, object> properties)
        {
            _properties = properties ?? throw new ArgumentNullException(nameof(properties));
        }

        #endregion


        #region Events

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        #region Methods

        protected internal virtual T Get<T>([CallerMemberName] string propertyName = null) 
            => string.IsNullOrWhiteSpace(propertyName) ? default : (T)_properties.GetOrAdd(propertyName, default(T));

        protected internal virtual void Set<T>(T value, [CallerMemberName] string propertyName = null)
        {
            _properties.AddOrUpdate(propertyName,
                _ =>
                {
                    OnPropertyChanged(propertyName);
                    return value;
                },
                (_, old) =>
                {
                    if (Equals(old, value))
                    {
                        return old;
                    }

                    OnPropertyChanged(propertyName);
                    return value;
                });
        }


        #endregion
    }
}