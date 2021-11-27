using Core.DataBaseServices;
using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.GeneratorApp
{
    public class DataBaseTree : Panel
    {


        public Guid Companyid { get; set; } = Guid.Empty;

        public DataBaseTree()
        {
            this.Controls.Add(treeView);
        }

        public TreeView treeView { get; set; }

        public void InitTree()
        {
            this.Controls.Clear();
         
            treeView = new TreeView(); treeView.Dock = DockStyle.Fill;
            var m = new ConnectionString() { CompanysId = Companyid };
            ConnectionStringManageServices connection = new ConnectionStringManageServices();

            connection.GetConnections(m).ForEach(c =>
            {
                // add root
                TreeNode root = new TreeNode()
                {
                    Text = c.Address,
                    Tag = c
                };
                treeView.Nodes.Add(root); 

                var dataBaseServices = new Core.DataBaseServices.DataBaseServices();

                FreeSqlFactory factory = new FreeSqlFactory(m.GetConnectionString());
                dataBaseServices.GetDataBase(factory.FreeSql, factory.DefaultDataType).ForEach(x =>
                {
                    TreeNode databasenode = new TreeNode()
                    {
                        Text = x.DataBaseName,
                        Tag = x
                    };
                    root.Nodes.Add(databasenode);


                    var tables = dataBaseServices.GetTable(factory.FreeSql, factory.DefaultDataType);
                    var columns = dataBaseServices.GetColumn(factory.FreeSql, factory.DefaultDataType);
                    tables.ForEach(p =>
                    {

                        TreeNode tablenode = new TreeNode()
                        {
                            Text = p.TableName,
                            Tag = p
                        };
                        databasenode.Nodes.Add(tablenode);

                        var tablecolumns = columns.Where(u=>u.TableName.Equals(p.TableName)).ToList();

                        tablecolumns.ForEach(y => {

                            TreeNode columnnode = new TreeNode()
                            {
                                Text = y.ColumnName,
                                Tag = y
                            };
                            tablenode.Nodes.Add(columnnode);
                        });
                    }); 
                });

            });
            this.Controls.Add(treeView);
        }
    }
}
