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
	/// Form1 �̊T�v�̐����ł��B
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private Seasar.Controls.Win.XPButton xpButton1;
        private Seasar.Controls.Win.XPButton xpButton2;
        private Seasar.Controls.Win.XPButton xpButton3;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent �Ăяo���̌�ɁA�R���X�g���N�^ �R�[�h��ǉ����Ă��������B
			//
		}

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
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

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.xpButton1 = new Seasar.Controls.Win.XPButton();
            this.xpButton2 = new Seasar.Controls.Win.XPButton();
            this.xpButton3 = new Seasar.Controls.Win.XPButton();
            this.SuspendLayout();
            // 
            // xpButton1
            // 
            this.xpButton1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.xpButton1.Location = new System.Drawing.Point(32, 32);
            this.xpButton1.Name = "xpButton1";
            this.xpButton1.TabIndex = 0;
            this.xpButton1.Text = "xpButton1";
            // 
            // xpButton2
            // 
            this.xpButton2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.xpButton2.Location = new System.Drawing.Point(32, 96);
            this.xpButton2.Name = "xpButton2";
            this.xpButton2.Size = new System.Drawing.Size(96, 23);
            this.xpButton2.TabIndex = 1;
            this.xpButton2.Text = "xpButton2(&T)";
            // 
            // xpButton3
            // 
            this.xpButton3.BackColor = System.Drawing.Color.AliceBlue;
            this.xpButton3.ForeColor = System.Drawing.Color.Navy;
            this.xpButton3.Location = new System.Drawing.Point(136, 168);
            this.xpButton3.Name = "xpButton3";
            this.xpButton3.Size = new System.Drawing.Size(88, 32);
            this.xpButton3.TabIndex = 2;
            this.xpButton3.Text = "xpButton3";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.xpButton3);
            this.Controls.Add(this.xpButton2);
            this.Controls.Add(this.xpButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
