using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Core.Data.ViewModel
{
    public class TreeNode
    {
        #region props

        public Guid Id { get; set; }

        public string Text { get; set; }

        public string JsonData { get; set; }

        public Guid? ParentId { get; set; }

        public List<TreeNode> Nodes { get; set; }

        #endregion

        
    }
}
