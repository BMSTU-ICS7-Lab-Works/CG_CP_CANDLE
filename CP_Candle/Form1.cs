using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Candle_CP
{
    public partial class Form1 : Form
    {
        Bitmap img;
        Graphics g;
        Scene scene;
        List<Bitmap> frames = new List<Bitmap>();
        FolderBrowserDialog FBD = new FolderBrowserDialog();

        int i = 0;
        int curframe = 0;
        int outframe = 0;

        public Form1()
        {
            
            InitializeComponent();
            g = canvas.CreateGraphics();
            this.scene = new Scene(canvas.Size);
            this.scene.createScene();
            outframe = 0;
            timer1.Interval = (int)(1000 / FPS.Value);
            pathlabel.Text = "Текущий путь:\n D:\\3qrs1sem\\CP_Candle\\frames\\";
            for (int i = 0; i < 30; i++)
            {
                img = new Bitmap(string.Concat("D:\\3qrs1sem\\CP_Candle\\frames\\frame", outframe.ToString(), ".jpg"));
                this.frames.Add(img);
                outframe++;
            }

            timer1.Enabled = true;
            pBar.Visible = false;

            ToolStripMenuItem aboutItem = new ToolStripMenuItem("О программе");
            aboutItem.Click += aboutItem_Click;
            menuStrip1.Items.Add(aboutItem);
            /*
            scene = new Scene(canvas.Size);
            scene.createScene();
            RayTracer rt = new RayTracer(scene);
            img = rt.GetBitmap();
            //this.frames.Add(img);
            canvas.Image = img;
            */
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            canvas.Image = frames[i];
            i++;
            if (i == frames.Count)
                i = 0;
        }

        private void Load_frames_Click(object sender, EventArgs e)
        {
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                timer1.Enabled = false;
                this.frames.Clear();
                outframe = 0;
                string path = FBD.SelectedPath;
                pathlabel.Text = string.Concat("Текущий путь: ", path, "\\");
                int end = (int)setframe_download.Value;
                for (int i = 0; i < end; i++)
                {
                    try
                    {
                        img = new Bitmap(string.Concat(path, "\\frame", outframe.ToString(), ".jpg"));
                        this.frames.Add(img);
                    }
                    catch
                    {
                        timer1.Enabled = false;
                        pathlabel.Text = string.Concat("Текущий путь:\n путь не выбран!");
                        this.frames.Clear();
                        MessageBox.Show("В данной папке отсутствует нужное количество кадров!");
                        break;
                    }
                    this.frames.Add(img);
                    outframe++;
                }
            }
                
        }

        private void Frame_generate_Click(object sender, EventArgs e)
        {
            curframe = 0;
            timer1.Enabled = false;
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                string path = FBD.SelectedPath;
                int end = (int) framegen_num.Value;
                pBar.Visible = true;
                pBar.Minimum = 0;
                pBar.Maximum = end;
                pBar.Step = 1;
                for (int num = 0; num < end; num++)
                {
                    pBar.PerformStep();
                    RayTracer rt = new RayTracer(scene);
                    img = rt.GetBitmap();
                    string filenum = curframe.ToString();
                    img.Save(string.Concat(path, "\\frame", filenum, ".jpg"));
                    curframe++;
                }
                MessageBox.Show("Генерация окончена!");
            }
            
        }

        private void Start_animation_Click(object sender, EventArgs e)
        {
            
            if (this.frames.Count == 0)
            {
                MessageBox.Show("Кадры не были подгружены!");
            }
            else
            {
                timer1.Interval = (int)(1000 / FPS.Value);
                i = 0;
                timer1.Enabled = true;
            }
                
            
        }

        private void stop_animation_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void canvas_Click(object sender, EventArgs e)
        {

        }

        void aboutItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа моделирования огня, исходящего от свечи.\nВыполнил: Чалый А.А.\nГруппа: ИУ7-52Б");
        }
    }
}