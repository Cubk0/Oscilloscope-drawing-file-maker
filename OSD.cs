
namespace OSD
{
    enum fileTypes {basic,rts}
    public partial class OSD : Form
    {
        bool gridEnabled;
        bool returnToStart = false;
        bool darkMode = false;
        byte fileType = (byte)fileTypes.basic;
        int gridSize=3;
        Color backColor = Color.White;
        Color headerColor = Color.DarkGray;
        Color textColor = Color.Black;
        Color penColor = Color.Navy;
        Point Latest, mouseGrid, oldMouseGrid;
        
        Image darkModeImg= Properties.Resources.darkMode;
        Image lightModeImg = Properties.Resources.lightMode;
        List<Point> _points = new List<Point>();
        float currentScale;
        public OSD(string path)
        {
            InitializeComponent();

            if (path != string.Empty && Path.GetExtension(path).ToLower() == ".pes")
            {
                LoadFile(path);
            }
            else if(path != string.Empty)
            {
                MessageBox.Show("Dropped File is not pes File", "File Type Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                path = string.Empty;
            }
        }

        private void TurboProgram_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            currentScale = 1000f / panel.Width;
            TurboProgram_Resize(this, EventArgs.Empty);
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(penColor, 4);
            Pen gridPen = new Pen(Color.DimGray, 1);
            Graphics g = e.Graphics;
            if (_points.Count > 0)
            {
                Point pt = new Point((int)(_points[0].X / currentScale), (int)(_points[0].Y / currentScale));
                e.Graphics.FillEllipse(darkMode?Brushes.White:Brushes.Navy, new Rectangle(new Point((int)(_points[0].X / currentScale) - 2, (int)(_points[0].Y / currentScale) - 2), new Size(4, 4)));
                for (int i = 1; _points.Count > i; i++)
                {
                    Point next = new Point((int)(_points[i].X / currentScale), (int)(_points[i].Y / currentScale));
                    g.DrawLine(pen, pt, next);
                    pt = next;
                }
            }
            if (gridEnabled)
            {
                for (int i = 0;i<gridSize;i++)
                {
                    g.DrawLine(gridPen, new Point(panel.Width/gridSize*i,0),new Point(panel.Width / gridSize * i, panel.Height));
                    g.DrawLine(gridPen, new Point(0, panel.Height / gridSize * i), new Point(panel.Width, panel.Height / gridSize * i));
                }
                e.Graphics.FillEllipse(darkMode ? Brushes.White : Brushes.Navy, new Rectangle(new Point(mouseGrid.X - 2, mouseGrid.Y - 2), new Size(4, 4)));
            }
        }
        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (SolidBrush backBrush = new SolidBrush(headerColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            using (SolidBrush foreBrush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(e.Header.Text, e.Font, foreBrush, e.Bounds);
            }
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (gridEnabled)
            {
                int x = mouseGrid.X; 
                int y = mouseGrid.Y; 
                Latest = new Point((int)(x * currentScale), (int)(y * currentScale));
            }
            else
            {
                Latest = new Point((int)(e.X * currentScale), (int)(e.Y * currentScale));
            }
            
            _points.Add(Latest);
            ListViewItem item = new ListViewItem(_points.Count().ToString());
            item.SubItems.Add(((int)(e.X*currentScale)).ToString());
            item.SubItems.Add(((int)(e.Y*currentScale)).ToString());
            item.BackColor = backColor;
            item.ForeColor = textColor;
            listView1.Items.Add(item);
            
            Refresh();
        }

        private void panel_MouseLeave(object sender, EventArgs e)
        {
            if (_points.Count>0&&!returnToStart)
            {
                _points.Add(_points[0]);
                Refresh();
            }
            
        }
        private void panel_MouseEnter(object sender, EventArgs e)
        {
            if (_points.Count>1 && _points[0]==_points[_points.Count-1])
            {
                _points.RemoveAt(_points.Count-1);
                Refresh();
            }
        }
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (gridEnabled)
            {
                if (oldMouseGrid != mouseGrid)
                {

                    Refresh();
                }
                oldMouseGrid = mouseGrid;
                mouseGrid = new Point((e.X + panel.Width / (gridSize * 2)) / (panel.Width / gridSize) * (panel.Width / gridSize),
                                      (e.Y + panel.Width / (gridSize * 2)) / (panel.Height / gridSize) * (panel.Width / gridSize));
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            _points.Clear();
            listView1.Items.Clear();
            Refresh();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (_points.Count>0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "havo|*.pes";
                saveFileDialog1.Title = "Save a Mario";
                saveFileDialog1.ShowDialog();
                if (!returnToStart)
                {
                    _points.RemoveAt(_points.Count - 1);
                }
                if (saveFileDialog1.FileName != "")
                {
                    using (Stream stream = saveFileDialog1.OpenFile())
                    {
                        using (var writer = new BinaryWriter(stream, System.Text.Encoding.ASCII, false))
                        {
                            writer.Write(fileType);
                            writer.Write(returnToStart ? _points.Count() * 2-2:_points.Count()) ;
                            foreach (Point p in _points)
                            {
                                writer.Write(p.X);
                                writer.Write(p.Y);
                            }
                            if (returnToStart)
                            {
                                for (int i= _points.Count()-2;i  > 0 ; i--)
                                {
                                    writer.Write(_points[i].X);
                                    writer.Write(_points[i].Y);
                                }
                            }
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("0 bodov :(","Sikovnicek",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }   
        }
        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "havo|*.pes";
            ofd.ShowDialog();
            if (File.Exists(ofd.FileName))
            {
                LoadFile(ofd.FileName);
            }
            
        }

        private void TurboProgram_Resize(object sender, EventArgs e)
        {
            if (this.Width-200>this.Height)
            {
                panel.Size = new Size(this.Size.Height - 56, this.Size.Height - 56);
            }
            else
            {
                panel.Size = new Size(this.Size.Width - 256, this.Size.Width - 256);
            }
            currentScale = 1000f / panel.Width;
            listView1.Location = new Point(this.Width-24-listView1.Width, 10);
            listView1.Size = new Size(204,panel.Size.Height-234);
            resetButton.Location = new Point(listView1.Location.X,panel.Height-122);
            saveButton.Location = new Point(resetButton.Location.X, resetButton.Location.Y + 68);
            gridCheckBox.Location = new Point(resetButton.Location.X, resetButton.Location.Y -87);
            gridTrackBar.Location = new Point(gridCheckBox.Location.X, gridCheckBox.Location.Y + 25);
            darkModeButton.Location = new Point(gridCheckBox.Location.X + 174,gridCheckBox.Location.Y);
            rtsCheckBox.Location = new Point(gridTrackBar.Location.X, gridTrackBar.Location.Y + 37);
            loadButton.Location = new Point(saveButton.Location.X+107, saveButton.Location.Y);
            Refresh();
        }

        

        private void TurboProgram_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Z&&e.Control&&_points.Count()>0)
            {
                _points.RemoveAt(_points.Count() - 1);
                listView1.Items.RemoveAt(_points.Count());
                Refresh();
            }
            
        }

        private void darkModeButton_Click(object sender, EventArgs e)
        {
            darkMode = !darkMode;
            if (darkMode)
            {
                penColor = Color.White;
                backColor = Color.FromArgb(64, 64, 64);
                headerColor = Color.DimGray;
                textColor = Color.White;
                darkModeButton.BackgroundImage = lightModeImg;
            }
            else
            {
                penColor = Color.Navy;
                backColor = Color.White;
                headerColor = Color.DarkGray;
                textColor = Color.Black;
                darkModeButton.BackgroundImage = darkModeImg;
            }
            foreach (ListViewItem item in listView1.Items)
            {
                item.BackColor = backColor;
                item.ForeColor = textColor;
            }
            panel.BackColor = backColor;
            this.BackColor = headerColor;
            listView1.BackColor = backColor;
            listView1.ForeColor = textColor;
            gridCheckBox.BackColor = headerColor;
            gridCheckBox.ForeColor = textColor;
            resetButton.BackColor = backColor;
            resetButton.ForeColor = textColor;
            saveButton.BackColor = backColor;
            saveButton.ForeColor = textColor;
            loadButton.BackColor = backColor;
            loadButton.ForeColor = textColor;   
            darkModeButton.BackColor = backColor;
            darkModeButton.ForeColor = textColor;
            rtsCheckBox.ForeColor = textColor;
        }

        private void rtsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            returnToStart=rtsCheckBox.Checked;
            if (rtsCheckBox.Checked)
            {
                fileType=(byte)fileTypes.rts;
            }
            else
            {
                fileType = (byte)fileTypes.basic;
            }
            if (rtsCheckBox.Checked && _points.Count > 0 && _points[0] == _points[_points.Count - 1])
            {
                _points.RemoveAt(_points.Count - 1);
            }
            else if (_points.Count > 0 && !rtsCheckBox.Checked)
            {
                _points.Add(_points[0]);
            }
            Refresh();

        }

        

        private void gridCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            gridEnabled = gridCheckBox.Checked;
            Refresh();
        }

        private void gridTrackBar_Scroll(object sender, EventArgs e)
        {   
            gridSize = gridTrackBar.Value;
            if (gridEnabled)
            {
                Refresh();
            }
            
        }
        private void LoadFile(string path)
        {
            _points.Clear();
            listView1.Items.Clear();
            using (var stream = File.Open(path, FileMode.Open))
            {
                using (var reader = new BinaryReader(stream, System.Text.Encoding.ASCII, false))
                {
                    fileType = reader.ReadByte();
                    int length = fileType == (byte)fileTypes.basic ? reader.ReadInt32() : reader.ReadInt32() / 2 + 1;
                    for (int i = 0; i < length; i++)
                    {
                        _points.Add(new Point(reader.ReadInt32(), reader.ReadInt32()));
                    }
                }
            }
            for (int i = 0; i < _points.Count(); i++)
            {
                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(_points[i].X.ToString());
                item.SubItems.Add(_points[i].Y.ToString());
                item.BackColor = backColor;
                item.ForeColor = textColor;
                listView1.Items.Add(item);
            }
            if (fileType == (byte)fileTypes.rts)
            {
                rtsCheckBox.Checked = true;
            }
            else
            {
                rtsCheckBox.Checked = false;
            }
            rtsCheckBox_CheckedChanged(this, EventArgs.Empty);
        }
    }
}