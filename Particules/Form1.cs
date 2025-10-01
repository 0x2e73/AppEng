using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Particules
{
    public partial class Form1 : Form
    {
        private PictureBox canvas;
        private List<Particle> particles;
        private Timer animationTimer;
        private PointF center;
        private const int MAX_DISTANCE = 400;
        private const int PARTICLE_COUNT = 30;

        public Form1()
        {
            InitializeComponent();
            SetupCanvas();
            SetupParticles();
            SetupAnimation();
        }

        private void SetupCanvas()
        {
            // PictureBox qui prend toute la fenêtre
            canvas = new PictureBox
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Black
            };
            this.Controls.Add(canvas);

            // Centre de l'écran
            center = new PointF(this.Width / 2, this.Height / 2);
        }

        private void SetupParticles()
        {
            particles = new List<Particle>();

            // Crée plusieurs particules au centre
            for (int i = 0; i < PARTICLE_COUNT; i++)
            {
                Particle p = new Particle(center, 3f);
                particles.Add(p);
                canvas.Controls.Add(p);
            }
        }

        private void SetupAnimation()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 50; // 20 FPS
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Liste des particules à supprimer
            List<Particle> toRemove = new List<Particle>();

            foreach (Particle particle in particles)
            {
                // Bouge la particule
                particle.Move();

                // Vérifie si elle dépasse la distance limite
                if (particle.DistanceFromCenter(center) > MAX_DISTANCE)
                {
                    toRemove.Add(particle);
                }
            }

            // Supprime les particules trop loin
            foreach (Particle particle in toRemove)
            {
                canvas.Controls.Remove(particle);
                particles.Remove(particle);
                particle.Dispose();
            }

            // Si plus de particules, on peut en recréer (optionnel)
            if (particles.Count == 0)
            {
                SetupParticles();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 600);
            this.Name = "Form1";
            this.Text = "Particules";
            this.ResumeLayout(false);
        }
    }
}
}
