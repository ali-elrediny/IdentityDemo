// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckListData.cs" company="SURE International Technology">
//   Copyright © 2018 All Right Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.DirectoryServices.Protocols;

namespace Framework.Core.Data.ViewModel
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The check list data.
    /// </summary>
    [Serializable]
    public class CheckListData
    {
        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        public List<CheckItem> DataSource { get; set; }

        /// <summary>
        /// Gets or sets the selected items.
        /// </summary>
        public List<Guid> SelectedItems { get; set; }
    }

    /// <summary>
    /// The check item.
    /// </summary>
    [Serializable]
    public class CheckItem
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the info.
        /// </summary>
        public string Info { get; set; } /*Used for competency weight as an example*/

        /// <summary>
        /// Gets or sets the info min value.
        /// </summary>
        public int InfoMinValue { get; set; }

        /// <summary>
        /// The info max value.
        /// </summary>
        public int InfoMaxValue { get; set; } = 999;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public CheckListItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the sub items.
        /// </summary>
        public List<CheckItem> SubItems { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is saved.
        /// </summary>
        public bool IsSaved { get; set; }

        /// <summary>
        /// Gets or sets the supported operations.
        /// </summary>
        public CheckListTreeOperations SupportedOperations { get; set; } = new CheckListTreeOperations();

        public bool IsCheckBox { get; set; } = true;

        public bool HasSelectionControl { get; set; }

        public List<CheckListColumn> Columns { get; set; } = new List<CheckListColumn>();
    }

    /// <summary>
    /// The supported operations.
    /// </summary>
    public class CheckListTreeOperations
    {
        /// <summary>
        /// Gets or sets a value indicating whether can pin questions.
        /// </summary>
        public bool CanPinQuestions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can set ranges.
        /// </summary>
        public bool CanSetRanges { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can delete.
        /// </summary>
        public bool CanDelete { get; set; }
    }

    public class CheckListColumn
    {
        public string ColumnName { get; set; }
        public CheckListColumnType ColumnType { get; set; }
        public object ColumnValue { get; set; }
    }

    public enum CheckListColumnType
    {
        Span,
        TextBox,
        NumericTextBox,
        DecimalNumericTextBox,
        Hidden
    }
}