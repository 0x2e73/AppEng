namespace Particules
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.particle2 = new Particules.Particle();
            ((System.ComponentModel.ISupportInitialize)(this.particle2)).BeginInit();
            this.SuspendLayout();
            // 
            // particle2
            // 
            this.particle2.Angle = 0.5759587F;
            this.particle2.BackColor = System.Drawing.Color.Red;
            this.particle2.Location = new System.Drawing.Point(0, -2);
            this.particle2.Name = "particle2";
            this.particle2.Position = ((System.Drawing.PointF)(resources.GetObject("particle2.Position")));
            this.particle2.Size = new System.Drawing.Size(407, 347);
            this.particle2.Speed = 5F;
            this.particle2.TabIndex = 0;
            this.particle2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 520);
            this.Controls.Add(this.particle2);
            this.Name = "Form1";
            this.Text = "Particules";
            ((System.ComponentModel.ISupportInitialize)(this.particle2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Particle particle1;
        private Particle particle2;
    }
}

