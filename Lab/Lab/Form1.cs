using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab
{
	public partial class Form1 : Form
	{
		Color historyColor;
		bool drawing;
		int historyCounter;
		GraphicsPath currentPath;
		Point oldLocation;
	public static Pen currentPen;
		List<Image> History;
		int figuri = 0;	
		int locallX = 0;
		int locallY = 0;
		int locallXO = 0;
		int locallY0 = 0;
		Image Original;


		public Form1()
		{
			InitializeComponent();
			drawing = false;
			currentPen = new Pen(Color.Black);
			currentPen.Width = trackBar1.Value;
			History = new List<Image>();
		}

		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Версия 1,1 \nРазработчик Dungeon Master");
		}

		private void NewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Bitmap pic = new Bitmap(711, 469);
			History.Clear();
			historyCounter = 0;
			picDrawingSurface.Image = pic;
			History.Add(new Bitmap(picDrawingSurface.Image));
			if (picDrawingSurface.Image != null)
			{
				var result = MessageBox.Show("Сохранить текущее изображение перед созданием нового рисунка?", "Предупреждение", MessageBoxButtons.YesNoCancel);

				switch (result)
				{
					case DialogResult.No: break;
					case DialogResult.Yes: SaveToolStripMenuItem_Click(sender, e); break;
					case DialogResult.Cancel: return;
				}
			}
		}

		private void PicDrawingSurface_MouseDown(object sender, MouseEventArgs e)
		{
			if (picDrawingSurface.Image == null)
			{
				MessageBox.Show("Сначала создайте новый файл!");
				return;
			}
			if (e.Button == MouseButtons.Left)
			{
				drawing = true;
				oldLocation = e.Location;
				currentPath = new GraphicsPath();
			}
			if (e.Button == MouseButtons.Right)
			{
				historyColor = currentPen.Color;
				currentPen.Color=Color.White;
			}
		}

		private void ToolStripButton2_Click(object sender, EventArgs e)
		{
			SaveFileDialog SaveDlg = new SaveFileDialog();
			SaveDlg.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
			SaveDlg.Title = "Save an Image File";
			SaveDlg.FilterIndex = 4;
			SaveDlg.ShowDialog();
			if (SaveDlg.FileName != "")
			{
				System.IO.FileStream fs =
					(System.IO.FileStream)SaveDlg.OpenFile();

				switch (SaveDlg.FilterIndex)
				{
					case 1:
						this.picDrawingSurface.Image.Save(fs, ImageFormat.Jpeg);
						break;
					case 2:
						this.picDrawingSurface.Image.Save(fs, ImageFormat.Bmp);
						break;
					case 3:
						this.picDrawingSurface.Image.Save(fs, ImageFormat.Gif);
						break;
					case 4:
						this.picDrawingSurface.Image.Save(fs, ImageFormat.Png);
						break;
				}
				fs.Close();
			}
		}

		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog SaveDlg = new SaveFileDialog();
			SaveDlg.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
			SaveDlg.Title = "Save an Image File";
			SaveDlg.FilterIndex = 4;
			SaveDlg.ShowDialog();
			if (SaveDlg.FileName != "")
			{
				System.IO.FileStream fs =
					(System.IO.FileStream)SaveDlg.OpenFile();

				switch (SaveDlg.FilterIndex)
				{
					case 1:
						this.picDrawingSurface.Image.Save(fs, ImageFormat.Jpeg);
						break;
					case 2:
						this.picDrawingSurface.Image.Save(fs, ImageFormat.Bmp);
						break;
					case 3:
						this.picDrawingSurface.Image.Save(fs, ImageFormat.Gif);
						break;
					case 4:
						this.picDrawingSurface.Image.Save(fs, ImageFormat.Png);
						break;
				}
				fs.Close();
			}
		}

		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog OP = new OpenFileDialog();
			OP.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
			OP.Title = "Open an Image File";
			OP.FilterIndex = 1;
			if (OP.ShowDialog() != DialogResult.Cancel)
				picDrawingSurface.Load(OP.FileName);
			picDrawingSurface.AutoSize = true;
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (picDrawingSurface.Image != null)
			{
				var result = MessageBox.Show("Сохранить текущее изображение перед выходом?", "Предупреждение", MessageBoxButtons.YesNoCancel);

				switch (result)
				{
					case DialogResult.No: Application.Exit(); break;
					case DialogResult.Yes: SaveToolStripMenuItem_Click(sender, e); Application.Exit(); break;
					case DialogResult.Cancel: return;
				}
			}
		}

		private void ToolStripButton1_Click(object sender, EventArgs e)
		{
			Bitmap pic = new Bitmap(711, 469);
			picDrawingSurface.Image = pic;
			if (picDrawingSurface.Image != null)
			{
				var result = MessageBox.Show("Сохранить текущее изображение перед созданием нового рисунка?", "Предупреждение", MessageBoxButtons.YesNoCancel);

				switch (result)
				{
					case DialogResult.No: break;
					case DialogResult.Yes: SaveToolStripMenuItem_Click(sender, e); break;
					case DialogResult.Cancel: return;
				}
			}
		}

		private void ToolStripButton3_Click(object sender, EventArgs e)
		{
			OpenFileDialog OP = new OpenFileDialog();
			OP.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
			OP.Title = "Open an Image File";
			OP.FilterIndex = 1;
			if (OP.ShowDialog() != DialogResult.Cancel)
				picDrawingSurface.Load(OP.FileName);
			picDrawingSurface.AutoSize = true;
		}

		private void ToolStripButton5_Click(object sender, EventArgs e)
		{
			if (picDrawingSurface.Image != null)
			{
				var result = MessageBox.Show("Сохранить текущее изображение перед выходом?", "Предупреждение", MessageBoxButtons.YesNoCancel);

				switch (result)
				{
					case DialogResult.No: Application.Exit(); break;
					case DialogResult.Yes: SaveToolStripMenuItem_Click(sender, e); Application.Exit(); break;
					case DialogResult.Cancel: return;
				}
			}
		}

		private void PicDrawingSurface_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right) currentPen.Color = historyColor;

			if (figuri == 1)
			{

				Graphics g = Graphics.FromImage(picDrawingSurface.Image);
				currentPath.AddRectangle(new Rectangle(locallX, locallY, locallXO, locallY0));
				g.DrawPath(currentPen, currentPath);
				oldLocation = e.Location;
				g.Dispose();
				picDrawingSurface.Invalidate();
			}

			if (figuri == 2)
			{

				Graphics g = Graphics.FromImage(picDrawingSurface.Image);
				currentPath.AddEllipse(locallX, locallY, locallXO, locallY0);
				g.DrawPath(currentPen, currentPath);
				oldLocation = e.Location;
				g.Dispose();
				picDrawingSurface.Invalidate();
			}
			if (figuri == 3)
			{
				Graphics g = Graphics.FromImage(picDrawingSurface.Image);

				/*       locallX =  e.Location.X;
					   locallY = e.Location.Y;*/


				currentPath.AddLine(locallX, locallY, e.Location.X, e.Location.Y);

				g.DrawPath(currentPen, currentPath);
				oldLocation = e.Location;
				g.Dispose();
				picDrawingSurface.Invalidate();

			}
			if (figuri == 4)
			{
				Graphics g = Graphics.FromImage(picDrawingSurface.Image);
				locallXO = locallY0;
				locallY0 = locallXO;
				currentPath.AddRectangle(new Rectangle(locallX, locallY, locallXO, locallY0));
				g.DrawPath(currentPen, currentPath);
				oldLocation = e.Location;
				g.Dispose();
				picDrawingSurface.Invalidate();

			}
			if (figuri == 5)
			{
				Graphics g = Graphics.FromImage(picDrawingSurface.Image);
				g.DrawLine(currentPen, new Point(locallX, locallY + 50), new Point(locallY + 50, locallY0));
				g.DrawLine(currentPen, new Point(locallX + 50, locallY), new Point(locallY + 50, locallY0 + 100));
				g.DrawLine(currentPen, new Point(locallX + 50, locallY + 100), new Point(locallY, locallY0 + 50));
				g.DrawPath(currentPen, currentPath);
				oldLocation = e.Location;
				g.Dispose();
				picDrawingSurface.Invalidate();

			}
			if (figuri == 6)
			{
				Graphics g = Graphics.FromImage(picDrawingSurface.Image);
				currentPath.AddLines(new[]
				{
					new Point(locallX, locallY + (locallY0 / 2)),
					new Point(locallX + (locallXO / 2), locallY),
					new Point(locallX + locallXO, locallY + (locallY0 / 2)),
					new Point(locallX + (locallXO / 2), locallY + locallY0),
					new Point(locallX, locallY + (locallY0 / 2))
				});
				g.DrawPath(currentPen, currentPath);
				oldLocation = e.Location;
				g.Dispose();
				picDrawingSurface.Invalidate();
			}

			//  history.RemoveRange(historyCounter + 1, history.Count - historyCounter - 1);
			History.Add(new Bitmap(picDrawingSurface.Image));
			if (historyCounter + 1 < 100000) historyCounter++;
			if (History.Count - 1 == 100000) History.RemoveAt(0);
			drawing = false;
			try
			{
				currentPath.Dispose();
			}
			catch { };
		}

		private void PicDrawingSurface_MouseMove(object sender, MouseEventArgs e)
		{
			
				if (drawing)
				{
					if (figuri == 0)
					{
						Graphics g = Graphics.FromImage(picDrawingSurface.Image);
						/* g.Clear(Color.White);
						g.DrawImage(pictureBox1.Image, 0, 0, 733, 337);*/
						currentPath.AddLine(oldLocation, e.Location);
						g.DrawPath(currentPen, currentPath);
						oldLocation = e.Location;
						g.Dispose();
						picDrawingSurface.Invalidate();
					}
					}
					if (figuri != 0)
					{
						locallX = oldLocation.X;
						locallY = oldLocation.Y;
						locallXO = e.Location.X - oldLocation.X;
						locallY0 = e.Location.Y - oldLocation.Y;
					}

				label1.Text = e.X.ToString() + ", " + e.Y.ToString();
		}

		private void TrackBar1_Scroll(object sender, EventArgs e)
		{
			currentPen.Width = trackBar1.Value;
		}

		private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (History.Count != 0 && historyCounter != 0)
			{
				picDrawingSurface.Image = new Bitmap(History[--historyCounter]);
			}
			else MessageBox.Show("История пуста");
		}

		private void RenoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (historyCounter < History.Count - 1)
			{
				picDrawingSurface.Image = new Bitmap(History[++historyCounter]);
			}
			else MessageBox.Show("История пуста");
		}

		public void SolidToolStripMenuItem_Click(object sender, EventArgs e)
		{
			currentPen.DashStyle = DashStyle.Solid;

			solidToolStripMenuItem.Checked = true;
			dashDotDotToolStripMenuItem.Checked = false;
			doyToolStripMenuItem.Checked = false;
			dashDotDotToolStripMenuItem.Checked = false;

		}

		public void DashDotDotToolStripMenuItem_Click(object sender, EventArgs e)
		{
			currentPen.DashStyle = DashStyle.DashDotDot;

			solidToolStripMenuItem.Checked = false;
			dashDotDotToolStripMenuItem.Checked = true;
			doyToolStripMenuItem.Checked = false;
			dashDotDotToolStripMenuItem.Checked = false;
		}

		public void DoyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			currentPen.DashStyle = DashStyle.Dash;

			solidToolStripMenuItem.Checked = false;
			dashDotDotToolStripMenuItem.Checked = false;
			doyToolStripMenuItem.Checked = true;
			dashDotDotToolStripMenuItem.Checked = false;
		}

		private void ToolStripButton4_Click(object sender, EventArgs e)
		{
			Form2 f = new Form2();
			f.Owner = this;
			f.ShowDialog();
		}

		private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form2 f = new Form2();
			f.Owner = this;
			f.ShowDialog();
		}

		private void DashDotToolStripMenuItem_Click(object sender, EventArgs e)
		{
			currentPen.DashStyle = DashStyle.DashDot;

			solidToolStripMenuItem.Checked = false;
			dashDotDotToolStripMenuItem.Checked = false;
			doyToolStripMenuItem.Checked = false;
			dashDotDotToolStripMenuItem.Checked = true;
		}

		private void TriangleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			figuri = 6;
		}

		private void PenToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			figuri = 0;
		}

		private void RectangleToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			figuri = 1;
		}

		private void ElipseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			figuri = 2;
		}

		private void LineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			figuri = 3;
		}
	}
}
