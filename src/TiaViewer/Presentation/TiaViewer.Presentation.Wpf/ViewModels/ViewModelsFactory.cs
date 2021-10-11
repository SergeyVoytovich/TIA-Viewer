﻿using System;
using TiaViewer.BusinessLayer;
using TiaViewer.Common.BusinessLayer;
using TiaViewer.Common.Data;
using TiaViewer.Data;
using TiaViewer.Presentation.Wpf.Services;

namespace TiaViewer.Presentation.Wpf.ViewModels
{
    /// <summary>
    /// View models factory
    /// </summary>
    public class ViewModelsFactory
    {
        #region Fields

        private readonly IApplication _application;

        #endregion


        #region Constructors

        /// <summary>
        /// Initialize a new instance
        /// </summary>
        public ViewModelsFactory()
            : this(new DataSource())
        {

        }

        /// <summary>
        /// Initialize a new instance
        /// </summary>
        public ViewModelsFactory(IDataSource dataSource)
            :this(new Application(dataSource))
        {

        }

        /// <summary>
        /// Initialize a new instance
        /// </summary>
        public ViewModelsFactory(IApplication application)
        {
            _application = application ?? throw new ArgumentNullException(nameof(application));
        }

        #endregion


        #region Properties

        /// <summary>
        /// Main view model
        /// </summary>
        public MainViewModel Main 
            => new(new ViewModelEnvironment(_application, new ServicesCollection(new FileDialogService())));

        #endregion
    }
}