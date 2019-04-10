using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Data.ViewModel
{
    public class TreeModel
    {
        #region props

        public List<TreeNode> Items { get; set; }

        public bool ShowDetails { get; set; }

        #endregion

        #region publics

        public TreeNode GetNode(Guid id)
        {
            return this.Items.SelectMany(item => item.Nodes.SelectMany(x => x.Nodes)).FirstOrDefault(x => x.Id == id);
        }

        #endregion
    }
}
