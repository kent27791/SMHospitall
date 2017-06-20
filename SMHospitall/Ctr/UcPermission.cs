using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace SMHospitall.Ctr
{
    public partial class UcPermission : DevExpress.XtraEditors.XtraUserControl
    {
        public UcPermission()
        {
            InitializeComponent();
            tree.ShowingEditor += (s, e) =>
            {
                var ps = tree.FocusedNode.GetValue(colThis) as Data.PermissionSet;
                if (tree.FocusedColumn == colRead && !ps.ReadS)
                    e.Cancel = true;
                else if (tree.FocusedColumn == colAdd && !ps.AddS)
                    e.Cancel = true;
                else if (tree.FocusedColumn == colEdit && !ps.EditS)
                    e.Cancel = true;
                else if (tree.FocusedColumn == colDelete && !ps.DeleteS)
                    e.Cancel = true;
                else if (tree.FocusedColumn == colReport && !ps.ReportS)
                    e.Cancel = true;
            };
            tree.CustomNodeCellEdit += (s, e) =>
            {
                var edit = e.RepositoryItem as RepositoryItemCheckEdit;
                if (edit!=null)
                {
                    var ps = e.Node.GetValue(colThis) as Data.PermissionSet;
                    if (ps != null)
                    {
                        if (e.Column == colRead && !ps.ReadS)
                            e.RepositoryItem = new RCEdit();
                        else if (e.Column == colAdd && !ps.AddS)
                            e.RepositoryItem = new RCEdit();
                        else if (e.Column == colEdit && !ps.EditS)
                            e.RepositoryItem = new RCEdit();
                        else if (e.Column == colDelete && !ps.DeleteS)
                            e.RepositoryItem = new RCEdit();
                        else if (e.Column == colReport && !ps.ReportS)
                            e.RepositoryItem = new RCEdit();
                    }
                }
            };
            tree.ShownEditor += (s, e) =>
            {
                tree.ActiveEditor.EditValueChanged += (s1, e1) =>
                {
                    tree.PostEditor();
                    tree.CloseEditor();
                    tree.Refresh();
                };
            };
        }
        Data.UserGroup _UserGroup;
        public Data.UserGroup UserGroup
        {
            get
            {
                return _UserGroup;
            }
            set
            {
                if (value!=null)
                {
                    _UserGroup = value;
                    var work = value.Session as UnitOfWork;
                    var ps = work.Query<Data.Permisson>().ToList();
                    ps.ForEach(item =>
                    {
                        if (!value.PermissionSets.Select(p=>p.Permisson).Contains(item))
                            value.PermissionSets.Add(new Data.PermissionSet(work)
                            {
                                UserGroup=value,
                                Permisson=item
                            });
                        tree.DataSource = value.PermissionSets.ToList();
                        tree.ExpandAll();
                    });
                }
                else
                {
                    tree.DataSource = typeof(Data.PermissionSet);
                }

            }
        }
        public bool EditTable
        {
            set
            {
                tree.OptionsBehavior.Editable = value;
            }
        }
    }
}
