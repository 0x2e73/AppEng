using System;
using System.Drawing;
using System.Windows.Forms;

namespace Particules
{
    public class Particle : PictureBox
    {
        public PointF Position { get; set; }
        public float Angle { get; set; }
        public float Speed { get; set; }

        // Constructeur par défaut pour la toolbox
        public Particle() : this(new PointF(400, 300), 3f)
        {
        }

        // Constructeur avec paramètres
        public Particle(PointF startPosition, float speed)
        {
            Position = startPosition;
            Speed = speed;

            // Génère un angle aléatoire UNE SEULE FOIS
            Random rand = new Random(Guid.NewGuid().GetHashCode()); // Évite les mêmes angles
            Angle = ToRadians(rand.Next(0, 360));

            // Configure l'apparence
            this.Size = new Size(6, 6);
            this.BackColor = Color.Red;
            this.Location = new Point((int)Position.X, (int)Position.Y);
        }

        public void Move()
        {
            // Calcule le déplacement avec trigonométrie
            float deltaX = Speed * (float)Math.Cos(Angle);
            float deltaY = Speed * (float)Math.Sin(Angle);

            Position = new PointF(Position.X + deltaX, Position.Y + deltaY);
            this.Location = new Point((int)Position.X, (int)Position.Y);
        }

        public float ToRadians(float degrees)
        {
            return (float)(Math.PI / 180) * degrees;
        }

        // Méthode pour calculer la distance du centre
        public float DistanceFromCenter(PointF center)
        {
            float dx = Position.X - center.X;
            float dy = Position.Y - center.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
