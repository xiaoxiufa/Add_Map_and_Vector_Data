using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void axMapControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            axMapControl1.LoadMxFile(@"./data");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开地图文档";
            ofd.Filter = "地图文档(*.mxd)|*.mxd";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string Path = ofd.FileName;
                axMapControl1.LoadMxFile(Path);
                if (axMapControl1.CheckMxFile(Path))
                {
                    axMapControl1.Map.ClearLayers();
                    axMapControl1.LoadMxFile(Path);
                }
                axMapControl1.ActiveView.Refresh();
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开shp文件";
            ofd.Filter = "shp文件(*.shp)|*.shp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string ShpPath = ofd.FileName;
                string shpFolder = System.IO.Path.GetDirectoryName(ShpPath);
                string shpFilename = System.IO.Path.GetFileName(ShpPath);
                axMapControl1.AddShapeFile(shpFolder, shpFilename);
                
            }

        }
    }
}
