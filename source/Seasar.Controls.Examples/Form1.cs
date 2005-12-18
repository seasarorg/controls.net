#region Copyright
/*
 * Copyright 2005 the Seasar Foundation and the Others.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language
 * governing permissions and limitations under the License.
 */
#endregion

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Seasar.Controls.Examples
{
	/// <summary>
	/// Form1 の概要の説明です。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private Seasar.Controls.Win.XPButton xpButton1;
        private Seasar.Controls.Win.XPButton xpButton2;
        private Seasar.Controls.Win.XPButton xpButton3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private Seasar.Controls.Win.XPButton xpButton4;
        private System.Windows.Forms.Button button4;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
			//
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.xpButton1 = new Seasar.Controls.Win.XPButton();
            this.xpButton2 = new Seasar.Controls.Win.XPButton();
            this.xpButton3 = new Seasar.Controls.Win.XPButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.xpButton4 = new Seasar.Controls.Win.XPButton();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpButton1
            // 
            this.xpButton1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.xpButton1.Location = new System.Drawing.Point(16, 24);
            this.xpButton1.Name = "xpButton1";
            this.xpButton1.Size = new System.Drawing.Size(80, 23);
            this.xpButton1.TabIndex = 0;
            this.xpButton1.Text = "xpButton1";
            // 
            // xpButton2
            // 
            this.xpButton2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.xpButton2.Location = new System.Drawing.Point(16, 56);
            this.xpButton2.Name = "xpButton2";
            this.xpButton2.Size = new System.Drawing.Size(80, 23);
            this.xpButton2.TabIndex = 1;
            this.xpButton2.Text = "xpButton2(&T)";
            // 
            // xpButton3
            // 
            this.xpButton3.BackColor = System.Drawing.Color.AliceBlue;
            this.xpButton3.ForeColor = System.Drawing.Color.Navy;
            this.xpButton3.Location = new System.Drawing.Point(112, 24);
            this.xpButton3.Name = "xpButton3";
            this.xpButton3.Size = new System.Drawing.Size(72, 24);
            this.xpButton3.TabIndex = 2;
            this.xpButton3.Text = "xpButton3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 24);
            this.button1.Name = "button1";
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 88);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通常のボタン";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.xpButton4);
            this.groupBox2.Controls.Add(this.xpButton1);
            this.groupBox2.Controls.Add(this.xpButton2);
            this.groupBox2.Controls.Add(this.xpButton3);
            this.groupBox2.Location = new System.Drawing.Point(16, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 104);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 56);
            this.button2.Name = "button2";
            this.button2.TabIndex = 4;
            this.button2.Text = "button2(&T)";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.AliceBlue;
            this.button3.ForeColor = System.Drawing.Color.Navy;
            this.button3.Location = new System.Drawing.Point(112, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 24);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            // 
            // xpButton4
            // 
            this.xpButton4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.xpButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xpButton4.Location = new System.Drawing.Point(112, 56);
            this.xpButton4.Name = "xpButton4";
            this.xpButton4.TabIndex = 3;
            this.xpButton4.Text = "xpButton4";
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(112, 56);
            this.button4.Name = "button4";
            this.button4.TabIndex = 6;
            this.button4.Text = "button4";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
