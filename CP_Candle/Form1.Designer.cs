namespace Candle_CP
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Load_frames = new System.Windows.Forms.Button();
            this.Start_animation = new System.Windows.Forms.Button();
            this.Frame_generate = new System.Windows.Forms.Button();
            this.stop_animation = new System.Windows.Forms.Button();
            this.FPS = new System.Windows.Forms.NumericUpDown();
            this.framegen_num = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pathlabel = new System.Windows.Forms.Label();
            this.setframe_download = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.framegen_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setframe_download)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(-3, 27);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(801, 561);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Click += new System.EventHandler(this.canvas_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 33;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Load_frames
            // 
            this.Load_frames.Location = new System.Drawing.Point(806, 410);
            this.Load_frames.Name = "Load_frames";
            this.Load_frames.Size = new System.Drawing.Size(234, 39);
            this.Load_frames.TabIndex = 6;
            this.Load_frames.Text = "Подгрузить кадры из указанной папки";
            this.Load_frames.UseVisualStyleBackColor = true;
            this.Load_frames.Click += new System.EventHandler(this.Load_frames_Click);
            // 
            // Start_animation
            // 
            this.Start_animation.Location = new System.Drawing.Point(806, 27);
            this.Start_animation.Name = "Start_animation";
            this.Start_animation.Size = new System.Drawing.Size(234, 39);
            this.Start_animation.TabIndex = 8;
            this.Start_animation.Text = "Запустить анимацию";
            this.Start_animation.UseVisualStyleBackColor = true;
            this.Start_animation.Click += new System.EventHandler(this.Start_animation_Click);
            // 
            // Frame_generate
            // 
            this.Frame_generate.Location = new System.Drawing.Point(806, 241);
            this.Frame_generate.Name = "Frame_generate";
            this.Frame_generate.Size = new System.Drawing.Size(234, 39);
            this.Frame_generate.TabIndex = 9;
            this.Frame_generate.Text = "Сгенерировать и сохранить кадры в папку";
            this.Frame_generate.UseVisualStyleBackColor = true;
            this.Frame_generate.Click += new System.EventHandler(this.Frame_generate_Click);
            // 
            // stop_animation
            // 
            this.stop_animation.Location = new System.Drawing.Point(806, 182);
            this.stop_animation.Name = "stop_animation";
            this.stop_animation.Size = new System.Drawing.Size(234, 39);
            this.stop_animation.TabIndex = 11;
            this.stop_animation.Text = "Остановить анимацию";
            this.stop_animation.UseVisualStyleBackColor = true;
            this.stop_animation.Click += new System.EventHandler(this.stop_animation_Click);
            // 
            // FPS
            // 
            this.FPS.Location = new System.Drawing.Point(806, 85);
            this.FPS.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.FPS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FPS.Name = "FPS";
            this.FPS.Size = new System.Drawing.Size(234, 20);
            this.FPS.TabIndex = 13;
            this.FPS.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // framegen_num
            // 
            this.framegen_num.Location = new System.Drawing.Point(809, 312);
            this.framegen_num.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.framegen_num.Name = "framegen_num";
            this.framegen_num.Size = new System.Drawing.Size(231, 20);
            this.framegen_num.TabIndex = 14;
            this.framegen_num.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(803, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Задать количество кадров в секунду";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(806, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Задать количество кадров для генерации";
            // 
            // pathlabel
            // 
            this.pathlabel.AutoSize = true;
            this.pathlabel.Location = new System.Drawing.Point(806, 121);
            this.pathlabel.Name = "pathlabel";
            this.pathlabel.Size = new System.Drawing.Size(240, 13);
            this.pathlabel.TabIndex = 17;
            this.pathlabel.Text = "Текущий путь откуда запускается анимация: ";
            // 
            // setframe_download
            // 
            this.setframe_download.Location = new System.Drawing.Point(806, 468);
            this.setframe_download.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.setframe_download.Name = "setframe_download";
            this.setframe_download.Size = new System.Drawing.Size(234, 20);
            this.setframe_download.TabIndex = 18;
            this.setframe_download.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(803, 452);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Задать количество кадров для подгрузки";
            this.label3.UseMnemonic = false;
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(806, 338);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(234, 24);
            this.pBar.TabIndex = 20;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1052, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1052, 590);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.setframe_download);
            this.Controls.Add(this.pathlabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.framegen_num);
            this.Controls.Add(this.FPS);
            this.Controls.Add(this.stop_animation);
            this.Controls.Add(this.Frame_generate);
            this.Controls.Add(this.Start_animation);
            this.Controls.Add(this.Load_frames);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.framegen_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setframe_download)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Load_frames;
        private System.Windows.Forms.Button Start_animation;
        private System.Windows.Forms.Button Frame_generate;
        private System.Windows.Forms.Button stop_animation;
        private System.Windows.Forms.NumericUpDown FPS;
        private System.Windows.Forms.NumericUpDown framegen_num;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label pathlabel;
        private System.Windows.Forms.NumericUpDown setframe_download;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

